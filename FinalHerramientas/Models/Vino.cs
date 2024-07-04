namespace FinalHerramientas.Models
{
    public class Vino
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Año { get; set; }
        public string Variedad { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int BodegaID { get; set; }

        public Bodega Bodega { get; set; }
        public List<DetalleDespacho> DetalleDespachos { get; set; }
    }

}
