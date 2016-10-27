using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeamVesper.Models
{
    public class Speciality
    {
        private ICollection<Developer> developers;

        public Speciality()
        {
            this.developers = new HashSet<Developer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Developer> Developers
        {
            get { return this.developers; }
            set { this.developers = value; }
        }
    }
}
