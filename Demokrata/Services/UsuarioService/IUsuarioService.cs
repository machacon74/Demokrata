using Demokrata.Entities;

namespace Demokrata.Services.UsuarioService
{
    public interface IUsuarioService
    {
        public Task<List<Usuario>> GetUsuarios();
        public Task<Usuario?> GetUsuarioById(int id);
        public Task<List<Usuario?>> GetUsuariosByNombre(string nombre, int nroPagina, int cantidadRegistros);
        public Task<RespuestaGeneral> AddUsuario(Usuario usuario);
        public Task<RespuestaGeneral> UpdateUsuario(Usuario usuario);
        public Task<RespuestaGeneral> DeleteUsuario(int id);
    }
}
