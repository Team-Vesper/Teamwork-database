using System;
using System.ComponentModel.DataAnnotations;

namespace TeamVesper.Models
{
    public class Bug 
    {
        public Bug()
        {

        }

        public Bug(string description)
        {
            this.Description = description;
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Bug description is required")]
        [MinLength(5)]
        [MaxLength(1500)]
        public string Description { get; set; }

        // TODO check http://stackoverflow.com/questions/15109726/required-attribute-for-foreign-keys is true!
        public virtual int PriorityId { get; set; }

        public virtual Priority Priority { get; set; }

        public virtual int SpecialityId { get; set; }

        public virtual Speciality Speciality { get; set; }

        public virtual Developer AttachedTo { get; set; }

        public DateTime? solvedOn { get; set; }
    }
}
