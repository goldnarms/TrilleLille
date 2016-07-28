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

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public int LocationId { get; set; }

        public string CreatorId { get; set; }

        public int ChildId { get; set; }

        public virtual Location Location { get; set; }

        public virtual ApplicationUser Creator { get; set; }

        public virtual Child Child { get; set; }
    }
}
