using infomerc_site.Models;
using Microsoft.EntityFrameworkCore;

namespace infomerc_site.Data
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options)
        { 
        }

        public DbSet<Usuario> Usuarios { get; set; }

    }
}