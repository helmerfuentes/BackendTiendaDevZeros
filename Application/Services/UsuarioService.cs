using System;
using System.Collections.Generic;
using System.Linq;
using Application.Base;
using Application.Http.Requests;
using Application.Http.Responses;
using Domain.Contract;
using Domain.Entities.Usuario;
using Domain.Repositories;
using Infrastructure.Utils;

namespace Application.Services
{
    public class UsuarioService : Service<User>
    {
        

        public UsuarioService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
          
        }

        public Response<IEnumerable<UsuarioResponse>> Listar()
        {
            var usuarios = UnitOfWork.UserRepository.FindBy(includeProperties: "Rol,Persona").ToList();

            return new Response<IEnumerable<UsuarioResponse>>
            {
                Message = "Listado de Usuarios",
                Data = usuarios.ConvertAll(x => new UsuarioResponse(x).Include(x.Rol).Include(x.Persona)),
                Code=System.Net.HttpStatusCode.OK
            };
                    
        }

        public Response<CrearUsuarioResponse> Registrar(CrearUsuarioRequest request)
        {
            var usuario = UnitOfWork.UserRepository
               .Any(x => x.Username == request.Usuario);

            if (usuario)
            {
                return new Response<CrearUsuarioResponse>
                {
                    State = false,
                    Message = "Usuario ya existe",
                    Code = System.Net.HttpStatusCode.BadRequest,

                };
            }

            var rol = UnitOfWork.RolRepository
                  .FindBy(x => x.Id == request.RolId)
                  .FirstOrDefault();
            if (rol is null)
            {
                return new Response<CrearUsuarioResponse>
                {
                    State = false,
                    Message = "Rol no existe",
                    Code = System.Net.HttpStatusCode.NotFound,

                };
            }

            var persona = UnitOfWork.PersonaRepository
                .FindBy(x => x.Id == request.PersonaId)
                .FirstOrDefault();

            if (persona is null)
            {
                return new Response<CrearUsuarioResponse>
                {
                    State = false,
                    Message = "Persona no existe",
                    Code = System.Net.HttpStatusCode.NotFound,

                };
            }

            var usuarioRequest = new User
            {
                Password = request.Password,
                PersonaId = request.PersonaId,
                RolId = request.RolId,
                Username=request.Usuario
            };

            UnitOfWork.UserRepository.Add(usuarioRequest);
            UnitOfWork.Commit();
            return new Response<CrearUsuarioResponse>("Usuario Creado", data: new CrearUsuarioResponse { Rol = rol.Nombre, UserName = request.Usuario});

        }

        
        public Response<LoginUserResponse> Autenticar(LoginUserRequest request)
        {
            // TODO: User authentication code
            var usuario = UnitOfWork.UserRepository
                .FindBy(x => x.Username == request.Username && x.Password == Encriptacion.GetSha256(request.Password),"Rol")
                .FirstOrDefault();



            if (usuario is null)
            {
                return new Response<LoginUserResponse>
                {
                    State = false,
                    Message = "Usuario o contraseña incorrecta",
                    Code = System.Net.HttpStatusCode.NotFound,

                };
            }
            

            var token = Encriptacion.BuildToken(usuario);
            return new Response<LoginUserResponse>(
                "Autenticación Correcta", 
                data: new LoginUserResponse
            {
                Username = usuario.Username,
                Token = token,
                Rol = usuario.Rol.Nombre
            });
            
               

            
        }


     
    }
}