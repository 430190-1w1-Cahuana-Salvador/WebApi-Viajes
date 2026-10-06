using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViajesRepository.Domain;

namespace ViajesRepository.Data.Interfaces
{
    public interface IViajeRepository
    {
        Task<List<Viaje>> GetAllAsync(); 
        Task<Viaje?> GetByIdAsync(int id); 
        Task<bool> SaveAsync(Viaje viaje); 
        Task<bool> DeleteAsync(int id);


    }
}
