using ListedIN.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ListedIN.Models
{
    public class Member
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public string HeadLine { get; set; }
        public string Position { get; set; }
        public Country Country { get; set; }
        public string Summary { get; set; }
    }
}