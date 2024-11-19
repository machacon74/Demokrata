using Demokrata.Entities;

namespace Demokrata.Services.UsuarioService
{
    public interface IUsuarioService
    {
        public Task<List<Usuario>> GetUsuarios();
        public Task<Usuario?> GetUsuarioById(int id);
    }
}
