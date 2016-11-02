using System.Xml.Serialization;

namespace TeamVesper.Models
{
    [XmlRoot(ElementName = "developperEducation")]
    public class DTOEducation
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("highSchoolName")]
        public string HighSchoolName { get; set; }

        [XmlAttribute("highSchoolTown")]
        public string HighSchoolTown { get; set; }

        [XmlAttribute("univerisityName")]
        public string UniversityName { get; set; }

        [XmlAttribute("univerisityTown")]
        public string UniversityTown { get; set; }

        [XmlAttribute("universityGradeNote")]
        public int UniversityGradeNote { get; set; }
    }
}
