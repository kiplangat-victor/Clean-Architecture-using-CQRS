using CleanArchWithCQRSandMediator.Application.Common.Mappings;
using CleanArchWithCQRSandMediator.Domain;

namespace CleanArchWithCQRSandMediator.Application.Blogs.Queries.GetBlogs
{
public class BlogVm : IMapFrom<Blog>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string  Description { get; set; }
    public string Author { get; set; }

}
}