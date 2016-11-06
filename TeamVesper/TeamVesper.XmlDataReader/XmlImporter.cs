using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Collections.Generic;

using TeamVesper.Models;
using System;
using TeamVesper.Repositories.Contracts;
using System.Linq.Expressions;
using System.Linq;

namespace TeamVesper.XmlDataReader
{
    public class XmlImporter : IReadableRepository<DTOEducation>
        
    {
        private string filePath;

        public XmlImporter(string filePath)
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

                this.filePath = value;
            }
        }

        public IEnumerable<DTOEducation> All()
        {
            return this.GetAllDeveloppersEducations();
        }

        public IEnumerable<DTOEducation> All(Expression<Func<DTOEducation, bool>> predicate)
        {
            var func = predicate.Compile();

            return this.All().Where(func).ToList();
        }

        private IEnumerable<DTOEducation> GetAllDeveloppersEducations()
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
