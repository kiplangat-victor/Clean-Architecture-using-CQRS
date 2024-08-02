// namespace CleanArchWithCQRSandMediator.Application.Blogs.Commands.UpdateBlog
// {
//   public sealed class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, int>
//     {
//         private readonly IBlogRepository _blogRepository;
//         private readonly IMapper _mapper;
        
//          public UpdateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper)
//          {
//             _blogRepository=blogRepository;
//             _mapper=mapper;

//          }

//         public async Task<int> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
//         {
//             var update= new Blog()
//             {
//                 Id=request.Id,
//                 Name=request.Name,
//                 Description=request.Description,
//                 Author=request.Author

//             };
//             return await _blogRepository.UpdateAsync(request.Id,update);
            
//         }
//     }
// }