using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrilleLille.Web.Models.AccountViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name="E-post")]
        public string Email { get; set; }

        [Display(Name="Fødselsdato")]
        public DateTime BirthDate { get; set; }

        [Display(Name="Jeg er ")]
        public string Parent { get; set; }

        [Display(Name="Navn")]
        public string Name { get; set; }

    }
}
