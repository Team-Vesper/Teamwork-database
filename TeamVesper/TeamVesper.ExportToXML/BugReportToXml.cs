using System;
using System.IO;
using System.Xml;
using System.Diagnostics;
using System.Collections.Generic;

using TeamVesper.Models;
using TeamVesper.Repositories.Contracts;

namespace TeamVesper.ExportToXML
{
    public class BugReportToXml : IReporter<BugReport>
    {
        private const string FileName = "BugsReports.xml";
        private const string Version = "1.0";
        private const string Encoding = "UTF-8";
        private const string RootName = "bugs";

        private string folderPath;

        public BugReportToXml(string folderPath)
        {
            this.FolderPath = folderPath;
        }

        private string FolderPath
        {
            get
            {
                return this.folderPath;
            }

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

        public void ReportSingle(BugReport entity)
        {
            var list = new List<BugReport>();

            list.Add(entity);
            this.ReportMany(list);
        }

        public void ReportMany(IEnumerable<BugReport> entities)
        {
            this.XmlCreateReports(entities);
        }

        private void XmlCreateReports(IEnumerable<BugReport> bugsReport)
        {
            XmlDocument xmlReport = new XmlDocument();
            XmlDeclaration xmlDeclaration = xmlReport.CreateXmlDeclaration(Version, Encoding, null);
            XmlElement root = xmlReport.CreateElement(RootName);

            foreach (var bug in bugsReport)
            {
                XmlElement bugElement = xmlReport.CreateElement("bug");
                bugElement.SetAttribute("id", bug.Id.ToString());

                XmlElement bugName = xmlReport.CreateElement("name");
                bugName.InnerText = bug.Name;

                XmlElement bugAcceptedOn = xmlReport.CreateElement("acceptedOn");
                bugAcceptedOn.InnerText = bug.AcceptedOn.ToString();

                XmlElement bugSolvedOn = xmlReport.CreateElement("solvedOn");
                bugSolvedOn.InnerText = bug.SolvedOn.ToString(); ;

                bugElement.AppendChild(bugName);
                bugElement.AppendChild(bugAcceptedOn);
                bugElement.AppendChild(bugSolvedOn);
                root.AppendChild(bugElement);
            }

            xmlReport.AppendChild(xmlDeclaration);
            xmlReport.AppendChild(root);
            xmlReport.Save(FolderPath + @"\" + FileName);
            Process.Start(FolderPath);
        }
    }
}
