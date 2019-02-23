using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ListedIN.Models
{
    public class Education
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Degree { get; set; }

        [Display(Name = "Field of Study")]
        public string Field { get; set; }

        public string Grade { get; set; }

        [Display(Name = "From Year")]
        [Range(1900, 2019)]
        public short? FromYear { get; set; }


        [Display(Name = "To Year")]
        [Range(1900, 2019)]
        public short? ToYear { get; set; }

        public string Description { get; set; }

        public ApplicationUser User { get; set; }

        [ForeignKey("User")]
        public string fk_User { get; set; }
    }
}