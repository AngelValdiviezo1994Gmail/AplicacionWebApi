using AngelValdiviezoWebApi.Application.Common.Wrappers;
using AngelValdiviezoWebApi.Application.Features.Acontecimientos.Dto;
using AngelValdiviezoWebApi.Application.Features.Acontecimientos.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelValdiviezoWebApi.Application.Features.Acontecimientos.Commands.CreateAcontecimientos
{

    public record CreateAcontecimientosCommand(CreateAcontecimientosRequest CreateMarcacion) : IRequest<ResponseType<string>>;

    public class CreateAcontecimientosCommandHandler : IRequestHandler<CreateAcontecimientosCommand, ResponseType<string>>
    {

        private readonly IAcontecimientos _repository;

        public CreateAcontecimientosCommandHandler(IAcontecimientos repository)
        {
            _repository = repository;            
        }

        public async Task<ResponseType<string>> Handle(CreateAcontecimientosCommand request, CancellationToken cancellationToken)
        {
            var objResult = await _repository.CreateAcontecimiento(request.CreateMarcacion, cancellationToken);
            return objResult;

        }
    }

}
