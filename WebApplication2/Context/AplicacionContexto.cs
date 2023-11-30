using Microsoft.EntityFrameworkCore;
using WebApplication2.ModelsEmail;
using WebApplication2.ModelsUsuario;
using WebApplication2.ModelsVideojuegos;

namespace WebApplication2.Context
{
    public class AplicacionContexto : DbContext
    {
        public AplicacionContexto
            (DbContextOptions<AplicacionContexto> options)
            : base(options) { }

        public DbSet<Emails> Email { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Videojuegos> Videojuegos { get; set; }
    }
}
