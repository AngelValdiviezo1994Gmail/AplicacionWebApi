using AngelValdiviezoWebApi.Application.Common.Wrappers;
using AngelValdiviezoWebApi.Application.Features.Eventos.Commands.GetListaEventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelValdiviezoWebApi.Application.Features.Eventos.Interfaces
{
    public interface IEventos
    {
        Task<ResponseType<string>> GetListEventosAsync(GetListEventosRequest request);
    }
}
