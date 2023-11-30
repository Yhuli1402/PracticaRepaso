using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Context;
using WebApplication2.ModelsUsuario;

namespace WebApplication2.ControllersUsuario
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;

        public UsuarioController(
            ILogger<UsuarioController> logger,
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }

        // CREATE: Crear materia
        [HttpPost(Name = "PostUsuario")]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            _aplicacionContexto.Usuario.Add(usuario);
            _aplicacionContexto.SaveChanges();
            return Ok(usuario);
        }

        // READ: Obtener lista de materias
        [HttpGet(Name = "GetUsuario")]
        public IEnumerable<Usuario> Get()
        {
            return _aplicacionContexto.Usuario.ToList();
        }

        // UPDATE: Modificar materia
        [HttpPut(Name = "PutUsuario")]
        public IActionResult Put([FromBody] Usuario usuario)
        {
            _aplicacionContexto.Usuario.Update(usuario);
            _aplicacionContexto.SaveChanges();
            return Ok(usuario);
        }

        // DELETE: Eliminar materia
        [HttpDelete(Name = "DeleteUsuario")]
        public IActionResult Delete(int usuarioId)
        {
            var usuario = _aplicacionContexto.Usuario
                .FirstOrDefault(x => x.IdUsuario == usuarioId);

            if (usuario != null)
            {
                _aplicacionContexto.Usuario.Remove(usuario);
                _aplicacionContexto.SaveChanges();
                return Ok(usuarioId);
            }
            else
            {
                return NotFound($"Usuario con Id {usuarioId} no encontrada.");
            }
        }
    }
}
