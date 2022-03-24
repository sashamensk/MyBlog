using Microsoft.EntityFrameworkCore;

namespace MyBlog.Areas.Admin.Models
{
    public class CategoriesDbContext : DbContext
    {
        public CategoriesDbContext(DbContextOptions<CategoriesDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
    }
}
