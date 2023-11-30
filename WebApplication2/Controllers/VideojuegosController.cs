using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Context;
using WebApplication2.ModelsVideojuegos;

namespace WebApplication2.ControllersVideojuegos
{
    [ApiController]
    [Route("[controller]")]
    public class VideojuegosController : ControllerBase
    {
        private readonly ILogger<VideojuegosController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;

        public VideojuegosController(
            ILogger<VideojuegosController> logger,
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }

        // CREATE: Crear materia
        [HttpPost(Name = "PostVieojuegos")]
        public IActionResult Post([FromBody] Videojuegos videojuegos)
        {
            _aplicacionContexto.Videojuegos.Add(videojuegos);
            _aplicacionContexto.SaveChanges();
            return Ok(videojuegos);
        }

        // READ: Obtener lista de materias
        [HttpGet(Name = "GetVideojuegos")]
        public IEnumerable<Videojuegos> Get()
        {
            return _aplicacionContexto.Videojuegos.ToList();
        }

        // UPDATE: Modificar materia
        [HttpPut(Name = "PutVideojuegos")]
        public IActionResult Put([FromBody] Videojuegos videojuegos)
        {
            _aplicacionContexto.Videojuegos.Update(videojuegos);
            _aplicacionContexto.SaveChanges();
            return Ok(videojuegos);
        }

        // DELETE: Eliminar materia
        [HttpDelete(Name = "DeleteVideojuegos")]
        public IActionResult Delete(int videojuegosId)
        {
            var videojuegos = _aplicacionContexto.Videojuegos
                .FirstOrDefault(x => x.IdVideojuegos == videojuegosId);

            if (videojuegos != null)
            {
                _aplicacionContexto.Videojuegos.Remove(videojuegos);
                _aplicacionContexto.SaveChanges();
                return Ok(videojuegosId);
            }
            else
            {
                return NotFound($"Musica con Id {videojuegosId} no encontrada.");
            }
        }
    }
}
