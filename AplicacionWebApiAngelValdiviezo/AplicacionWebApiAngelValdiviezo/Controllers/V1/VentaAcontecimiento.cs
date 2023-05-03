using Application.Common.Wrappers;
using Application.Features.VentaEntradas.Commands.CreateVenta;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionWebApiAngelValdiviezo.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaAcontecimiento : ControllerBase
    {
        [HttpPost("CreateVenta")]
        [EnableCors("AllowOrigin")]
        [ProducesResponseType(typeof(ResponseType<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        public async Task<IActionResult> CreateCliente([FromBody] CreateVentaRequest request, CancellationToken cancellationToken)
        {
            var objResult = await Mediator.Send(new CreateVentaCommand(request), cancellationToken);
            return Ok(objResult);

        }
    }
}
