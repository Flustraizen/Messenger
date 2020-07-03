using System;
using System.Linq;

namespace Database
{
    public class ApplicationContext : DbContext
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
        private static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                
            }
        }
    }
}
