using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ListedIN.Models
{
    public class Skill
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Skill is Required")]
        [Display(Name = "Skill")]
        public string Name { get; set; }

        public List<ApplicationUser> User { get; set; }
    }
}