using Microsoft.EntityFrameworkCore;
using bulkAction.Models;
namespace bulkAction.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Product> products { get; set; }
        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options) : base(options)
        {

        }
    }
}
