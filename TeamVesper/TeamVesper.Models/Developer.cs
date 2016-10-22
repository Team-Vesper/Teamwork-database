using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeamVesper.Models
{
    public class Developer
    {
        private ICollection<Bug> workingOn;

        public Developer()
        {
            workingOn = new HashSet<Bug>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Developer first name is required")]
        [MinLength(2)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Developer last name is required")]
        [MinLength(2)]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Range(18, 100)]
        public int Age { get; set; }

        [Range(0, int.MaxValue)]
        public int Salary { get; set; }

        public bool TeamLeader { get; set; }

        public virtual int TeamId { get; set; }

        public virtual ICollection<Bug> WorkingOn { get; set; }
    }
}
