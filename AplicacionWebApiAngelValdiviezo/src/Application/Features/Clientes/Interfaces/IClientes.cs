using AngelValdiviezoWebApi.Application.Common.Wrappers;
using AngelValdiviezoWebApi.Application.Features.Acontecimientos.Commands.CreateAcontecimientos;
using AngelValdiviezoWebApi.Application.Features.Clientes.Commands.CreateClientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelValdiviezoWebApi.Application.Features.Clientes.Interfaces
{
    public interface IClientes
    {
        Task<ResponseType<string>> CreateCliente(CreateClientesRequest Request, CancellationToken cancellationToken);
    }
}
