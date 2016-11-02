using System;
using System.Collections.Generic;
using System.Globalization;

using ClosedXML.Excel;

using TeamVesper.Models;

namespace TeamVesper.ExportToExcel
{
    public class CompanyExcelExporter
    {
        static void ExportCollection(IList<CompanyOverview> companyCollection, string sheetName, string outputFolder, string outputFileName)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add(sheetName);

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

            var FilePathNameDate = outputFolder + outputFileName + "_" + timeNow + ".xlsx";

            workbook.SaveAs(FilePathNameDate);
        }
    }
}