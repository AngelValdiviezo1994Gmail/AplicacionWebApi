using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Features.VentaEntradas.Specifications
{
    [Table("tblAcontecimientoNextTi", Schema = "dbo")]
    public class GetAcontecimientoConvivenciaSpec
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("idAcontecimiento", Order = 0, TypeName = "int")]
        public int IdAcontecimiento { get; set; }

        [Column("idEvento", Order = 1, TypeName = "int")]
        public int IdEvento { get; set; }

        [Column("Fecha", Order = 2, TypeName = "datetime")]
        public DateTime Fecha { get; set; }

        [Column("Lugar", Order = 3, TypeName = "nvarchar")]
        public string Lugar { get; set; }

        [Column("NumeroEntrada", Order = 4, TypeName = "int")]
        public int NumeroEntrada { get; set; }

        [Column("Descripcion", Order = 5, TypeName = "nvarchar")]
        public string Descripcion { get; set; }

        [Column("Precio", Order = 6, TypeName = "int")]
        public int Precio { get; set; }
    }
}
