using FinalHerramientas.Data;
using FinalHerramientas.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalHerramientas.Services
{
    public class BodegaService : IBodegaService
    {
        private readonly VinotecaDbContext _context;
        public BodegaService(VinotecaDbContext context)
        {
            _context = context;
        }
        public async Task Create(Bodega bodega)
        {
            _context.Add(bodega);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Bodega bodega)
        {
            if (bodega != null)
            {
                _context.Remove(bodega);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<Bodega>> GetAll(string filter)
        {
            var query = from bodega in _context.Bodegas select bodega;

            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(bodega => bodega.Nombre.ToLower().Contains(filter.ToLower()));
            }

            return await query.ToListAsync();
        }

        public async Task<Bodega?> GetById(int? id)
        {
            if (id == null || _context.Bodegas == null)
            {
                return null;
            }

            return await _context.Bodegas
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task Update(Bodega bodega)
        {
            _context.Update(bodega);
            await _context.SaveChangesAsync();
        }
    }
}
