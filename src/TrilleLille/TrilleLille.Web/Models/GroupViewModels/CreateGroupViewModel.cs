using Models;

namespace TrilleLille.Web.Models.GroupViewModels
{
    public class CreateGroupViewModel
    {
        public string Name { get; set; }

        public int LocationId { get; set; }

        public string GroupIntro { get; set; }
        public string CreatorId { get; set; }

        public string CreatorName { get; set; }

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