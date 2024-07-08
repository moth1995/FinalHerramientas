namespace FinalHerramientas.ViewModels
{
    public class BodegaListVM
    {
        public List<BodegaVM> Bodegas { get; set; } = new List<BodegaVM>();
        public string? Filter { get; set; }
    }
}
