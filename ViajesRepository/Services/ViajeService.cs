using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViajesRepository.Data.Interfaces;
using ViajesRepository.Domain;

namespace ViajesRepository.Services
{
    public class ViajeService : IViajeService
    {
        private readonly IViajeRepository _repository;

        public ViajeService(IViajeRepository repository)
        {
            _repository = repository;
        }
        public Task<bool> EliminarAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }

        public async Task<bool> GuardarAsync(Viaje viaje)
        {
            if (string.IsNullOrWhiteSpace(viaje.Destino))
            {
                throw new ArgumentException("Destino no puede estar vacio");
            }
            //alguna otra validación
            return await _repository.SaveAsync(viaje);
        }

        public Task<Viaje?> ObtenerPorIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task<List<Viaje>> ObtenerTodosAsync()
        {
            return _repository.GetAllAsync();
        }
    }
}
