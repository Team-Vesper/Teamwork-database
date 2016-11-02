using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Collections.Generic;

using TeamVesper.XmlDataReader.Models;
using TeamVesper.XmlDataReader.Contracts;

namespace TeamVesper.XmlDataReader
{
    public class XmlToDTOEducationConverter : IXmlToDTOEducationConverter
    {
        public XmlToDTOEducationConverter(string path)
        {
            this.Path = path;
        }

        public string Path { get; set; }

        public IEnumerable<DTOEducation> GetAllDeveloppersEducations()
        {
            var xmlDocument = XDocument.Load(this.Path);
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
