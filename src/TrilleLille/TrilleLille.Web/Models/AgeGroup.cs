using System.ComponentModel.DataAnnotations.Schema;

namespace TrilleLille.Web.Models
{
    public class AgeGroup
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Range { get; set; }
    }
}