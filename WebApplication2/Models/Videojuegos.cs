using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ModelsVideojuegos
{
    public class Videojuegos
    {
        [Key]
        public int IdVideojuegos { get; set; }
        public string Nombre { get; set; }
        public string TipoDePago { get; set; }
        public bool EsGrupal { get; set; }
        public string Tipo { get; set; }
        public int IdUsuario { get; set; }
    }
}