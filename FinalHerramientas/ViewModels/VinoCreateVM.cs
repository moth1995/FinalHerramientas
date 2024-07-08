namespace FinalHerramientas.ViewModels
{
    public class VinoCreateVM
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Año { get; set; }
        public string Variedad { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int BodegaId { get; set; }
    }
}
