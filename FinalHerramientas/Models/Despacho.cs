namespace FinalHerramientas.Models
{
    public class Despacho
    {
        public int Id { get; set; }
        public int ClienteID { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public decimal Total { get; set; }

        public Cliente Cliente { get; set; }
        public List<DetalleDespacho> DetalleDespachos { get; set; }
    }

}
