using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Inicializacion
{
    public class Inicializador
    {
        private readonly MyContext _ctx;
        public Inicializador(MyContext ctx)
        {
            _ctx = ctx;
        }

        public void inicializar()
        {
            if (!_ctx.Provedores.Any()) ProovedorInicializador.InicializarProvedor(_ctx);
            if (!_ctx.Categorias.Any()) CategoriaInicializador.InicializadorCategoria(_ctx);
            if (!_ctx.Productos.Any()) ProductoInicializador.InicializadorProducto(_ctx);
            if (!_ctx.Personas.Any()) PersonaInicializador.InicializarPersona(_ctx);
            if (!_ctx.Roles.Any()) Rolinicializador.InicializadorRol(_ctx);
            if (!_ctx.Users.Any()) UsuarioInicializador.InicializarUsuario(_ctx);
            if (!_ctx.Permisos.Any()) Permisosinicializador.InicializadorPermiso(_ctx);
        }
    }
}
