using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrilleLille.Web.Models.CommonViewModels
{
    public class SideMenuViewModel
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Dictionary<int, string> Groups { get; set; }
        public string UserProfileUrl { get; set; }
    }
}
