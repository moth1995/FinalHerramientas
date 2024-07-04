namespace FinalHerramientas.Models
{
    public class DetalleDespacho
    {
        public int Id { get; set; }
        public int DespachoId { get; set; }
        public int VinoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        public Despacho Despacho { get; set; }
        public Vino Vino { get; set; }
    }

}
