using System;
using System.ComponentModel.DataAnnotations;

namespace TeamVesper.Models
{
    public class Bug
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Bug description is required")]
        [MinLength(5)]
        [MaxLength(1500)]
        public string Description { get; set; }

        public virtual Developer AttachedTo { get; set; }

        public DateTime? solvedOn { get; set; }
    }
}
