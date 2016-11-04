using System;
using System.Collections.Generic;
using System.Globalization;

using ClosedXML.Excel;

using TeamVesper.Models;
using TeamVesper.Repositories.Contracts;
using System.Linq;

namespace TeamVesper.ExportToExcel
{
    public class CompanyExcelExporter<TEntity> : IReporter<TEntity>
        where TEntity : CompanyOverview
    {
        private string sheetName;
        private string outputFolder;
        private string outputFileName;

        public CompanyExcelExporter(string sheetName,
                                        string outputFolder,
                                        string outputFileName)
        {
            this.SheetName = sheetName;
            this.OutputFolder = outputFolder;
            this.OutputFileName = outputFileName;
        }

        private string SheetName
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("SheetName");
                }

                this.sheetName = value;
            }
        }

        private string OutputFolder
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("OutputFolder");
                }

                this.outputFolder = value;
            }
        }

        private string OutputFileName
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("OutputFileName");
                }

                this.outputFileName = value;
            }
        }

        public void ReportMany(IEnumerable<TEntity> entities)
        {
            this.ExportCollection(entities.ToList());
        }

        public void ReportSingle(TEntity entity)
        {
            var list = new List<TEntity>();
            list.Add(entity);

            this.ReportMany(list);
        }

        private void ExportCollection(IList<TEntity> companyCollection)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add(this.sheetName);

            // column names start from 1, e.g. A1, B1
            var columnNamesExcelRowIndex = 1;

            // real data under cell name starts from 2, e.g. A2, B2
            var columnDataExcelRowStartingIndex = 2;

            // char hex representation of 'A' needed for the excel columns index
            var cellA = 0x41;

            // getting property names from the first collection object element using reflection
            var propertyNames = companyCollection[0].GetType().GetProperties();

            // inserting object properties as table names in the excel file
            for (int i = 0; i < propertyNames.Length; i++)
            {
                worksheet.Cell(Convert.ToString((char)cellA) + columnNamesExcelRowIndex).Value = propertyNames[i].Name;
                worksheet.Cell(Convert.ToString((char)cellA) + columnNamesExcelRowIndex).RichText.Bold = true;
                cellA++;
            }

            // resetting to 'A'
            cellA = 0x41;

            // filling the data from object collection
            foreach (var company in companyCollection)
            {
                for (int i = 0; i < propertyNames.Length; i++)
                {
                    worksheet.Cell(Convert.ToString((char)cellA) + columnDataExcelRowStartingIndex).Value = propertyNames[i].GetValue(company);
                    cellA++;
                }
                cellA = 0x41;
                columnDataExcelRowStartingIndex++;
            }
            var timeNow = DateTime.Now.ToString("yyyyMMdd_hhmmss", CultureInfo.InvariantCulture);

            var FilePathNameDate = this.outputFolder + this.outputFileName + "_" + timeNow + ".xlsx";

            workbook.SaveAs(FilePathNameDate);
        }
    }
}