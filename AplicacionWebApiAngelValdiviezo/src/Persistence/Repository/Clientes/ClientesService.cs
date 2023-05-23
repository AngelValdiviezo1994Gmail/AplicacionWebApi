using AngelValdiviezoWebApi.Application.Common.Exceptions;
using AngelValdiviezoWebApi.Application.Common.Interfaces;
using AngelValdiviezoWebApi.Application.Common.Wrappers;
using AngelValdiviezoWebApi.Application.Features.Acontecimientos.Commands.CreateAcontecimientos;
using AngelValdiviezoWebApi.Application.Features.Acontecimientos.Dto;
using AngelValdiviezoWebApi.Application.Features.Clientes.Commands.CreateClientes;
using AngelValdiviezoWebApi.Application.Features.Clientes.Interfaces;
using AngelValdiviezoWebApi.Domain.Entities.Acontecimientos;
using AngelValdiviezoWebApi.Domain.Entities.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelValdiviezoWebApi.Persistence.Repository.Clientes
{
    public class ClientesService : IClientes
    {
        private readonly IRepositoryAsync<ClientesModels> _repositoryAcontecimientoAsync;

        public ClientesService(IRepositoryAsync<ClientesModels> repositoryAcontecimientoAsync)
        {
            _repositoryAcontecimientoAsync = repositoryAcontecimientoAsync;
        }

        public async Task<ResponseType<string>> CreateCliente(CreateClientesRequest Request, CancellationToken cancellationToken)
        {
            try
            {
                var marcacionColaborador = DateTime.Now;
                AcontecimientosResponseType objResultFinal = new();

                ClientesModels objAcont = new()
                {
                    //IdCliente = Request.IdCliente,
                    NombreCliente = Request.NombreCliente,
                    ApellidoCliente= Request.ApellidoCliente,
                    CedulaCliente= Request.CedulaCliente,
                    CorreoCliente= Request.CorreoCliente,
                    CursosCliente= Request.CursosCliente,
                    TelefonoCliente = Request.TelefonoCliente,
                };

                var objResultado = await _repositoryAcontecimientoAsync.AddAsync(objAcont, cancellationToken);
                if (objResultado is null)
                {
                    return new ResponseType<string>() { Message = "No se ha podido registrar su información", StatusCode = "101", Succeeded = true };
                }

                return new ResponseType<string>() { Data = null, Message = "Registro ingresado correctamente", StatusCode = "100", Succeeded = true };

            }
            catch (Exception)
            {
                return new ResponseType<string>() { Message = CodeMessageResponse.GetMessageByCode("102"), StatusCode = "102", Succeeded = false };
            }


        }


    }
}
