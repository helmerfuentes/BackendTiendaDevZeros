using System;
using Domain.Repositories;

namespace Domain.Contract
{
    public interface IUnitOfWork : IDisposable
    {
        #region [Repositories]
        public IUserRepository UserRepository { get;}
        public IRolRepository RolRepository { get;}
        public IPersonaRepository PersonaRepository { get;}
        public IProductoRepository  ProductoRepository { get; }
        public ICategoriaRepository  CategoriaRepository{ get; }
        public IPermisoRepository PermisoRepository { get;  }
        public IDetalleCompraRepository DetalleCompraRepository { get;  }
        public IDetalleVentaRepository DetalleVentaRepository { get; }
        public IFacturaCompraRepository FacturaCompraRepository { get;  }
        public IProvedorRepository ProvedorRepository{ get;  }
        public IFacturaRepository FacturaRepository { get; }
        public IFacturaVentaRepository FacturaVentaRepository{ get; }

        #endregion

        int Commit();
    }
}