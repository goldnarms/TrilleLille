using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Models;
using TrilleLille.Web.Models;
using TrilleLille.Web.Models.GroupViewModels;

namespace TrilleLille.Web.Controllers {
    public class GroupController: Controller {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly TrilleLilleContext _trilleLilleContext;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public GroupController(IHostingEnvironment hostingEnvironment, IMapper mapper, UserManager<ApplicationUser> userManager, TrilleLilleContext trilleLilleContext, SignInManager<ApplicationUser> signInManager)
        {
            _hostingEnvironment = hostingEnvironment;
            _mapper = mapper;
            _userManager = userManager;
            _trilleLilleContext = trilleLilleContext;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            var groups = await _trilleLilleContext.Groups
                .Include(g => g.Creator)
                .Include(g => g.Child)
                .Include(g => g.Location).ThenInclude(l => l.Area).ThenInclude(a => a.City)
                .ToListAsync();
            var viewModels = _mapper.Map<IEnumerable<GroupListViewModel>>(groups);
            return View(viewModels);
        }

        [HttpGet]
        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGroupViewModel viewModel, IFormFile profileImage)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var user = await GetCurrentUserAsync();
            var child = new Child {Name = viewModel.ChildName};
            if (user == null)
            {
                var imageName = "";
                if (profileImage != null && profileImage.Length > 0)
                {
                    var parsedContentDisposition = ContentDispositionHeaderValue.Parse(profileImage.ContentDisposition);
                    var path = parsedContentDisposition.FileName.Trim('"');
                    var extension = Path.GetExtension(path);
                    var uploadDir = _hostingEnvironment.WebRootPath + $@"\Uploads\Images\";
                    imageName = Guid.NewGuid() + extension;
                    var imageUrl = uploadDir + imageName;
                    using (var stream = new FileStream(imageUrl, FileMode.CreateNew))
                    {
                        await profileImage.CopyToAsync(stream);
                    }
                }
                user = new ApplicationUser
                {
                    UserName = viewModel.CreatorEmail,
                    Email = viewModel.CreatorEmail,
                    Bio = viewModel.CreatorBio,
                    Name = viewModel.CreatorName,
                    ProfileImageUrl = imageName,
                    Children = new List<Child> { child },
                    ParentType = (ParentType) Enum.ToObject(typeof(ParentType), viewModel.ParentTypeId),
                };
                var result = await _userManager.CreateAsync(user, viewModel.Password);
                if (result.Succeeded)
                {
                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=532713
                    // Send an email with this link
                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                    //await _emailSender.SendEmailAsync(model.Email, "Confirm your account",
                    //    $"Please confirm your account by clicking this link: <a href='{callbackUrl}'>link</a>");
                    await _signInManager.SignInAsync(user, isPersistent: false);
                }
                else
                {
                    ModelState.AddModelError("UserFailed", "Kunne ikke opprette din bruker: " + result.Errors);
                    return View(viewModel);
                }
            }
            var city = new City
            {
                Name = "Trondheim"
            };

            var area = new Area
            {
                City = city,
                Name = "Brøset"
            };
            var location = new Location
            {
                ZipCode = viewModel.ZipCode,
                Area = area
            };

            var model = new Group
            {
                Creator = user,
                Name = viewModel.Name,
                GroupIntro = viewModel.GroupIntro,
                Location = location,
                Child = child
            };

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