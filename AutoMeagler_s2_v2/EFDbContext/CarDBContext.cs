using AutoMeagler_s2_v2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AutoMeagler_s2_v2.EFDbContext
{
    public class CarDBContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public CarDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Car> Cars { get; set; }
    }
}
