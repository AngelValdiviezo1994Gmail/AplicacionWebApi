using AngelValdiviezoWebApi.Application.Common.Wrappers;
using AngelValdiviezoWebApi.Application.Features.Acontecimientos.Commands.CreateAcontecimientos;
using AngelValdiviezoWebApi.Application.Features.Acontecimientos.Commands.DeleteLogicoAcontecimientos;
using AngelValdiviezoWebApi.Application.Features.Acontecimientos.Commands.UpdateAcontecimientos;
using AngelValdiviezoWebApi.Application.Features.Acontecimientos.Dto;
using AngelValdiviezoWebApi.Application.Features.Eventos.Commands.GetListaAcontecimientos;
using AngelValdiviezoWebApi.Application.Features.Eventos.Commands.GetListaEventos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace AngelValdiviezoWebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class VentaEntradasController : ApiControllerBase
    {

        [HttpGet("GetVentaEntradas")]
        [EnableCors("AllowOrigin")]
        [ProducesResponseType(typeof(ResponseType<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetVentaEntrada()
        {
            var objResult = await Mediator.Send(new GetListAcontecimientosCommand());

            return Ok(objResult);
        }

        [HttpPost("GenerarVentaEntrada")]
        [EnableCors("AllowOrigin")]
        [ProducesResponseType(typeof(ResponseType<AcontecimientosResponseType>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateVentaEntrada([FromBody] CreateAcontecimientosRequest request, CancellationToken cancellationToken)
        {
            var objResult = await Mediator.Send(new CreateAcontecimientosCommand(request), cancellationToken);
            return Ok(objResult);
        }

        [EnableCors("AllowOrigin")]
        [HttpPut("UpdateVentaEntrada")]
        [ProducesResponseType(typeof(ResponseType<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateVentaEntrada(int idAcontecimiento, int idEvento, String nombreEvento, DateTime Fecha, string Lugar, int NumeroEntrada, string Descripcion, int Precio, CancellationToken cancellationToken)
        {
            var objResult = await Mediator.Send(new UpdateAcontecimientoCommand(idAcontecimiento, idEvento, nombreEvento,Fecha, Lugar,NumeroEntrada,Descripcion,Precio), cancellationToken);
            return Ok(objResult);
        }

        [EnableCors("AllowOrigin")]
        [HttpPut("EliminaVentaEntrada")]
        [ProducesResponseType(typeof(ResponseType<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> EliminaVentaEntrada(int idAcontecimiento, int idEvento, String nombreEvento, DateTime Fecha, string Lugar, int NumeroEntrada, string Descripcion, int Precio, CancellationToken cancellationToken)
        {
            var objResult = await Mediator.Send(new DeleteLogicoAcontecimientoCommand(idAcontecimiento, idEvento, nombreEvento, Fecha, Lugar, NumeroEntrada, Descripcion, Precio), cancellationToken);
            return Ok(objResult);
        }

    }
}
