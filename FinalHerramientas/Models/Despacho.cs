namespace FinalHerramientas.Models
{
    public class Despacho
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public decimal Total { get; set; }

        public virtual List<DetalleDespacho> DetalleDespachos { get; set; }
    }

}
