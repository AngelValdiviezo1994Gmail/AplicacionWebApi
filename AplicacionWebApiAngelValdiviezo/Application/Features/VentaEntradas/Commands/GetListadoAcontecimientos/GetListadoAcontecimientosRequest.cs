
namespace Application.Features.VentaEntradas.Commands.GetListadoAcontecimientos
{
    public class GetListadoAcontecimientosRequest
    {
        public int idAcontecimiento { get; set; }

        public int idEvento { get; set; }

        public DateTime Fecha { get; set; }

        public string Lugar { get; set; }

        public int NumeroEntrada { get; set; }

        public string Descripcion { get; set; }

        public int Precio { get; set; }
    }
}
