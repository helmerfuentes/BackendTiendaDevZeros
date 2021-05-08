using Domain.Entities;
using Domain.Entities.Facturacion;
using Domain.Entities.Usuario;
using Infrastructure.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class MyContext : DbContextBase
    {
        public MyContext(DbContextOptions options) : base(options)
        {
        }

        #region DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<DetalleCompra> DetalleCompras{ get; set; }
        public DbSet<Proovedor> Provedores{ get; set; }
        public DbSet<Factura> Facturas{ get; set; }
        public DbSet<FacturaCompra> Compras{ get; set; }
        public DbSet<FacturaVenta> Ventas{ get; set; }
        public DbSet<Permiso> Permisos{ get; set; }
        public DbSet<Persona> Personas{ get; set; }
        public DbSet<Rol> Roles{ get; set; }
        public DbSet<DetalleVenta> DetalleVentas{ get; set; }
        public DbSet<Producto> Productos{ get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration on creation
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Persona>()
                .HasOne(b => b.User)
                .WithOne(i => i.Persona)
                .HasForeignKey<User>(b => b.PersonaId);
        }
    }
}