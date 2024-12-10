using DIPatternDemo_Layered .Models;
using Microsoft .EntityFrameworkCore;

namespace DIPatternDemo_Layered .Data
    {
    public class ApplicationDBContext : DbContext
        {
        //override configuration that we need at app level
        public ApplicationDBContext ( DbContextOptions<ApplicationDBContext> options ) : base(options)

            {
            }
        public DbSet<Employee> Employees { get; set; }
     //   public DbSet<Student> students { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        }
    }
