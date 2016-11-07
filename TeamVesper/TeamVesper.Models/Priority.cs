using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeamVesper.Models
{
    public class Priority
    {
        private string name;
        private ICollection<Bug> bugs;

        public Priority()
        {
            this.bugs = new HashSet<Bug>();
        }

        public Priority(string name)
        {
            this.Name = name;
            this.bugs = new HashSet<Bug>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Name { get; set; }

        public virtual ICollection<Bug> Bugs
        {
            get { return this.bugs; }
            set { this.bugs = value; }
        }
    }
}
