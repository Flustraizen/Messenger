using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public sealed class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-S9G1N32\\SQLEXPRESS;" +
                                        "Database=messengerdb;" +
                                        "Trusted_Connection=True;");
        }
    }
    
    internal class Program
    {
        private static void Main()
        {
            using (var db = new ApplicationContext())
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
                
                db.Users.Add(user1);
                db.Users.Add(user2);
                db.SaveChanges();

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
