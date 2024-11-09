using Microsoft.EntityFrameworkCore;
using SKbooks.Models;
using SKbooksAPI.Models;

namespace SKbooks.Data
{
    public class ApplicationDBcontext  : DbContext
    {
        public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options) : base(options)
        {

        }

       public DbSet<Customer> Customers { get; set; } 
       public DbSet<category> Categories { get; set; }

     //  public DbSet<Product> products { get; set; }
        public DbSet<Language> languages { get; set; }
        public DbSet<MainProducts> mainProducts { get; set; }



    }
}
