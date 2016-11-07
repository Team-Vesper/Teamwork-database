using System.Collections.Generic;
using TeamVesper.Models;

namespace TeamVesper.Mappers
{
    public class DTOEducationToDbEducationMapper
    {
        public DTOEducationToDbEducationMapper()
        {
            
        }


        public IEnumerable<Education> GetAllEducations(IEnumerable<DTOEducation> collection)
        {
            var dtoEducations = collection;
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
