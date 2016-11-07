using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamVesper.Models
{
    public class Education
    {
        [Key, ForeignKey("Developer")]
        public int Id { get; set; }

        [MinLength(0)]
        [MaxLength(50)]
        public string HighSchoolName { get; set; }

        [MinLength(0)]
        [MaxLength(50)]
        public string HighSchoolTown { get; set; }

        [MinLength(0)]
        [MaxLength(50)]
        public string UniversityName { get; set; }

        [MinLength(0)]
        [MaxLength(50)]
        public string UniversityTown { get; set; }

        public int UniversityGradeNote { get; set; }

        public virtual Developer Developer { get; set; }
    }
}
