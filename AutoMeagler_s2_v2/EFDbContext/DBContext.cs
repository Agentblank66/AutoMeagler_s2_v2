using AutoMeagler_s2_v2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AutoMeagler_s2_v2.EFDbContext
{
    public class DBContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Image> Image { get; set; }

    }
}
