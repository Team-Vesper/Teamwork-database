using System;
using iTextSharp.text;
using iTextSharp.text.pdf;
using TeamVesper.Repositories.Contracts;
using System.Collections.Generic;
using System.IO;
using TeamVesper.SqlServerData;
using System.Linq;
using TeamVesper.Models;

namespace TeamVesper.ExportToPdf
{
    public class PdfExporter<TEntity> : IReporter<TEntity>
        where TEntity : BugInfo
    {
        private const string ReportFileName = "Bug";
        private const string FileExtension = "pdf";
        private const string FileExtensionFormat = " {0}.{1}.{2}-{3}.{4}.{5}.";
        private const string EntityReportTitle = "Bugs Report generated on: ";
        private const string BugIdColumnHeader = "Bug Id";
        private const string BugDesriptionColumnHeader = "Bug Desription";
        private const string BugPriorityColumnHeader = "Bug Priority";
        private const string BugSpecialtyColumnHeader = "Bug Specialty";
        private const string BugSolvedOnColumnHeader = "Bug Solved On";
        private const string BugAttachedToDeveloperColumnHeader = "Bug Attached To";
        private const string BugAttachedToTeamColumnHeader = "Developer team";
        private const int PdfTableSize = 7;

        private string folderPath;

        public PdfExporter(string folderPath)
        {
            this.FolderPath = folderPath;
        }

        private string FolderPath
        {
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Directory path");
                }

                if (value == string.Empty)
                {
                    throw new ArgumentException("Direcotry path cannot be empty string!");
                }

                if (!Directory.Exists(value))
                {
                    Directory.CreateDirectory(value);
                }

                this.folderPath = value;
            }
        }

        public void ReportMany(IEnumerable<TEntity> entities)
        {
            this.GeneratePdfReport(entities);
        }

        public void ReportSingle(TEntity entity)
        {
            var list = new List<TEntity>();

            list.Add(entity);

            this.ReportMany(list);
        }

        private void GeneratePdfReport(IEnumerable<TEntity> report)
        {
            var document = new Document(PageSize.A4);
            var fileName = AddDateTimeSuffixtoFileName(ReportFileName) + FileExtension;
            var fileStream = new FileStream(this.folderPath + fileName, FileMode.Create, FileAccess.Write);
            var writer = PdfWriter.GetInstance(document, fileStream);

            document.Open();

            var table = this.FormatingReportTable();
            this.AddReportTableTitle(table);
            this.AddReportTableColumns(table);
            this.AddDataInReportTable(table, report);

            document.Add(table);
            document.Close();
        }

        private static string AddDateTimeSuffixtoFileName(string fileName)
        {
            var currentDate = DateTime.Now;
            string fileNameSuffix = string.Format(
               FileExtensionFormat,
                currentDate.Day,
                currentDate.Month,
                currentDate.Year,
                currentDate.Hour,
                currentDate.Minute,
                currentDate.Second);

            fileName = fileName + fileNameSuffix;

            return fileName;
        }

        private PdfPTable FormatingReportTable()
        {
            PdfPTable table = new PdfPTable(PdfTableSize);
            table.WidthPercentage = 100;
            table.LockedWidth = false;
            table.HorizontalAlignment = Element.ALIGN_CENTER;

            return table;
        }

        private void AddDataInReportTable(PdfPTable table, IEnumerable<TEntity> report)
        {
            foreach (var bug in report)
            {
                table.AddCell(bug.Id.ToString());
                table.AddCell(bug.Description);
                table.AddCell(bug.Priority);
                table.AddCell(bug.Speciality);
                table.AddCell(bug.SolvedOn);
                table.AddCell(bug.AttachTo);
                table.AddCell(bug.Team);
            }
        }

        private void AddReportTableColumns(PdfPTable table)
        {
            table.AddCell(SetColorToCell(BugIdColumnHeader));
            table.AddCell(SetColorToCell(BugDesriptionColumnHeader));
            table.AddCell(SetColorToCell(BugPriorityColumnHeader));
            table.AddCell(SetColorToCell(BugSpecialtyColumnHeader));
            table.AddCell(SetColorToCell(BugSolvedOnColumnHeader));
            table.AddCell(SetColorToCell(BugAttachedToDeveloperColumnHeader));
            table.AddCell(SetColorToCell(BugAttachedToTeamColumnHeader));
        }

        private PdfPCell SetColorToCell(string cellTitle)
        {
            var phrase = new Phrase(cellTitle);
            var cell = new PdfPCell(phrase);
            cell.BackgroundColor = BaseColor.GREEN;

            return cell;
        }

        private void AddReportTableTitle(PdfPTable table)
        {
            var title = AddDateTimeSuffixtoFileName(EntityReportTitle);
            var fullTitle = new Phrase(title);
            var titleCell = new PdfPCell(fullTitle);
            titleCell.Colspan = PdfTableSize;
            titleCell.HorizontalAlignment = Element.ALIGN_CENTER;
            titleCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            table.AddCell(titleCell);
        }
    }
}