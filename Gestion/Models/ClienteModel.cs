using System.ComponentModel.DataAnnotations;

namespace Gestion.Models
{
    public class ClienteModel
    {
  
        public int IdCliente { get; set; }
        
        [Required(ErrorMessage ="El campo Nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo NIF es obligatorio")]
        public string Nif { get; set; }

        [Required(ErrorMessage = "El campo domicilio es obligatorio")]
        public string Domicilio { get; set; }

        [Required(ErrorMessage = "El campo CP es obligatorio")]
        public string Cp { get; set; }
       
        [Required(ErrorMessage = "El campo provincia es obligatorio")]
        public string Provincia { get; set; }

        [Required(ErrorMessage = "El campo país es obligatorio")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "El campo Fecha Alta es obligatorio")]
        public DateTime Fecha_Alta { get; set; }

    }
}
