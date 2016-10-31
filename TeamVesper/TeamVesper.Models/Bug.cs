using System;
using System.ComponentModel.DataAnnotations;

namespace TeamVesper.Models
{
    public class Bug 
    {
        private int id;
        private string description;

        public Bug()
        {

        }

        public Bug(string description)
        {
            this.Description = description;
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

        [Required(ErrorMessage = "Bug description is required")]
        [MinLength(5)]
        [MaxLength(1500)]
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Description");
                }

                if (value.Length < 5 || value.Length > 1500)
                {
                    throw new ArgumentException("Description lenght should be in range 5-1500 symbols!");
                }

                this.description = value;
            }
        }

        // TODO check http://stackoverflow.com/questions/15109726/required-attribute-for-foreign-keys is true!
        public virtual int PriorityId { get; set; }

        public virtual Priority Priority { get; set; }

        public virtual int SpecialityId { get; set; }

        public virtual Speciality Speciality { get; set; }

        public virtual Developer AttachedTo { get; set; }

        public DateTime? solvedOn { get; set; }
    }
}
