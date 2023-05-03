using AngelValdiviezoWebApi.Application.Common.Exceptions;
using AngelValdiviezoWebApi.Application.Common.Interfaces;
using AngelValdiviezoWebApi.Application.Common.Wrappers;
using AngelValdiviezoWebApi.Application.Features.Eventos.Dto;
using AngelValdiviezoWebApi.Application.Features.Eventos.Specifications;
using AngelValdiviezoWebApi.Domain.Entities.Eventos;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelValdiviezoWebApi.Application.Features.Eventos.Commands
{
    public record GetListEventosCommand() : IRequest<ResponseType<List<EventosType>>>;

    public class GetListEventosCommandHandler : IRequestHandler<GetListEventosCommand, ResponseType<List<EventosType>>>
    {
        private readonly IRepositoryAsync<EventosModels> _repositoryEventosAsync;

        public GetListEventosCommandHandler(IRepositoryAsync<EventosModels> repositoryEvAsync)
        {
            _repositoryEventosAsync = repositoryEvAsync;
        }

        public async Task<ResponseType<List<EventosType>>> Handle(GetListEventosCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _repositoryEventosAsync.ListAsync(new GetListEventsConvivenciaSpec(), cancellationToken);

                if (!data.Any())
                    return new ResponseType<List<EventosType>>() { Data = null, Message = "Colaborador no tiene roles asignados", StatusCode = "001", Succeeded = false };


                var response = ProcesoListadoEventos(data);

                return new ResponseType<List<EventosType>>() { Data = response, Message = CodeMessageResponse.GetMessageByCode("100"), StatusCode = "100", Succeeded = true };
            
            }
            catch (Exception)
            {
                return new ResponseType<List<EventosType>>() { Data = null, Message = CodeMessageResponse.GetMessageByCode("500"), StatusCode = "500", Succeeded = false };
            }
        }

        public static List<EventosType> ProcesoListadoEventos(List<EventosModels> lstEventos)
        {
            var res = new List<EventosType>();

            foreach (var objEvento in lstEventos)
            {
               res.Add(new()
                    {
                        idEvento = objEvento.idEvento,
                        nombreEvento = objEvento.nombreEvento
                    }
                );
            }


            res = res.OrderBy(x => x.idEvento).ToList();

            return res;
        }

    }

}
