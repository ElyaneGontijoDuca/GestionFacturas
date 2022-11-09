namespace Gestion.Models
{
    public class DetalleModel
    {
        public int IdDetalle { get; set; }
        public int IdFactura { get; set; }

        public int IdProducto { get; set; }

        public string Concepto { get; set; }

        public int Unidades { get; set; }

        public decimal Precio { get; set; }

        public decimal Importe { get; set; }

            
    }
}
