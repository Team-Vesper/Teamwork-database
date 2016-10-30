﻿namespace TeamVesper.DbCreate
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.IO;
    using System.IO.Compression;
    using Models;

    public static class ExcelReader
    {
        private const string extractPath = "../../../Bugs";

        public static List<Bug> Read(string path)
        {
            var bugs = new List<Bug>();
            using (ZipArchive archive = ZipFile.Open(path, ZipArchiveMode.Update))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".xlsx"))
                    {
                        entry.ExtractToFile(Path.Combine(extractPath, entry.Name));
                        string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path.Combine(extractPath, entry.Name) + ";Extended Properties='Excel 12.0 xml;HDR=Yes';";

                        OleDbConnection connection = new OleDbConnection(connectionString);

                        using (connection)
                        {
                            connection.Open();
                            var excelSchema = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                            var sheetName = excelSchema.Rows[0]["TABLE_NAME"].ToString();
                            bugs = ReadExcelData(connection, sheetName);
                        }
                        File.Delete(Path.Combine(extractPath, entry.Name));
                    }
                }

                return bugs;
            }
        }

        private static List<Bug> ReadExcelData(OleDbConnection conn, string sheetName)
        {
            var excelDbCommand = new OleDbCommand(@"SELECT * FROM [" + sheetName + "]", conn);
            using (var oleDbDataAdapter = new OleDbDataAdapter(excelDbCommand))
            {
                DataSet ds = new DataSet();
                oleDbDataAdapter.Fill(ds);
                var bugs = new List<Bug>();
                using (var reader = ds.CreateDataReader())
                {
                    while (reader.Read())
                    {
                        var bug = new Bug();
                        bug.Id = int.Parse(reader["ID"].ToString());
                        bug.Description = reader["Description"].ToString();
                        bug.PriorityId = int.Parse(reader["Priority"].ToString());
                        var tempDate = new DateTime();
                        if (DateTime.TryParse(reader["solvedOn"].ToString(), out tempDate))
                        {
                            bug.solvedOn = tempDate;
                        }
                        else
                        {
                            bug.solvedOn = null;
                        }
                        bugs.Add(bug);
                    }
                }

                return bugs;
            }
        }
    }
}
