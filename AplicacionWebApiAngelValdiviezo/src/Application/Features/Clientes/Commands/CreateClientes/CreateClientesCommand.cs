using AngelValdiviezoWebApi.Application.Common.Wrappers;
using AngelValdiviezoWebApi.Application.Features.Acontecimientos.Commands.CreateAcontecimientos;
using AngelValdiviezoWebApi.Application.Features.Acontecimientos.Interfaces;
using AngelValdiviezoWebApi.Application.Features.Clientes.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelValdiviezoWebApi.Application.Features.Clientes.Commands.CreateClientes
{
    public record CreateClientesCommand(CreateClientesRequest CreateCliente) : IRequest<ResponseType<string>>;

    public class CreateClientesCommandHandler : IRequestHandler<CreateClientesCommand, ResponseType<string>>
    {

        private readonly IClientes _repository;

        public CreateClientesCommandHandler(IClientes repository)
        {
            _repository = repository;
        }

        public async Task<ResponseType<string>> Handle(CreateClientesCommand request, CancellationToken cancellationToken)
        {
            var objResult = await _repository.CreateCliente(request.CreateCliente, cancellationToken);
            return objResult;

        }
    }

}
