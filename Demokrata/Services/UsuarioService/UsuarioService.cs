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

        public async Task<RespuestaGeneral> AddUsuario(Usuario usuario)
        {
            RespuestaGeneral respuesta = new RespuestaGeneral();
            try
            {
                _dataContext.Usuarios.Add(usuario);
                await _dataContext.SaveChangesAsync();
                respuesta.Codigo = 1;
                respuesta.Resultado = usuario;
            }
            catch(Exception ex)
            {
                respuesta.Codigo = -1;
                respuesta.Mensaje = ex.Message;
            }
            return respuesta;
        }

        public async Task<RespuestaGeneral> DeleteUsuario(int id)
        {
            try
            {
                if (await _dataContext.Usuarios.AnyAsync(e => e.Id == id))
                {
                    _dataContext.Usuarios.Remove(new Usuario() { Id = id });
                    if (await _dataContext.SaveChangesAsync() > 0)
                        return new RespuestaGeneral() { Codigo = 1 };
                    else
                        return new RespuestaGeneral() { Codigo = 0, Mensaje = "No existe." };
                }
                else
                {
                    return new RespuestaGeneral() { Codigo = 0, Mensaje = "No existe." };
                }
            }
            catch (Exception ex)
            {
                return new RespuestaGeneral() { Codigo = -1, Mensaje = ex.Message };
            }
        }

        public async Task<Usuario?> GetUsuarioById(int id)
        {
            var usuario = await _dataContext.Usuarios.FirstOrDefaultAsync(e => e.Id.Equals(id));
            return usuario;
        }

        public async Task<List<Usuario>> GetUsuariosByNombre(string nombre, int nroPagina, int cantidadRegistros)
        {
            var usuarios = await _dataContext.Usuarios
                .Where(e => e.PrimerNombre.Equals(nombre) || e.PrimerApellido.Equals(nombre))
                .OrderBy(e => e.Id)
                .Skip((nroPagina - 1) * cantidadRegistros)
                .Take(cantidadRegistros)
                .ToListAsync();
            return usuarios;
        }

        public async Task<List<Usuario>> GetUsuarios()
        {
            var usuarios = await _dataContext.Usuarios.ToListAsync();
            return usuarios;
        }

        public async Task<RespuestaGeneral> UpdateUsuario(Usuario usuario)
        {
            try
            {
                if (await _dataContext.Usuarios.AnyAsync(e => e.Id == usuario.Id))
                {
                    var entry = _dataContext.Usuarios.Update(usuario);
                    entry.Property(e => e.FechaCreacion).IsModified = false;
                    if (await _dataContext.SaveChangesAsync() > 0)
                    {
                        entry.Reload();
                        return new RespuestaGeneral() { Codigo = 1, Resultado = usuario };
                    }
                    else
                        return new RespuestaGeneral() { Codigo = 0, Mensaje = "No existe." };
                }
                else
                {
                    return new RespuestaGeneral() { Codigo = 0, Mensaje = "No existe." };
                }
            }
            catch(Exception ex)
            {
                return new RespuestaGeneral() { Codigo = -1, Mensaje = ex.Message };
            }
        }
    }
}
