using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

namespace TrilleLille.Web.Models.GroupViewModels
{
    public class GroupListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ZipCode { get;set;}
        public string City { get; set; }
        public string AgeRange { get; set; }
        public ParentType SeekingParentType {get;set;}
        public string CreatorName { get; set; }
        public string CreatorBio {get;set;}
        public string CreatorEmail { get; set; }
        public string ProfileImageUrl { get; set; }
        public string CreatorChild { get; set; }
        public string GroupIntro {get;set;}
        public string CreatorId {get;set;}
        
    }
}
