using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Wrappers;
using Application.Features.VentaEntradas.Dto;
using AutoMapper;
using Domain.Entities.Common;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VentaEntradas.Commands.GetListadoAcontecimientos
{

    public record GetListadoAcontecimientosCommand(GetListadoAcontecimientosRequest Request) : IRequest<ResponseType<List<ListadoAcontecimientosType>>>;

    public class GetListadoAcontecimientosCommandHandler : IRequestHandler<GetListadoAcontecimientosCommand, ResponseType<List<ListadoAcontecimientosType>>>
    {
        private readonly IRepositoryAsync<VentaEntradasDom> _repositoryAsyncVtEnt;
        private readonly IRepositoryAsync<VentaEntradasConvivencia> _repositoryAsyncVentEntConv;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly string fotoPerfilDefecto;

        public GetListadoAcontecimientosCommandHandler(IRepositoryAsync<VentaEntradasDom> repository, IRepositoryAsync<VentaEntradasConvivencia> repositoryAsyncVentConv,, IMapper mapper, IConfiguration config)
        {
            _repositoryAsyncVtEnt = repository;
            _repositoryAsyncVentEntConv = repositoryAsyncVentConv;
            _mapper = mapper;
            _config = config;
            fotoPerfilDefecto = _config.GetSection("Imagenes:FotoPerfilDefecto").Get<string>();
        }

        public async Task<ResponseType<List<ListadoAcontecimientosType>>> Handle(GetListadoAcontecimientosCommand request, CancellationToken cancellationToken)
        {
            List<ListadoAcontecimientosType> listadoColaboradores = new();
            var req = request.Request;

            try
            {
                var colConv = await _repositoryAsyncVentEntConv.ListAsync(new GetProspectoByUdnAreaSccSpec(req.Udn, req.Area, req.Scc, req.Colaborador), cancellationToken);
                var colaboradores = await _repositoryAsyncVtEnt.ListAsync(new GetColaboradoresSpec());
                
                var lstCola = colaboradores.Where(c => colConv.Any(p => c.Identificacion == p.Identificacion) || clientEje.Any(cl => c.Identificacion == cl.Identificacion)).ToList();

                if (lstCola != null && lstCola.count == 0) return new ResponseType<List<ListadoAcontecimientosType>>() { Data = listadoColaboradores, Message = CodeMessageResponse.GetMessageByCode("001"), StatusCode = "001", Succeeded = false };

                return new ResponseType<List<ListadoAcontecimientosType>>() { Data = listadoColaboradores, Message = CodeMessageResponse.GetMessageByCode("000"), StatusCode = "000", Succeeded = true };
            }
            catch (Exception ex)
            {
                return new ResponseType<List<ListadoAcontecimientosType>>() { Data = null, Message = CodeMessageResponse.GetMessageByCode("500"), StatusCode = "500", Succeeded = false };
            }
        }
    }

}
