using FinalHerramientas.Data;
using FinalHerramientas.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalHerramientas.Services
{
    public class VinoService : IVinoService
    {
        private readonly VinotecaDbContext _context;
        public VinoService(VinotecaDbContext context)
        {
            _context = context;
        }
        public async Task Create(Vino vino)
        {
            _context.Add(vino);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Vino vino)
        {
            if (vino != null)
            {
                _context.Remove(vino);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<Vino>> GetAll(string filter)
        {
            var query = _context.Vinos.Include(v => v.Bodega).AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(vino => vino.Nombre.ToLower().Contains(filter.ToLower()));
            }

            return await query.ToListAsync();
        }


        public async Task<List<Bodega>> GetAllBodegas()
        {
            var query = from bodega in _context.Bodegas select bodega;

            return await query.ToListAsync();
        }

        public async Task<Vino?> GetById(int? id)
        {
            if (id == null || _context.Vinos == null)
            {
                return null;
            }

            return await _context.Vinos
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task Update(Vino vino)
        {
            _context.Update(vino);
            await _context.SaveChangesAsync();
        }
    }
}
