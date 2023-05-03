using Ardalis.Specification;
using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Features.VentaEntradas.Specifications
{
    public class GetAcontecimientoConvivenciaSpec : Specification<VentaEntradasConvivencia>
    {
        public GetAcontecimientoConvivenciaSpec()
        {
            Query.OrderBy(x => x.IdAcontecimiento);
        }
    }
}
