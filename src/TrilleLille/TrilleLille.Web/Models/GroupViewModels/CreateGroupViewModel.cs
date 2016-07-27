using System.ComponentModel.DataAnnotations;
using Models;

namespace TrilleLille.Web.Models.GroupViewModels
{
    public class CreateGroupViewModel
    {
        [Display(Name = "Gruppens navn")]
        public string Name { get; set; }

        public int LocationId { get; set; }

        [Display(Name = "En kort beskrivelse om gruppen")]
        public string GroupIntro { get; set; }
        public string CreatorId { get; set; }

        [Display(Name = "Ditt navn")]
        public string CreatorName { get; set; }

        [Display(Name = "Fortell oss litt om deg selv")]
        public string CreatorBio { get; set; }
        
        public Gender CreatorGender { get; set; }

        public string CreatorEmail { get; set; }
        public string ProfileImageUrl { get; set; }
        public int AgeGroupId { get; set; }

        public Gender SeekingGender { get; set; }

        public string ChildName { get; set; }
        public AgeGroup AgeGroup { get; set; }
    }
}