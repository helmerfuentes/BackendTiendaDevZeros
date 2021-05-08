namespace Application.Http.Requests
{
    public class CrearUsuarioRequest
    {
        public string Usuario { get; set; }
        public string Password { get; set; }
        public int RolId { get; set; }
        public int PersonaId { get; set; }
    }
}