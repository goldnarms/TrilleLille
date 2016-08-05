using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrilleLille.Web.Models.AccountViewModels
{
    public class RegisterProfileViewModel
    {
        public ParentType ParentType { get; set; }
        public string Bio { get; set; }
        public DateTime BirthDate { get; set; }

    }
}
