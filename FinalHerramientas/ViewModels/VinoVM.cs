namespace FinalHerramientas.ViewModels
{
    public class VinoVM
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Año { get; set; }
        public string Variedad { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int BodegaId { get; set; }
        public string BodegaNombre { get; set; }
    }
}
