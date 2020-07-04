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
                    Id = 1,
                    Name = "Mikhail", 
                    Surname = "Vikhrov"
                };
                
                var user2 = new User
                {
                    Id = 2,
                    Name = "Matvey",
                    Surname = "Smirnov"
                };

                var message1 = new Message
                {
                    Id = 1,
                    Text = "12345"
                };

                var message2 = new Message
                {
                    Id = 2,
                    Text = "67890"
                };
               
                db.Messages.AddRange(message1, message2);
                db.Users.AddRange(user1, user2);
                db.SaveChanges();

                var users = db.Users.ToList();
                var messages = db.Messages.ToList();
                
                foreach (var u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} {u.Surname} : ");
                }

                foreach (var m in messages)
                {
                    Console.WriteLine($"{m.Id} : {m.Text}");
                }

            }

            Console.ReadKey();
        }
    }
}
