using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrilleLille.Web.Models.AccountViewModels
{
    public class InfoViewModel
    {
        [Display(Name = "Fødselsdato")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Jeg er ")]
        public string Parent { get; set; }

        [Display(Name = "Navn")]
        public string Name { get; set; }

    }
}
