using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Http.Responses
{
   public class ProovedorResponse
    {
        public int Id { get; set; }
        public string Nit { get; set; }
        public string Nombre { get; set; }
        public string RazonSocial { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        public ProovedorResponse(Proovedor provedor)
        {
            Id = provedor.Id;
            Nombre = provedor.Nombre;
            RazonSocial = provedor.RazonSocial;
            Nit = provedor.Nit;
            Telefono = provedor.Telefono;
            Direccion = provedor.Direccion;


        }
    }
}
