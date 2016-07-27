using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrilleLille.Web.Models
{
    public class Group
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string GroupIntro { get; set; }
        public int LocationId { get; set; }

        public string CreatorId { get; set; }

        public int AgeGroupId { get; set; }

        public Gender SeekingGender { get; set; }

        public virtual Location Location { get; set; }

        public virtual ApplicationUser Creator { get; set; }
        public AgeGroup AgeGroup { get; set; }

    }
}
