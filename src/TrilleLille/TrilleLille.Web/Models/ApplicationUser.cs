using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TrilleLille.Web.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public ParentType ParentType { get; set; }
        public string Bio { get; set; }
        public DateTime BirthDate { get; set; }
        public string ProfileImageUrl { get; set; }
        public virtual ICollection<Child> Children { get; set; }

        public virtual ICollection<GroupMember> GroupMembers { get; set; }

    }
}
