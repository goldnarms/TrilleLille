using System.Runtime.InteropServices;
using TrilleLille.Web.Models;

namespace Models
{
    public class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
    }
}