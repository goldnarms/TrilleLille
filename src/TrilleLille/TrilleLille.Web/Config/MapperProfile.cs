using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using TrilleLille.Web.Extensions;
using TrilleLille.Web.Models;
using TrilleLille.Web.Models.CommonViewModels;
using TrilleLille.Web.Models.GroupViewModels;

namespace TrilleLille.Web.Config
{
    public class MapperProfile : Profile
    {
        public MapperProfile(IHostingEnvironment hostingEnvironment)
        {
            CreateMap<CreateGroupViewModel, Group>().ReverseMap();
            CreateMap<Group, GroupListViewModel>()
                .AfterMap((s, d) => d.ProfileImageUrl =
                            (hostingEnvironment.WebRootPath + $@"\Uploads\Images\" + string.Format(s?.Creator?.ProfileImageUrl, "_small")))
                .AfterMap((s , d) => d.CreatorName = s?.Creator?.Name)
                .AfterMap((s, d) => d.CreatorEmail = s?.Creator?.Email)
                .AfterMap((s, d) => d.CreatorBio = s?.Creator?.Bio)
                .AfterMap((s, d) => d.CreatorChild = s?.Child?.Name)
                .AfterMap((s, d) => d.City = s?.Location?.Area?.City?.Name)
                .AfterMap((s, d) => d.ZipCode = s?.Location?.ZipCode);

            CreateMap<Group, GroupDetailsViewModel>()
                .AfterMap((s, d) => d.LocationCity = s?.Location?.Area?.City?.Name)
                .AfterMap((s, d) => d.LocationArea = s?.Location?.Area?.Name)
                .AfterMap((s, d) => d.CreatorBio = s?.Creator?.Bio)
                .AfterMap((s, d) => d.CreatorEmail = s?.Creator?.Email)
                .AfterMap((s, d) => d.CreatorName = s?.Creator?.Name)
                .AfterMap((s, d) => d.CreatorProfileImageUrl =
                    (hostingEnvironment.WebRootPath + $@"\Uploads\Images\" +
                     string.Format(s?.Creator?.ProfileImageUrl, "_small")));

            CreateMap<ApplicationUser, SideMenuViewModel>()
                .AfterMap((s, d) => d.Groups = s?.GroupMembers
                    .DistinctBy(gm => gm.GroupId)
                    .Select(gm => new KeyValuePair<int, string>(gm.GroupId, gm.Group?.Name))
                    .ToDictionary(kvm => kvm.Key, kvm => kvm.Value))
                .AfterMap((s, d) => d.UserId = s.Id)
                .AfterMap((s, d) => d.UserProfileUrl =
                            (hostingEnvironment.WebRootPath + $@"\Uploads\Images\" +
                             string.Format(s?.ProfileImageUrl, "_small")));
        }

    }
}
