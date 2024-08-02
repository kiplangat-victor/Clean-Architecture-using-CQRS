using AutoMapper;
using CleanArchWithCQRSandMediator.Domain;
using MediatR;

namespace CleanArchWithCQRSandMediator.Application.Blogs.Queries.GetBlogs
{
    // public class GetBlogQuery : IRequest<List<BlogVm>>
    // {

    // }
    //TODO: 
    //this is the latest way to create a query class
     public record GetBlogQuery :IRequest<List<BlogVm>>;

    public sealed class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<BlogVm>>
        {
            public readonly IBlogRepository _blogRepository;
            private readonly IMapper _mapper;
            public GetBlogQueryHandler(IBlogRepository blogRepository, IMapper mapper)
            {
                _mapper = mapper;
                _blogRepository = blogRepository;
            }

            public async Task<List<BlogVm>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
            {
                var blogs=await _blogRepository.GetAllAsync();
                // var blogsresult=blogs.Select(b=> new BlogVm{
                //     Id=b.Id,
                //     Name=b.Name,
                //     Description= b.Description,
                //     Author=b.Author

                // }).ToList();
                var blogsresult= _mapper.Map<List<BlogVm>>(blogs);
                return blogsresult;


            }

        }
}