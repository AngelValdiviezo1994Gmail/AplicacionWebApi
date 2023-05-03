using Application.Common.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediatR;
using System.Threading.Tasks;

namespace Application.Features.VentaEntradas.Commands.CreateVenta
{
    public record CreateClienteCommand(CreateVentaRequest ClienteRequest) : IRequest<ResponseType<string>>;

}
