using AutoMeagler_s2_v2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AutoMeagler_s2_v2.EFDbContext
{
    public class UserDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        
        public UserDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// A method which is used to configure the database context.
        /// </summary>
        /// <param name="options"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        /// <summary>
        /// Properties of the UserDbContext class.
        /// </summary>
       
    }
}
