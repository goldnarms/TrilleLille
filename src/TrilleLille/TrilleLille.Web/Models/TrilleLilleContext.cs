using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;
using TrilleLille.Web.Models.GroupViewModels;

namespace TrilleLille.Web.Models
{
    public class TrilleLilleContext : IdentityDbContext<ApplicationUser>
    {
        public TrilleLilleContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<AgeGroup> AgeGroups { get; set; }
        public DbSet<GroupListViewModel> GroupListViewModel { get; set; }
    }
}
