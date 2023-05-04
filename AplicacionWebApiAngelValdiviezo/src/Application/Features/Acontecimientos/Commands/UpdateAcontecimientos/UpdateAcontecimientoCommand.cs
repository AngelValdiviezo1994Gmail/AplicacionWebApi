using AngelValdiviezoWebApi.Application.Common.Exceptions;
using AngelValdiviezoWebApi.Application.Common.Interfaces;
using AngelValdiviezoWebApi.Application.Common.Wrappers;
using AngelValdiviezoWebApi.Application.Features.Acontecimientos.Interfaces;
using AngelValdiviezoWebApi.Application.Features.Acontecimientos.Specifications;
using AngelValdiviezoWebApi.Domain.Entities.Acontecimientos;
using AngelValdiviezoWebApi.Domain.Entities.Notificacion;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelValdiviezoWebApi.Application.Features.Acontecimientos.Commands.UpdateAcontecimientos
{
    public record UpdateAcontecimientoCommand(int idAcontecimiento, int idEvento, string NombreEvento, DateTime Fecha, string Lugar, int NumeroEntrada, string Descripcion, int Precio) : IRequest<ResponseType<string>>;
    public class UpdateAcontecimientoCommandQuery : IRequestHandler<UpdateAcontecimientoCommand, ResponseType<string>>
    {

        private readonly IAcontecimientos _repositoryAcontecimiento;       

        public UpdateAcontecimientoCommandQuery(
           IAcontecimientos acontecimientos)
        {
            _repositoryAcontecimiento = acontecimientos;
        }

        public async Task<ResponseType<string>> Handle(UpdateAcontecimientoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                AcontecimientosModels acontecimientos = new AcontecimientosModels()
                {
                    Descripcion = request.Descripcion,
                    Estado = true,
                    Fecha = request.Fecha,
                    idAcontecimiento = request.idAcontecimiento,
                    idEvento = request.idEvento,
                    Lugar = request.Lugar,
                    NumeroEntrada = request.NumeroEntrada,
                    Precio = request.Precio,
                    nombreEvento =  request.NombreEvento,                    
                };


                var objData1 = await _repositoryAcontecimiento.UpdateAcontecimiento(acontecimientos, cancellationToken);



                return new ResponseType<string>() { Succeeded = true, Data = null, Message = CodeMessageResponse.GetMessageByCode("200", "El registro ha sido "), StatusCode = "200" };
            }
            catch (Exception)
            {
                return new ResponseType<string>() { Succeeded = false, Data = null, Message = CodeMessageResponse.GetMessageByCode("201"), StatusCode = "201" };
            }
        }
    }

}
