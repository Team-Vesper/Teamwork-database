using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TeamVesper.Models.Contracts;

namespace TeamVesper.Models
{
    public class Team : IEntity
    {
        private string name;
        private ICollection<Developer> developers;

        public Team()
        {
            this.developers = new HashSet<Developer>();
        }

        public Team(string name)
        {
            this.Name = name;
            this.developers = new HashSet<Developer>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Team name is required")]
        [MinLength(1)]
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
                    throw new ArgumentNullException("Team name");
                }

                if (value.Length < 1 || 50 < value.Length)
                {
                    throw new ArgumentException("Team name lenght should be in range 1-50 symbols!");
                }

                this.name = value;
            }
        }

        public virtual ICollection<Developer> Developers
        {
            get { return this.developers; }
            set { this.developers = value; }
        }
    }
}
