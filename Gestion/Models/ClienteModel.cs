using System.ComponentModel.DataAnnotations;

namespace Gestion.Models
{
    public class ClienteModel
    {
  
        public int IdCliente { get; set; }
        
        [Required(ErrorMessage ="El campo Nombre es obligatorio")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo NIF es obligatorio")]
        [StringLength(10)]
        public string Nif { get; set; }

        [Required(ErrorMessage = "El campo domicilio es obligatorio")]
        [StringLength(50)]
        public string Domicilio { get; set; }

        [Required(ErrorMessage = "El campo CP es obligatorio")]
        [StringLength(5)]
        public string Cp { get; set; }
       
        [Required(ErrorMessage = "El campo provincia es obligatorio")]
        [StringLength(15)]
        public string Provincia { get; set; }

        [Required(ErrorMessage = "El campo país es obligatorio")]
        [StringLength(20)]
        public string Pais { get; set; }

        [Required(ErrorMessage = "El campo Fecha Alta es obligatorio")]
        [DataType(DataType.Date)]
        public DateTime Fecha_Alta { get; set; }

    }
}
