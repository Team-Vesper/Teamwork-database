using System;
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

        public Developer(string userName,
                            string firstName,
                            string lastName,
                            int age)
            : this()
        {
            this.UserName = userName;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "UserNmae is required")]
        [MinLength(2)]
        [MaxLength(30)]
        public string UserName { get; set; }

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

        public bool isTeamLeader { get; set; }

        public virtual int TeamId { get; set; }

        public virtual Team Team { get; set; }

        public virtual int SpecialityId { get; set; }
        
        public virtual Speciality Speciality { get; set; }

        public virtual ICollection<Bug> WorkingOn
        {
            get { return this.workingOn; }
            set { this.workingOn = value; }
        }
    }
}
