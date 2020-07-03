using System;
using System.IO;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Database
{
    public sealed class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) 
            :base(options)
        {
            Database.EnsureCreated();
        }
    }
    
    internal class Program
    {
        private static void Main()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = builder.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder.UseSqlServer(connectionString).Options;
            using (var db = new ApplicationContext(options))
            {
                var user1 = new User { 
                    Name = "Mikhail", 
                    Surname = "Vikhrov"
                };
                
                var user2 = new User
                {
                    Name = "Matvey",
                    Surname = "Smirnov"
                };
                
                var users = db.Users.ToList();
                foreach (var u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} {u.Surname}");
                }
            }
            Console.ReadKey();
        }
    }
}
