using ListedIN.Models;
using System.Collections.Generic;

namespace ListedIN.ViewModels
{
    public class ProfileViewModel
    {

        public ApplicationUser User { get; set; }
        public IList<Education> Educations { get; set; }    
    }
}