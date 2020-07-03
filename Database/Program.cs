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
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;" +
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
                
                db.Users.Add(user1);
                db.Users.Add(user2);
                db.SaveChanges();

                var users = db.Users.ToList();
                foreach (var u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} {u.Surname}");
                }
            }
            Console.WriteLine();
        }
    }
}
