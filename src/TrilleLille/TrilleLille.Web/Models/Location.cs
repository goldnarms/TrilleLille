using Microsoft.AspNetCore.Mvc;
using Models;

namespace TrilleLille.Web.Models
{
    public class Location
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string ZipCode { get; set; }

        public int AreaId { get; set; }

        public virtual Area Area { get; set; }
    }
}