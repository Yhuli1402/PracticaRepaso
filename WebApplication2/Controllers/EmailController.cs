using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Context;
using WebApplication2.ModelsEmail;

namespace WebApplication2.ControllersEmail
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly ILogger<EmailController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;

        public EmailController(
            ILogger<EmailController> logger,
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }

        // Create: Crear email
        [HttpPost(Name = "PostEmail")]
        public IActionResult Post([FromBody] Emails email)
        {
            _aplicacionContexto.Email.Add(email);
            _aplicacionContexto.SaveChanges();
            return Ok(email);
        }

        // Read: Obtener lista de emails
        [HttpGet(Name = "GetEmail")]
        public IEnumerable<Emails> Get()
        {
            return _aplicacionContexto.Email.ToList();
        }

        // Update: Modificar email
        [HttpPut(Name = "PutEmail")]
        public IActionResult Put([FromBody] Emails email)
        {
            _aplicacionContexto.Email.Update(email);
            _aplicacionContexto.SaveChanges();
            return Ok(email);
        }

        // Delete: Eliminar email
        [HttpDelete(Name = "DeleteEmail")]
        public IActionResult Delete(int EmailId)
        {
            var emailToDelete = _aplicacionContexto.Email
                .FirstOrDefault(x => x.IdEmail == EmailId);

            if (emailToDelete != null)
            {
                _aplicacionContexto.Email.Remove(emailToDelete);
                _aplicacionContexto.SaveChanges();
                return Ok(EmailId);
            }
            else
            {
                return NotFound($"Email con Id {EmailId} no encontrado.");
            }
        }
    }
}
