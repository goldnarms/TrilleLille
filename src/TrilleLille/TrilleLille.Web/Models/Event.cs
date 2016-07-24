using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrilleLille.Web.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public int ActivityId { get; set; }
        public int GroupId { get; set; }
        public string UserId { get; set; }
        public virtual Activity Activity { get; set; }
        public virtual ApplicationUser Creator { get; set; }
        public virtual Group Group { get; set; }
    }
}
