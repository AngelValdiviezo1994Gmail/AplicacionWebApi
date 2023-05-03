﻿using Application.Common.Wrappers;
using Application.Features.VentaEntradas.Commands.CreateVenta;
using Application.Features.VentaEntradas.Commands.GetListadoAcontecimientos;
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

        [HttpGet("GetListadoAcontecimientos")]
        [EnableCors("AllowOrigin")]
        [ProducesResponseType(typeof(ResponseType<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAcontecimientos(CancellationToken cancellationToken)
        {
            GetListadoAcontecimientosRequest request = new GetListadoAcontecimientosRequest
            {
               idAcontecimiento = 0,
            };

            var objResult = await Mediator.Send(new GetListadoAcontecimientosCommand(request), cancellationToken);

            return Ok(objResult);
        }

        /*

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
        */
    }
}
