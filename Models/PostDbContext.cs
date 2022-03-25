using Microsoft.EntityFrameworkCore;

namespace MyBlog.Models
{
    public class PostDbContext : DbContext
    {
        public PostDbContext(DbContextOptions<PostDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Post> Post { get; set; }
    }
}
