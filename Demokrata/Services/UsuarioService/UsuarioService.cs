using Demokrata.Data;
using Demokrata.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demokrata.Services.UsuarioService
{
    public class UsuarioService : IUsuarioService
    {
        private readonly DataContext _dataContext;
        public UsuarioService(DataContext dataContext) 
        {
            _dataContext = dataContext;
        }

        public Task<Usuario?> GetUsuarioById(int id)
        {
            return _dataContext.Usuarios.FirstOrDefaultAsync(e => e.Id.Equals(id));
        }

        public Task<List<Usuario>> GetUsuarios()
        {
            return _dataContext.Usuarios.ToListAsync();
        }
    }
}
