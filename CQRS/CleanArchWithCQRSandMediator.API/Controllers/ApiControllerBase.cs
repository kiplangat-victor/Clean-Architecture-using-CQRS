using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchWithCQRSandMediator.API.Controllers
{
    [ApiController]

    [Route("api/[controller]")]
    public class ApiControllerBase :ControllerBase
    {
        private ISender _mediator;
        protected ISender Mediator => _mediator ?? HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}