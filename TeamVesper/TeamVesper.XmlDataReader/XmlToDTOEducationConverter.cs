using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Collections.Generic;

using TeamVesper.XmlDataReader.Contracts;
using TeamVesper.Models;
using System;
using TeamVesper.Repositories.Contracts;
using System.Linq.Expressions;
using System.Linq;

namespace TeamVesper.XmlDataReader
{
    public class XmlToDTOEducationConverter<TEntity> : IReadableRepository<TEntity>
        where TEntity : DTOEducation
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

        public IEnumerable<TEntity> All()
        {
            return this.GetAllDeveloppersEducations();
        }

        public IEnumerable<TEntity> All(Expression<Func<TEntity, bool>> predicate)
        {
            var func = predicate.Compile();

            return this.All().Where(func).ToList();
        }

        private IEnumerable<TEntity> GetAllDeveloppersEducations()
        {
            var xmlDocument = XDocument.Load(this.FilePath);
            var xmlFormatEducations = xmlDocument.Descendants("developperEducation");
            var pocoEducations = new List<TEntity>();

            foreach (var education in xmlFormatEducations)
            {
                var stringReader = new StringReader(education.ToString());
                var xmlSerializer = new XmlSerializer(typeof(TEntity));
                var current = (TEntity)xmlSerializer.Deserialize(stringReader);

                pocoEducations.Add(current);
            }

            return pocoEducations;
        }
    }
}
