using Application.Base;
using Application.Http.Requests;
using Application.Http.Responses;
using Domain.Contract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductoService : Service<Producto>
    {
        public ProductoService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }


        private void SumarProducto(int Id, int Valor)
        {
            var producto = UnitOfWork.ProductoRepository.FindBy(x => x.Id == Id)
                .FirstOrDefault();
            if((producto is null))
            {

            }
            else
            {
                producto.CantidadDisponible = producto.CantidadDisponible + Valor;
                UnitOfWork.ProductoRepository.Edit(producto);
                UnitOfWork.Commit();
            }
        }


        public Response<IEnumerable<ProductoResponse>> ListarPorCategoria(int categoriaId)
        {
            var productos = UnitOfWork.ProductoRepository.FindBy(x=>x.CantidadDisponible>0 && x.CategoriaId==categoriaId).ToList();

            return new Response<IEnumerable<ProductoResponse>>("Listado de Producto",
                data: productos.ConvertAll(x => new ProductoResponse(x)));
        }
        public Response<IEnumerable<ProductoResponse>> Listar()
        {
            var productos = UnitOfWork.ProductoRepository.FindBy(includeProperties: "Categoria").ToList();

            return new Response<IEnumerable<ProductoResponse>>("Listado de Producto",
                data: productos.ConvertAll(x => new ProductoResponse(x).Include(x.Categoria)));
        }

        public Response<IEnumerable<ProductoResponse>> ListarDisponible()
        {
            var productos = UnitOfWork.ProductoRepository.FindBy(x=>x.CantidadDisponible!=0, includeProperties: "Categoria,DetalleCompras").ToList();

            return new Response<IEnumerable<ProductoResponse>>("Listado de Producto",
                data: productos.ConvertAll(x => new ProductoResponse(x).Include(x.Categoria).Include(x.DetalleCompras.ToList())));
        }




        public Response<CrearProductoResponse> Actualizar(CrearProductoRequest request)
        {
            var producto = UnitOfWork.ProductoRepository.FindBy(x => x.Codigo == request.Codigo)
                .FirstOrDefault();
            if (producto != null)
            {
                return new Response<CrearProductoResponse>
                {
                    State = false,
                    Message = "Producto con codigo: " + request.Codigo + " ya existe",
                    Code = System.Net.HttpStatusCode.BadRequest,

                };
            }

            var categoria = UnitOfWork.CategoriaRepository.FindBy(x => x.Id == request.CategoriaId)
                .FirstOrDefault();
            if (producto is null)
            {
                return new Response<CrearProductoResponse>
                {
                    State = false,
                    Message = "Categoria no existe",
                    Code = System.Net.HttpStatusCode.NotFound,

                };
            }

            var productoRequest = new Producto
            {
                CantidadDisponible = 0,
                CategoriaId = request.CategoriaId,
                Codigo = request.Codigo,
                Iva = request.Iva,
                PorcentajeMaxDescuento = request.PorcentajeMaxDescuento,
                PorcentajeUtilidad = request.PorcentajeUtilidad,
                Nombre = request.Nombre,
                Precio = request.Precio
            };

            UnitOfWork.ProductoRepository.Add(productoRequest);
            UnitOfWork.Commit();

            return new Response<CrearProductoResponse>("Producto registrado",
              data: new CrearProductoResponse
              {
                  CantidadDisponible = 0,
                  Categoria = categoria.Nombre,
                  Nombre = request.Nombre,
                  Iva = request.Iva,
                  PorcentajeMaxDescuento = request.PorcentajeMaxDescuento,
                  PorcentajeUtilidad = request.PorcentajeUtilidad,
                  Precio = request.Precio
              });

        }

        public Response<CrearProductoResponse> Registrar(CrearProductoRequest request)
        {
            var producto = UnitOfWork.ProductoRepository.FindBy(x => x.Codigo == request.Codigo)
                .FirstOrDefault();
            if (producto != null)
            {
                return new Response<CrearProductoResponse>
                {
                    State = false,
                    Message = "Producto con codigo: " + request.Codigo + " ya existe",
                    Code = System.Net.HttpStatusCode.BadRequest,

                };
            }

            var categoria = UnitOfWork.CategoriaRepository.FindBy(x => x.Id == request.CategoriaId)
                .FirstOrDefault();
            if (categoria is null)
            {
                return new Response<CrearProductoResponse>
                {
                    State = false,
                    Message = "Categoria no existe",
                    Code = System.Net.HttpStatusCode.NotFound,

                };
            }

            var productoRequest = new Producto
            {
                CantidadDisponible = 0,
                CategoriaId = request.CategoriaId,
                Codigo = request.Codigo,
                Iva = request.Iva,
                PorcentajeMaxDescuento = request.PorcentajeMaxDescuento,
                PorcentajeUtilidad = request.PorcentajeUtilidad,
                Nombre = request.Nombre,
                Precio = request.Precio
            };

            UnitOfWork.ProductoRepository.Add(productoRequest);
            UnitOfWork.Commit();

            return new Response<CrearProductoResponse>("Producto registrado",
              data: new CrearProductoResponse
              {
                  CantidadDisponible = 0,
                  Categoria = categoria.Nombre,
                  Nombre = request.Nombre,
                  Iva = request.Iva,
                  PorcentajeMaxDescuento = request.PorcentajeMaxDescuento,
                  PorcentajeUtilidad = request.PorcentajeUtilidad,
                  Precio = request.Precio
              });
                
        }
    }


}
