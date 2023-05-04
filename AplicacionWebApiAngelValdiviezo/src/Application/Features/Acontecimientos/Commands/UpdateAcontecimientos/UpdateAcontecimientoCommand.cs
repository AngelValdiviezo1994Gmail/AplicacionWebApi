using AngelValdiviezoWebApi.Application.Common.Exceptions;
using AngelValdiviezoWebApi.Application.Common.Interfaces;
using AngelValdiviezoWebApi.Application.Common.Wrappers;
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
    public record UpdateAcontecimientoCommand(int idAcontecimiento, int idEvento, DateTime Fecha, string Lugar, int NumeroEntrada, string Descripcion, int Precio) : IRequest<ResponseType<string>>;
    public class UpdateAcontecimientoCommandQuery : IRequestHandler<UpdateAcontecimientoCommand, ResponseType<string>>
    {
        private readonly IConfiguration _config;

        private readonly IApisConsumoAsync _repositoryApis;
        private readonly IRepositoryAsync<AcontecimientosModels> _repoAcont;        

        public UpdateAcontecimientoCommandQuery(IRepositoryAsync<AcontecimientosModels> repoAcont, IConfiguration config, IApisConsumoAsync repositoryApis)
        {
            _config = config;
            _repositoryApis = repositoryApis;
            _repoAcont = repoAcont;
        }

        public async Task<ResponseType<string>> Handle(UpdateAcontecimientoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var pbjAcontecimiento = await _repoAcont.FirstOrDefaultAsync(new AcontecimientosByIdSpec(request.idAcontecimiento), cancellationToken);

                if (pbjAcontecimiento is null)
                {
                    return new ResponseType<string>() { Succeeded = false, Data = null, Message = CodeMessageResponse.GetMessageByCode("201", "No existe registro para actualizar"), StatusCode = "201" };
                }

                if (pbjAcontecimiento is not null)
                {

                    var objActualizar = new
                    {
                        idEvento = request.idEvento,
                        Fecha = request.Fecha,
                        Lugar = request.Lugar,
                        NumeroEntrada = request.NumeroEntrada,
                        Descripcion = request.Descripcion,
                        Precio = request.Precio,
                    };

                    var objData1 = await _repositoryApis.PutEndPoint(objActualizar);

                }



                return new ResponseType<string>() { Succeeded = true, Data = null, Message = CodeMessageResponse.GetMessageByCode("200", "La solicitud ha sido "), StatusCode = "200" };
            }
            catch (Exception ex)
            {
                return new ResponseType<string>() { Succeeded = false, Data = null, Message = CodeMessageResponse.GetMessageByCode("201"), StatusCode = "201" };
            }
        }
    }

}
