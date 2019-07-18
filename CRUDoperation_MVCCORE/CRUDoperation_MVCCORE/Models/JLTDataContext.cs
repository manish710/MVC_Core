using Microsoft.EntityFrameworkCore;
using CRUDoperation_MVCCORE.Models;

namespace CRUDoperation_MVCCORE.Models
{
    public class JLTDataContext : DbContext
    {
        public JLTDataContext(DbContextOptions<JLTDataContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employee { get; set; }
    }
}
