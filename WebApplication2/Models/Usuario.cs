using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ModelsUsuario
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public bool Genero { get; set; }
        public int Edad { get; set; }

    }
}