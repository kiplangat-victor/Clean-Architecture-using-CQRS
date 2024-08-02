using CleanArchWithCQRSandMediator.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArchWithCQRSandMediator.Infra

{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options): base(options)
        {
            
        }
        public DbSet<Blog> Blogs { get; set; }  

    }
}