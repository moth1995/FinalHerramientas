using FinalHerramientas.Models;

namespace FinalHerramientas.Services
{
    public interface IVinoService
    {
        Task<List<Vino>> GetAll(string filter);
        Task Update(Vino vino);
        Task Delete(Vino vino);
        Task Create(Vino vino);
        Task<Vino?> GetById(int? id);
        Task<List<Bodega>> GetAllBodegas();
    }
}
