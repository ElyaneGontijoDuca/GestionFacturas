using System.ComponentModel.DataAnnotations;

namespace Gestion.Models
{
    public class DetalleModel
    {
        public int IdDetalle { get; set; }

        public int IdFactura { get; set; }

        [Required(ErrorMessage = "El campo Concepto es obligatorio")]
        [StringLength(20)]
        public string Concepto { get; set; }

        [Required(ErrorMessage = "El campo Unidades es obligatorio")]
        public int Unidades { get; set; }

        [Required(ErrorMessage = "El campo Precio es obligatorio")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El campo Importe es obligatorio")]
        [StringLength(5)]
        public decimal Importe { get; set; }
    }
}


