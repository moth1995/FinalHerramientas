using FinalHerramientas.Models;

namespace FinalHerramientas.Services
{
    public interface IBodegaService
    {
        Task<List<Bodega>> GetAll(string filter); 
        Task Update (Bodega bodega);
        Task Delete (Bodega bodega);
        Task Create (Bodega bodega);
        Task<Bodega?> GetById(int? id);
    }
}
