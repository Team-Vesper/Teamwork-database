using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TeamVesper.Models.Contracts;

namespace TeamVesper.Models
{
    public class Speciality : IEntity
    {
        private string name;
        private ICollection<Developer> developers;

        public Speciality()
        {
            this.developers = new HashSet<Developer>();
        }

        public Speciality(string name)
        {
            this.Name = name;
            this.developers = new HashSet<Developer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Speciality name");
                }

                if (value.Length < 2 || 50 < value.Length)
                {
                    throw new ArgumentException("Speciality name lenght should be in range 2-50 symbols!");
                }
            }
        }

        public virtual ICollection<Developer> Developers
        {
            get { return this.developers; }
            set { this.developers = value; }
        }
    }
}
