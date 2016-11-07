using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeamVesper.Models
{
    public class Team
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
        public string Name { get; set; }

        public virtual ICollection<Developer> Developers
        {
            get { return this.developers; }
            set { this.developers = value; }
        }
    }
}
