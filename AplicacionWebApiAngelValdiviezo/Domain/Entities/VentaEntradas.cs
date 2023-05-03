using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class VentaEntradas
    {
        public DateTime FechaEvento { get; set; }
        public string LugarEvento { get; set; }
        public int NumEntrada { get; set; }
        public string DescripcionEvento { get; set; }
        public int PrecioEvento { get; set; }
    }
}
