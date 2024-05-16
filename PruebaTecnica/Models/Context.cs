using Microsoft.EntityFrameworkCore;

namespace PruebaTecnica.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }   

        public DbSet<Sorteo> Sorteos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sorteo>().HasIndex(c => c.numeroSorteo).IsUnique();//Metodo para de que el numero de sorteo sea único
        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Usuario> Usuarios { get; set;}
        //se indican las tablas que se van a crear en la base de datos gracias a la clases anteriormente creadas

    }

}