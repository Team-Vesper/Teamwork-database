using System.Collections.Generic;

using TeamVesper.SqlServerData;
using TeamVesper.Models;
using TeamVesper.XmlDataReader.Contracts;

namespace TeamVesper.XmlDataReader
{
    public class DTOEducationToDbEducationConverter
    {
        public DTOEducationToDbEducationConverter(IXmlToDTOEducationConverter dtoModels, SqlServerDbContext dbContext)
        {
            this.DtoModels = dtoModels;
            this.DbContext = dbContext;
        }

        internal IXmlToDTOEducationConverter DtoModels { get; set; }

        internal SqlServerDbContext DbContext { get; set; }

        public IEnumerable<Education> GetAllEducations()
        {
            var dtoEducations = this.DtoModels.GetAllDeveloppersEducations();
            var resultEducations = new HashSet<Education>();

            foreach (var dtoEducation in dtoEducations)
            {
                var educationToBeAdded = new Education()
                {
                    Id = dtoEducation.Id,
                    HighSchoolName = dtoEducation.HighSchoolName,
                    HighSchoolTown = dtoEducation.HighSchoolTown,
                    UniversityName = dtoEducation.UniversityName,
                    UniversityTown = dtoEducation.UniversityTown,
                    UniversityGradeNote = dtoEducation.UniversityGradeNote
                };

                resultEducations.Add(educationToBeAdded);
            }

            return resultEducations;
        }
    }
}
