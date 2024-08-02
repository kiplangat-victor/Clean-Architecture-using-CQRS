// using AutoMapper;
// using CleanArchWithCQRSandMediator.Domain;
// using MediatR;

// namespace CleanArchWithCQRSandMediator.Application.Blogs.Commands.DeleteBlog
// {
// public sealed class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, int>
//     {
//         private readonly IBlogRepository _blogRepository;
//         private readonly IMapper _mapper;
//         public DeleteBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper)
//         {
//             _blogRepository = blogRepository;
//             _mapper = mapper;
//         }
    
//         public async Task<int> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
//         {
//             return await _blogRepository.DeleteAsync(request.Id);
//         }
//     }
// }