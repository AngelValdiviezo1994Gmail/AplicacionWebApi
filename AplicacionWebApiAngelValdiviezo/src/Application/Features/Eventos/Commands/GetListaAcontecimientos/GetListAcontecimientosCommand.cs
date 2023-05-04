using AngelValdiviezoWebApi.Application.Common.Exceptions;
using AngelValdiviezoWebApi.Application.Common.Interfaces;
using AngelValdiviezoWebApi.Application.Common.Wrappers;
using AngelValdiviezoWebApi.Application.Features.Acontecimientos.Dto;
using AngelValdiviezoWebApi.Application.Features.Acontecimientos.Specifications;
using AngelValdiviezoWebApi.Application.Features.Eventos.Dto;
using AngelValdiviezoWebApi.Application.Features.Eventos.Specifications;
using AngelValdiviezoWebApi.Domain.Entities.Acontecimientos;
using AngelValdiviezoWebApi.Domain.Entities.Eventos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelValdiviezoWebApi.Application.Features.Eventos.Commands.GetListaAcontecimientos
{

    public record GetListAcontecimientosCommand() : IRequest<ResponseType<List<AcontecimientosType>>>;

    public class GetListAcontecimientosCommandHandler : IRequestHandler<GetListAcontecimientosCommand, ResponseType<List<AcontecimientosType>>>
    {
        private readonly IRepositoryAsync<AcontecimientosModels> _repositoryEventosAsync;

        public GetListAcontecimientosCommandHandler(IRepositoryAsync<AcontecimientosModels> repositoryEvAsync)
        {
            _repositoryEventosAsync = repositoryEvAsync;
        }

        public async Task<ResponseType<List<AcontecimientosType>>> Handle(GetListAcontecimientosCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //_repositoryEventosAsync.AddAsync
                //_repositoryEventosAsync.UpdateAsync
                var data = await _repositoryEventosAsync.ListAsync(new GetListAcontecimientosConvivenciaSpec(), cancellationToken);

                if (!data.Any())
                    return new ResponseType<List<AcontecimientosType>>() { Data = null, Message = "No existen acontecimientos agregados", StatusCode = "001", Succeeded = false };


                var response = ProcesoListadoEventos(data);

                return new ResponseType<List<AcontecimientosType>>() { Data = response, Message = CodeMessageResponse.GetMessageByCode("000"), StatusCode = "000", Succeeded = true };

            }
            catch (Exception ex)
            {
                return new ResponseType<List<AcontecimientosType>>() { Data = null, Message = CodeMessageResponse.GetMessageByCode("500"), StatusCode = "500", Succeeded = false };
            }
        }

        public static List<AcontecimientosType> ProcesoListadoEventos(List<AcontecimientosModels> lstAcontecimientos)
        {
            var res = new List<AcontecimientosType>();

            foreach (var objAcontecimiento in lstAcontecimientos)
            {
                res.Add(new()
                {
                    idAcontecimiento = objAcontecimiento.idAcontecimiento,
                    idEvento = objAcontecimiento.idEvento,
                    nombreEvento = objAcontecimiento.nombreEvento,
                    Descripcion = objAcontecimiento.Descripcion,
                    Fecha = objAcontecimiento.Fecha,
                    Lugar = objAcontecimiento.Lugar,
                    NumeroEntrada = objAcontecimiento.NumeroEntrada,
                    Precio = objAcontecimiento.Precio,
                    Estado = objAcontecimiento.Estado
                }
                 );
            }


            res = res.OrderBy(x => x.idEvento).ToList();

            return res;
        }

    }

}
