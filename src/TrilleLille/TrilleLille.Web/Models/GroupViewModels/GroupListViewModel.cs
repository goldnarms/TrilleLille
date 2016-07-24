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
    }
}
