using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TrilleLille.Web.Models;
using TrilleLille.Web.Models.CommonViewModels;

namespace TrilleLille.Web.Services
{
    public interface ISideMenuService
    {
        SideMenuViewModel MapSideMenuViewModel(ClaimsPrincipal principal);
    }
}
