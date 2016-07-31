using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrilleLille.Web.Models.GroupViewModels
{
    public class GroupDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LocationCity { get; set; }
        public string LocationArea { get; set; }
        public string GroupIntro { get; set; }
        public string CreatorName { get; set; }
        public string CreatorProfileImageUrl { get; set; }
        public string CreatorBio { get; set; }
        public string CreatorEmail { get; set; }
        public DateTime FirstMeeting { get; set; }
        public ParentType SeekingParentType { get; set; }
        public AgeGroup AgeGroup { get; set; }
        public bool IsMember { get; set; }
        public bool IsAdmin { get; set; }
    }
}
