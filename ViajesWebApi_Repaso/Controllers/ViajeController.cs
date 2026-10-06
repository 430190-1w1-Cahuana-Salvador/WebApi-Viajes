using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViajesRepository.Domain;
using ViajesRepository.Services;

namespace ViajesWebApi_Repaso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViajeController : ControllerBase
    {
        private readonly IViajeService _service;
        public ViajeController(IViajeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var juegos = await _service.ObtenerTodosAsync();
            return Ok(juegos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var juego = await _service.ObtenerPorIdAsync(id);
            if(juego == null)
            {
                NotFound();
            }

            return Ok(juego);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Viaje viaje)
        {
            try
            {
                bool guardado = await _service.GuardarAsync(viaje);

                if (!guardado)
                {
                    return BadRequest("No se pudo guardar el  viaje");
                }
                return CreatedAtAction(nameof(GetById), new { id = viaje.Id }, viaje);
            }
            catch (ArgumentException ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool eliminado = await _service.EliminarAsync(id);

            if (!eliminado)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
