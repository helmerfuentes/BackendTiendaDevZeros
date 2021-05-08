using Application.Base;
using Application.Http.Requests;
using Application.Http.Responses;
using Domain.Contract;
using Domain.Entities.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PersonaService:Service<Persona>
    {
        public PersonaService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public Response<PersonaResponse> Registrar(CrearPersonaRequest request)
        {
            var persona = new Persona
            {
                Apellidos = request.Apellidos,
                Direccion = request.Direccion,
                Documento = request.Documento,
                Nombres = request.Nombres,
                Telefono = request.Telefono
            };

            UnitOfWork.PersonaRepository.Add(persona);
            UnitOfWork.Commit();
            return new Response<PersonaResponse>("Persona Creada", 
                data: new PersonaResponse { 
                    Apellidos = request.Apellidos,
                    Nombres = request.Nombres,
                    Direccion = request.Direccion,
                    Documento = request.Documento, 
                    Telefono = request.Telefono,
                    Id=persona.Id});

        }



    }
}
