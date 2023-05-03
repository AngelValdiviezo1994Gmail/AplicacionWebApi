using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace AplicacionWebApiAngelValdiviezo.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public class ApiControllerBase : ControllerBase
    {
        private IMediator _mediator = null!;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
    }
}
