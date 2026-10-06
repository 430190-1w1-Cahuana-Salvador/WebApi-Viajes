using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViajesRepository.Domain;

namespace ViajesRepository.Services
{
    public interface IViajeService
    {
        Task<List<Viaje>> ObtenerTodosAsync();
        Task<Viaje?> ObtenerPorIdAsync(int id);
        Task<bool> GuardarAsync(Viaje viaje);
        Task<bool> EliminarAsync(int id);
    }
}
