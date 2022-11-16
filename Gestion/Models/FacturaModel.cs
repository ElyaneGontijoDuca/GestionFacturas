using System.ComponentModel.DataAnnotations;

namespace Gestion.Models
{
    public class FacturaModel
    {
        public int IdFactura { get; set; }

        public int IdCliente { get; set; }

        [Required(ErrorMessage = "El campo Fecha es obligatorio")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
    }
}
