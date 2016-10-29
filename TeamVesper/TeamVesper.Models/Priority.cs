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
                    throw new ArgumentNullException("Priority name!");
                }

                if (value.Length < 2 || 30 < value.Length)
                {
                    throw new ArgumentException("Priority name lenght should be in range 2-30 symbols!");
                }

                this.name = value;
            }
        }

        public virtual ICollection<Bug> Bugs
        {
            get { return this.bugs; }
            set { this.bugs = value; }
        }
    }
}
