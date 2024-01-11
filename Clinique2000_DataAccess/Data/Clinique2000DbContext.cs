using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinique2000_Models.Models;
using Microsoft.AspNetCore.Identity;

namespace Clinique2000_DataAccess.Data
{
    public class Clinique2000DbContext : IdentityDbContext
    {




        public Clinique2000DbContext(DbContextOptions<Clinique2000DbContext> options) : base(options)
        {




        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().HasNoDiscriminator();

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
    }    

}
