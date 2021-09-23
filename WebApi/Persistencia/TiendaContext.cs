using System.Threading;
using WebApi.Dominio;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Persistencia
{
    public class TiendaContext:DbContext
    {
         public TiendaContext(DbContextOptions<TiendaContext> options) : base (options) { }

            public DbSet<Producto> Producto { get; set; }
        
    }
}