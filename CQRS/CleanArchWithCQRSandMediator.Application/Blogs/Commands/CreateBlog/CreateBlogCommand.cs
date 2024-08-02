using AutoMapper;
using CleanArchWithCQRSandMediator.Application.Blogs.Queries.GetBlogs;
using CleanArchWithCQRSandMediator.Domain;
using MediatR;

namespace CleanArchWithCQRSandMediator.Application
{
    public class CreateBlogCommand : IRequest<BlogVm>
    {
    public string Name { get; set; }
    public string  Description { get; set; }
    public string Author { get; set; }
        

    }
    public sealed class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, BlogVm>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        public CreateBlogCommandHandler(IBlogRepository blogRepository,IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
    
        public async Task<BlogVm> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var blogEntity= new Blog(){
                Name=request.Name,
                Description=request.Description,
                Author=request.Author,
            };
            var create=await _blogRepository.CreateAsync(blogEntity);
            return _mapper.Map<BlogVm>(create);

        }
    }
}