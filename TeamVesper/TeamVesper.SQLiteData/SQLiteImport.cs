using System;
using System.Collections.Generic;

using System.Data.SQLite;

using TeamVesper.Models;

namespace TeamVesper.SQLiteData
{
    public class SQLiteImport
    {
        private string sqLiteDbConnectionString;

        public SQLiteImport(string connectionString)
        {
            this.SQLiteDbConnectionString = connectionString;
        }

        public string SQLiteDbConnectionString
        {
            get
            {
                return this.sqLiteDbConnectionString;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Connection string cannot by null.");
                }

                this.sqLiteDbConnectionString = value;
            }
        }

        public IEnumerable<Company> ExtractCompaniesAndTheirAverageSalaries()
        {
            SQLiteConnection dbConnection = new SQLiteConnection(sqLiteDbConnectionString);
            dbConnection.Open();

            SQLiteCommand companiesAndTheirAverageSalariesQuery = new SQLiteCommand(@"SELECT Companies.Name, AVG(Salary) as AverageSalary
                                                                FROM Employees
                                                                INNER JOIN Companies
                                                                ON Companies.Id = Employees.CompanyId
                                                                GROUP BY Companies.Name
                                                                ORDER BY AverageSalary DESC", dbConnection);

            SQLiteDataReader reader = companiesAndTheirAverageSalariesQuery.ExecuteReader();

            var companyCollection = new List<Company>();

            using (reader)
            {
                while (reader.Read())
                {
                    var company = new Company(reader["Name"].ToString(), Convert.ToDecimal(reader["AverageSalary"]));

                    companyCollection.Add(company);
                }
            }

            dbConnection.Clone();

            return companyCollection;
        }
    }
}