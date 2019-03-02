using ListedIN.Models;
using System.Collections.Generic;

namespace ListedIN.ViewModels
{
    public class ProfileViewModel
    {

        public ApplicationUser User { get; set; }
        public List<Education> Educations { get; set; }
        public List<Skill> Skills { get; set; }

        public Education Education { get; set; }
    }
}