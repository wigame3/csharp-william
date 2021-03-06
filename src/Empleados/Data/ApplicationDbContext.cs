using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Empleados.Models;
using Empleados.Models.SubAreasViewModels;

namespace Empleados.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public virtual DbSet<Empleados.Models.EmpleadosViewModels.Empleado> Empleado { get; set; }

        public virtual DbSet<Empleados.Models.AreasViewModels.Areas> Areas { get; set; }

        public virtual DbSet<Empleados.Models.SubAreasViewModels.SubAreas> SubAreas { get; set; }

        public DbSet<SubArea> SubArea { get; set; }
    }
}
