using System.Reflection;
using Core.Entities.Concrete;
using Entities.Concrate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Concrate.EntityFramework.Context
{
    public class EmpCalcContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true);

                var configuration = builder.Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");

                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException($"Connection string 'DefaultConnection' missing for {environment}!");
                }

                // var connectionString = "Host=dpg-cvp4ovi4d50c73bo6b5g-a.frankfurt-postgres.render.com;Port=5432;Database=em_calc;Username=em_calc_user;Password=prblHBrewIbigSY3s14TfvX1vjoVRxcB;SslMode=Require;Trust Server Certificate=true";

                optionsBuilder.UseNpgsql(connectionString);
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<IsoftAccount> IsoftAccounts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<SalaryHead> SalaryHeads { get; set; }
        public DbSet<SalaryLine> SalaryLines { get; set; }
    }
}
