using System;
using System.IO;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Database
{
    
    
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
                    FirstName = "Mikhail", 
                    LastName = "Vikhrov"
                };
                
                var user2 = new User
                {
                    FirstName = "Matvey",
                    LastName = "Smirnov"
                };

                db.Users.AddRange(user1, user2);
                db.SaveChanges();

                var users = db.Users.ToList();
                
                foreach (var u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} : ");
                }

            }

            Console.ReadKey();
        }
    }
}
