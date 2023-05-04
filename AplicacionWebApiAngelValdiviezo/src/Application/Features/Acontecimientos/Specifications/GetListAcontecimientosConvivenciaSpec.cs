using AngelValdiviezoWebApi.Domain.Entities.Acontecimientos;
using AngelValdiviezoWebApi.Domain.Entities.Eventos;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AngelValdiviezoWebApi.Application.Features.Acontecimientos.Specifications
{
    public class GetListAcontecimientosConvivenciaSpec : Specification<AcontecimientosModels>
    {
        public GetListAcontecimientosConvivenciaSpec()
        {
            Query.OrderBy(x => x.idEvento);
        }
    }
}
