using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViajesRepository.Data.Interfaces;
using ViajesRepository.Domain;

namespace ViajesRepository.Data.Implementations
{
    public class ViajeRepository : IViajeRepository
    {
        private readonly ViajeDbContext _context;
        public ViajeRepository(ViajeDbContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var viaje = await _context.Viajes.FirstOrDefaultAsync(v => v.Id == id);

            if(viaje == null)
            {
                return false;
            }
            _context.Viajes.Remove(viaje);

            var filas = await _context.SaveChangesAsync();
            return filas > 0;
        }

        public async Task<List<Viaje>> GetAllAsync()
        {
            return await _context.Viajes
                .Include(v => v.ViajeDetalles)
                .ThenInclude(d => d.Excursion)
                .ToListAsync();
        }

        public async Task<Viaje?> GetByIdAsync(int id)
        {
            return await _context.Viajes
                .Include(v => v.ViajeDetalles)
                .ThenInclude(d => d.Excursion)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<bool> SaveAsync(Viaje viaje)
        {
            if(viaje.Id == 0)
            {
                await _context.Viajes.AddAsync(viaje);
            }
            else
            {
                _context.Viajes.Update(viaje);
            }

            var filas = await _context.SaveChangesAsync();
            return filas > 0;
        }
    }
}
