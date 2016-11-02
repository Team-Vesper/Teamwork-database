using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Collections.Generic;

using TeamVesper.XmlDataReader.Contracts;
using TeamVesper.Models;
using System;

namespace TeamVesper.XmlDataReader
{
    public class XmlToDTOEducationConverter : IXmlToDTOEducationConverter
    {
        private string filePath;

        public XmlToDTOEducationConverter(string filePath)
        {
            this.FilePath = filePath;
        }

        private string FilePath
        {
            get
            {
                return this.filePath;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("XML file path cannot be null!");
                }

                if (value == string.Empty)
                {
                    throw new ArgumentException("XML file path cannot be empty string!");
                }
            }
        }

        public IEnumerable<DTOEducation> GetAllDeveloppersEducations()
        {
            var xmlDocument = XDocument.Load(this.FilePath);
            var xmlFormatEducations = xmlDocument.Descendants("developperEducation");
            var pocoEducations = new List<DTOEducation>();

            foreach (var education in xmlFormatEducations)
            {
                var stringReader = new StringReader(education.ToString());
                var xmlSerializer = new XmlSerializer(typeof(DTOEducation));
                var current = (DTOEducation)xmlSerializer.Deserialize(stringReader);

                pocoEducations.Add(current);
            }

            return pocoEducations;
        }
    }
}
