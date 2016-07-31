using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TrilleLille.Web.Models;
using TrilleLille.Web.Models.CommonViewModels;

namespace TrilleLille.Web.Services
{
    public class SideMenuService : ISideMenuService
    {
        private readonly IMapper _mapper;
        private readonly TrilleLilleContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public SideMenuService(IMapper mapper, TrilleLilleContext context, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _context = context;
            _userManager = userManager;
        }

        public SideMenuViewModel MapSideMenuViewModel(ClaimsPrincipal principal)
        {
            if (!principal.Identity.IsAuthenticated)
                return null;
            var user = _context.Users.Include(u => u.GroupMembers).ThenInclude(gm => gm.Group).SingleOrDefault(u => u.UserName == principal.Identity.Name);
            return _mapper.Map<SideMenuViewModel>(user);
        }
    }
}
