using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeamVesper.Models
{
    public class Developer
    {
        private int id;
        private string userName;
        private string firstName;
        private string lastName;
        private int age;
        private ICollection<Bug> workingOn;

        public Developer()
        {
            workingOn = new HashSet<Bug>();
        }

        public Developer(string userName,
                            string firstName,
                            string lastName,
                            int age)
        {
            this.UserName = userName;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        [Key]
        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Id cannot be negative!");
                }

                this.id = value;
            }
        }

        [Required(ErrorMessage = "UserNmae is required")]
        [MinLength(2)]
        [MaxLength(30)]
        public string UserName
        {
            get
            {
                return this.userName;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("UserName");
                }

                if (value.Length < 2 || 30 < value.Length)
                {
                    throw new ArgumentException("UserName lenght should be in range 2-30 symbols!");
                }

                this.userName = value;
            }
        }

        [Required(ErrorMessage = "Developer first name is required")]
        [MinLength(2)]
        [MaxLength(50)]
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("FirstName");
                }

                if (value.Length < 2 || 50 < value.Length)
                {
                    throw new ArgumentException("FirstName lenght should be in range 2-50 symbols!");
                }

                this.firstName = value;
            }
        }

        [Required(ErrorMessage = "Developer last name is required")]
        [MinLength(2)]
        [MaxLength(50)]
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("LastName");
                }

                if (value.Length < 2 || 50 < value.Length)
                {
                    throw new ArgumentException("LastName lenght should be in range 2-50 symbols!");
                }

                this.lastName = value;
            }
        }

        [Range(18, 100)]
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 18 || 100 < value)
                {
                    throw new ArgumentException("Age should be in range 18-100!");
                }

                this.age = value;
            }
        }

        public bool isTeamLeader { get; set; }

        public virtual int TeamId { get; set; }

        public virtual Team Team { get; set; }

        public virtual int SpecialityId { get; set; }

        public virtual Speciality Speciality { get; set; }

        public virtual ICollection<Bug> WorkingOn { get; set; }
    }
}
