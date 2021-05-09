using Microsoft.EntityFrameworkCore;
using Provision.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Provision.Data
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=ProvisionDB;User Id=postgres; Password=7648154Ae.;");
        }
        public DbSet<Currency> Currencies { get; set; }
    }
}
