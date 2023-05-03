using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Features.VentaEntradas.Commands.CreateVenta
{
    public class CreateVentaRequest
    {
        [JsonPropertyName("fechaEvento")]
        public DateTime FechaEvento { get; set; }

        [JsonPropertyName("lugarEvento")]
        public string LugarEvento { get; set; }

        [JsonPropertyName("numEntrada")]
        public int NumEntrada { get; set; }

        [JsonPropertyName("descripcionEvento")]
        public string DescripcionEvento { get; set; }

        [JsonPropertyName("precioEvento")]
        public string PrecioEvento { get; set; }
    }
}
