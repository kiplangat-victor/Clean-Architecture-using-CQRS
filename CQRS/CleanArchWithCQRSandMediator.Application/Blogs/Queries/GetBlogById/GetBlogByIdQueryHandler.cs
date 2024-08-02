using AutoMapper;
using CleanArchWithCQRSandMediator.Application.Blogs.Queries.GetBlogs;
using CleanArchWithCQRSandMediator.Domain;
using MediatR;

namespace CleanArchWithCQRSandMediator.Application.Blogs.Queries.GetBlogById
{
//    public sealed class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, BlogVm>
//     {
//         public readonly IBlogRepository _blogRepository;
//         public readonly IMapper _mapper;
//         public GetBlogByIdQueryHandler(IBlogRepository blogRepository, IMapper mapper)
//         {
//             _blogRepository = blogRepository;
//             _mapper = mapper;

//         }

//         public async Task<BlogVm> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
//         {
//             var blog= await _blogRepository.GetByIdAsync(request.BlogId);
//             return _mapper.Map<BlogVm>(blog);
//         }
//     }
}