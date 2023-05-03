using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelValdiviezoWebApi.Domain.Entities.Acontecimientos
{
    [Table("tblAcontecimientoNextTi", Schema = "dbo")]
    public class AcontecimientosModels
    {
        [Column("idAcontecimiento", Order = 0, TypeName = "int")]
        public int idAcontecimiento { get; set; }

        [Column("idEvento", Order = 1, TypeName = "int")]
        public int idEvento { get; set; }

        [Column("Fecha", Order = 2, TypeName = "datetime")]
        public DateTime Fecha { get; set; }

        [Column("Lugar", Order = 3, TypeName = "nvarchar")]
        [StringLength(150)]
        public string Lugar { get; set; }

        [Column("NumeroEntrada", Order = 4, TypeName = "int")]
        public int NumeroEntrada { get; set; }

        [Column("Descripcion", Order = 5, TypeName = "nvarchar")]
        [StringLength(150)]
        public string Descripcion { get; set; }

        [Column("Precio", Order = 6, TypeName = "int")]
        public int Precio { get; set; }
    }
}
