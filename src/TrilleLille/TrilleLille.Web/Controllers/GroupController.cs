using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrilleLille.Web.Models;
using TrilleLille.Web.Models.GroupViewModels;

namespace TrilleLille.Web.Controllers {
    public class GroupController: Controller {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly TrilleLilleContext _trilleLilleContext;
        public GroupController(IMapper mapper, UserManager<ApplicationUser> userManager, TrilleLilleContext trilleLilleContext)
        {
            _mapper = mapper;
            _userManager = userManager;
            _trilleLilleContext = trilleLilleContext;
        }

        public async Task<IActionResult> Index()
        {
            var groups = await _trilleLilleContext.Groups.ToListAsync();
            return View(_mapper.Map<IEnumerable<GroupListViewModel>>(groups));
        }

        [HttpGet]
        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateGroupViewModel viewModel){
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return View("Error");
            }

            var model = _mapper.Map<Group>(viewModel);
            model.CreatorId = user.Id;

            var location = new Location
            {
                ZipCode = 7046,
                Latitude = 10,
                Longitude = 63
            };
            _trilleLilleContext.Locations.Add(location);
            await _trilleLilleContext.SaveChangesAsync();
            model.LocationId = location.Id;
            _trilleLilleContext.Groups.Add(model);
            await _trilleLilleContext.SaveChangesAsync();
            return RedirectToAction("Details", new {id = model.Id});
        }

        public async Task<IActionResult> Details(int id)
        {
            var group = await _trilleLilleContext.Groups.SingleOrDefaultAsync(g => g.Id == id);
            return View(group);
        }

        [Authorize]
        public IActionResult JoinGroup(int id){
            return View();
        }

        [Authorize]
        public IActionResult LeaveGroup(int id){
            return View();
        }

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }

    }
}