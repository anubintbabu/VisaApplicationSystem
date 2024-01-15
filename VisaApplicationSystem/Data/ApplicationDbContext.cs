using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using VisaApplicationSystem.Models;

namespace VisaApplicationSystem.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<UserProfiles> UserProfiles { get; set; }

        public virtual DbSet<VisaApplications> VisaApplications { get; set; }

        public virtual DbSet<VisaTypes> VisaTypes { get; set; }

    }
}
