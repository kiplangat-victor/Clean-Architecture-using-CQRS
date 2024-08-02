using FluentValidation;

namespace CleanArchWithCQRSandMediator.Application.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandValidator : AbstractValidator<CreateBlogCommand>
    {
        public CreateBlogCommandValidator()
        {
            RuleFor(c=>c.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(200).WithMessage("Name must not exceed 200 characters");
            RuleFor(c=>c.Description)
            .NotEmpty().WithMessage("Description is required");

            RuleFor(c=>c.Author)
            .NotEmpty().WithMessage("Author is required")
            .MaximumLength(20).WithMessage("Author must not exceed 20 characters");

        }
        
    }
}