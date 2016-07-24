using System;

namespace TrilleLille.Web.Models
{
    public class Child
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ParentId { get; set; }

        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set;}
        public virtual ApplicationUser Parent { get; set; }
    }
}