using CleanArchWithCQRSandMediator.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArchWithCQRSandMediator.Infra

{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDbContext _context;
        public BlogRepository(BlogDbContext context)
        {
            _context=context;
        }
        public async Task<Blog> CreateAsync(Blog blog)
        {
            await _context.Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();
            return blog;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _context.Blogs
            .Where(x=>x.Id == id)
            .ExecuteDeleteAsync();
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            return await _context.Blogs.ToListAsync();
        }

        public async Task<Blog?> GetByIdAsync(int id)
        {
            return await _context.Blogs.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> UpdateAsync(int id, Blog blog)
        {
           return await _context.Blogs
           .Where(c=>c.Id == id)
           .ExecuteUpdateAsync(setters=>setters
           .SetProperty(x=>x.Id,blog.Id)
           .SetProperty(x=>x.Name,blog.Name)
           .SetProperty(x=>x.Description,blog.Description)
           .SetProperty(x=>x.Author,blog.Author)
           );
        }
    }
}
