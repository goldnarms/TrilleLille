using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using TrilleLille.Web.Models;
using TrilleLille.Web.Models.GroupViewModels;

namespace TrilleLille.Web.Config
{
    public class MapperProfile : Profile
    {
        public MapperProfile(IHostingEnvironment hostingEnvironment)
        {
            CreateMap<CreateGroupViewModel, Group>().ReverseMap();
            CreateMap<Group, GroupListViewModel>()
                .AfterMap(
                    (s, d) =>
                        d.ProfileImageUrl =
                            (hostingEnvironment.WebRootPath + $@"\Uploads\Images\" + s?.Creator?.ProfileImageUrl))
                .AfterMap(
                    (s , d) =>
                        d.CreatorName = s?.Creator?.Name)
                .AfterMap(
                    (s, d) =>
                        d.CreatorEmail = s?.Creator?.Email)
                .AfterMap(
                    (s, d) =>
                        d.CreatorBio = s?.Creator?.Bio)
                .AfterMap(
                    (s, d) =>
                        d.CreatorChild = s?.Child?.Name)
                .AfterMap(
                    (s, d) =>
                        d.City = s?.Location?.Area?.City?.Name)
                .AfterMap(
                    (s, d) =>
                        d.ZipCode = s?.Location?.ZipCode);
        }

    }
}
