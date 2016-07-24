using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TrilleLille.Web.Models;
using TrilleLille.Web.Models.GroupViewModels;

namespace TrilleLille.Web.Config
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateGroupViewModel, Group>().ReverseMap();
            CreateMap<GroupListViewModel, Group>().ReverseMap();
        }

    }
}
