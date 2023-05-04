using AngelValdiviezoWebApi.Application.Common.Wrappers;
using AngelValdiviezoWebApi.Application.Features.Acontecimientos.Commands.CreateAcontecimientos;
using AngelValdiviezoWebApi.Application.Features.Acontecimientos.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelValdiviezoWebApi.Application.Features.Acontecimientos.Interfaces
{
    public interface IAcontecimientos
    {
        Task<ResponseType<AcontecimientosResponseType>> CreateAcontecimiento(CreateAcontecimientosRequest Request, CancellationToken cancellationToken);
    }
}
