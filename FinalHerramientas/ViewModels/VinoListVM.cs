namespace FinalHerramientas.ViewModels
{
    public class VinoListVM
    {
        public List<VinoVM> vinos { get; set; } = new List<VinoVM>();
        public string? Filter { get; set; }
    }
}
