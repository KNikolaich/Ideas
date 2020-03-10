using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication.Models.Game
{
    public class ContextGame : DbContext
    {
        public ContextGame() : base("DefaultConnection")
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<IdentityRole> IdentityRoles { get; set; }

        public DbSet<GameEntry> GamesEntries { get; set; }
        public DbSet<Walker> Walkers { get; set; }
        public DbSet<PointMap> PointMaps { get; set; }
    }
}