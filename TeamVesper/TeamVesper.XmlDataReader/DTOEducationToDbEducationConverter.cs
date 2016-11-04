using System.Collections.Generic;
using TeamVesper.Models;

namespace TeamVesper.XmlDataReader
{
    // TODO move this where is needed. Its mapper!

    public class DTOEducationToDbEducationConverter
    {
        public DTOEducationToDbEducationConverter(IEnumerable<DTOEducation> collection)
        {
            this.Collection = collection;
        }

        internal IEnumerable<DTOEducation> Collection { get; set; }

        public IEnumerable<Education> GetAllEducations()
        {
            var dtoEducations = this.Collection;
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
