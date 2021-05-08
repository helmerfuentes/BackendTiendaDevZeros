using Application.Base;
using Application.Builder;
using Application.Http.Requests;
using Application.Http.Responses;
using Domain.Contract;
using Domain.Entities;
using Domain.Entities.Facturacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FacturaService:Service<Factura>
    {
        public FacturaService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public Response<FacturaResponse> RegistrarVenta(CrearFacturaVentaRequest request)
        {
            try
            {
                var persona = UnitOfWork.PersonaRepository
               .FindBy(x => x.Id == request.PersonaId)
               .FirstOrDefault();
                if (persona is null)
                {
                    return new Response<FacturaResponse>(
                        "Persona no encontrada",
                        code: System.Net.HttpStatusCode.BadRequest,
                        state: false
                        );
                }
                var productos = UnitOfWork.ProductoRepository.FindBy(x => request.NumeroproductosPorId.Contains(x.Id)).ToList();

                if (productos.Count != request.DetallesProducto.Count)
                {
                    return new Response<FacturaResponse>(
                      "No se encontraron algunos productos",
                      code: System.Net.HttpStatusCode.BadRequest,
                      state: false
                      );
                }

                FacturaVentaBuilder.Inicializar();
                request.DetallesProducto.ForEach(x =>
                {
                    FacturaVentaBuilder.AgregarDetalle(x.Descuento, productos.First(p => p.Id == x.ProductoId), x.Costo, x.Cantidad);
                });
                var factura = FacturaVentaBuilder.Build(request.PersonaId);

                UnitOfWork.FacturaRepository.Add(factura);
                UnitOfWork.Commit();


                return new Response<FacturaResponse>("Venta exitosa",
                    data: new FacturaResponse
                    {
                        Id = factura.Id,
                        Fecha = factura.Fecha,
                        Nombre = factura.Persona.Nombres + " " + factura.Persona.Apellidos,
                        Valor = factura.Valor,
                        Tipo = "Cliente"

                    }
                );
            }
            catch (Exception e)
            {
                return new Response<FacturaResponse>(
                       e.Message,
                       code: System.Net.HttpStatusCode.BadRequest,
                       state: false
                       );
            }

           
        }

        public Response<IEnumerable<FacturaCompraResponse>> ListarCompras()
        {
            var facturas = UnitOfWork.FacturaCompraRepository.FindBy(includeProperties: "Provedor,Compras.Producto").ToList();

            return new Response<IEnumerable<FacturaCompraResponse>>("Compras realizadas",
                data: facturas.ConvertAll(x => new FacturaCompraResponse(x).Include(x.Provedor).Include(x.Compras.ToList())
                ));
        }

        public Response<IEnumerable<FacturaVentaResponse>> ListarVentas()
        {
            var facturas = UnitOfWork.FacturaVentaRepository.FindBy(includeProperties:"Persona,Ventas.Producto").ToList();

            return new Response<IEnumerable<FacturaVentaResponse>>("Compra realizadas",
              data: facturas.ConvertAll(x => new FacturaVentaResponse(x).Include(x.Persona).Include(x.Ventas.ToList()))
              );
            
        }

        public Response<FacturaResponse> RegistrarCompra(CrearFacturaCompraRequest request)
        {
            var provedor = UnitOfWork.ProvedorRepository
                .FindBy(x => x.Id == request.ProovedorId)
                .FirstOrDefault();
            if (provedor is null)
            {
                return new Response<FacturaResponse>(
                   "No se encontro provedor",
                   code: System.Net.HttpStatusCode.BadRequest,
                   state: false
                   );

            }
            var productos = UnitOfWork.ProductoRepository.FindBy(x => request.NumeroproductosPorId.Contains(x.Id)).ToList();

            if (productos.Count != request.DetallesCompra.Count)
            {
                return new Response<FacturaResponse>(
                  "No se encontraron algunos productos",
                  code: System.Net.HttpStatusCode.BadRequest,
                  state: false
                  );
            }

            FacturaCompraBuilder.Inicializar();
            request.DetallesCompra.ForEach(x =>
            {
                FacturaCompraBuilder.AgregarDetalle(x.Cantidad, productos.First(p=>p.Id==x.ProductoId), x.Costo);
            });
            
            var factura=FacturaCompraBuilder.Build(request.ProovedorId);

            UnitOfWork.FacturaRepository.Add(factura);
            UnitOfWork.Commit();
             
            return new Response<FacturaResponse>("Compra exitosa",
               data: new FacturaResponse
               {
                   Id = factura.Id,
                   Fecha = factura.Fecha,
                   Nombre = factura.Provedor.Nombre,
                   Valor = factura.Valor,
                   Tipo="Proveedor"
               }
           );

        }
    }
}
