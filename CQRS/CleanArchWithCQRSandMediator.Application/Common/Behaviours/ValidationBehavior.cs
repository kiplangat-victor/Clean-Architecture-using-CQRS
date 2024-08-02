using System.ComponentModel.DataAnnotations;
using FluentValidation;
using MediatR;

namespace CleanArchWithCQRSandMediator.Application

{
    internal class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators= validators;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(_validators.Any())
            {
                var context= new ValidationContext<TRequest> (request);
                var validationResult= await Task.WhenAll(_validators.Select(x => x.ValidateAsync(context,cancellationToken)));

                var failures=validationResult.Where(x => x.Errors.Any()).SelectMany(r=>r.Errors).ToList();

                if(failures.Any())
                throw new FluentValidation.ValidationException(failures);             
               
                
            }
            return await next();
        }
    }
}
