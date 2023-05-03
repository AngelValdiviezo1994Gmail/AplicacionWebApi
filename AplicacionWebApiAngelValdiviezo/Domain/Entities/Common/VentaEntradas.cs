using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Common
{
    [Table("tblAcontecimientoNextTi", Schema = "dbo")]
    public class VentaEntradasDom
    {
        [Column("idAcontecimiento", Order = 0, TypeName = "int")]
        public int IdAcontecimiento { get; set; }

        [Column("idEvento", Order = 1, TypeName = "int")]
        public int IdEvento { get; set; }

        [Column("Fecha", Order = 2, TypeName = "datetime")]
        public DateTime FechaEvento { get; set; }

        [Column("Lugar", Order = 3, TypeName = "nvarchar")]
        public string LugarEvento { get; set; }

        [Column("NumeroEntrada", Order = 4, TypeName = "int")]
        public int NumEntrada { get; set; }

        [Column("Descripcion", Order = 5, TypeName = "nvarchar")]
        public string DescripcionEvento { get; set; }

        [Column("Precio", Order = 6, TypeName = "int")]
        public int PrecioEvento { get; set; }
    }
}
