using AngelValdiviezoWebApi.Application.Common.Wrappers;
using AngelValdiviezoWebApi.Application.Features.Acontecimientos.Commands.CreateAcontecimientos;
using AngelValdiviezoWebApi.Application.Features.Acontecimientos.Dto;
using AngelValdiviezoWebApi.Domain.Entities.Acontecimientos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelValdiviezoWebApi.Application.Features.Acontecimientos.Interfaces
{
    public interface IAcontecimientos
    {
        Task<ResponseType<string>> CreateAcontecimiento(CreateAcontecimientosRequest Request, CancellationToken cancellationToken);
        Task<ResponseType<string>> UpdateAcontecimiento(AcontecimientosModels Request, CancellationToken cancellationToken);
        Task<ResponseType<string>> DeleteLogicoAcontecimiento(AcontecimientosModels Request, CancellationToken cancellationToken);
    }
}
