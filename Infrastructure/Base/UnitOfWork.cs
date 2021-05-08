using Domain.Contract;
using Domain.Repositories;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Compra;
using Infrastructure.Repositories.Facturacion;
using Infrastructure.Repositories.Usuario;
using Infrastructure.Repositories.Venta;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        public IDbContext _dbContext;

        public UnitOfWork(IDbContext context)
        {
            _dbContext = context;
        }

        #region Repositories

        private IUserRepository _userRepository;
        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_dbContext);

        private ICategoriaRepository _categoriaRepository;
        public ICategoriaRepository CategoriaRepository=> _categoriaRepository??= new CategoriaRepository(_dbContext);

        private IDetalleCompraRepository _detalleCompraRepository;
        public IDetalleCompraRepository DetalleCompraRepository=> _detalleCompraRepository ??= new DetalleCompraRepository(_dbContext);

        private IProvedorRepository _provedorRepository;
        public IProvedorRepository ProvedorRepository=> _provedorRepository ??= new ProovedorRepository(_dbContext);

        private IFacturaRepository _facturaRepository;
        public IFacturaRepository FacturaRepository=> _facturaRepository ??= new FacturaRepository(_dbContext);

        private IFacturaCompraRepository _facturaCompraRepository;
        public IFacturaCompraRepository FacturaCompraRepository=> _facturaCompraRepository ??= new FacturaCompraRepository(_dbContext);

        private IFacturaVentaRepository _facturaVentaRepository;
        public IFacturaVentaRepository FacturaVentaRepository => _facturaVentaRepository ??= new FacturaVentaRepository(_dbContext);

        private IPermisoRepository _permisoRepository;
        public IPermisoRepository PermisoRepository=> _permisoRepository ??= new PermisoRepository(_dbContext);
        
        private IPersonaRepository _personaRepository;
        public IPersonaRepository PersonaRepository=> _personaRepository ??= new PersonaRepository(_dbContext);

        private IRolRepository _rolRepository;
        public IRolRepository RolRepository=> _rolRepository ??= new RolRepository(_dbContext);

        private IDetalleVentaRepository _detalleVentaRepository;
        public IDetalleVentaRepository DetalleVentaRepository=> _detalleVentaRepository ??= new DetalleVentaRepository(_dbContext);

        private IProductoRepository _productoRepository;
        public IProductoRepository ProductoRepository => _productoRepository ??= new ProductoRepository(_dbContext);


        #endregion

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (!disposing || _dbContext == null) return;
            ((DbContext) _dbContext).Dispose();
            _dbContext = null;
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }
    }
}