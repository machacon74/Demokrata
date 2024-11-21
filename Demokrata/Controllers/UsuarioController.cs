using Demokrata.DTO.Usuario;
using Demokrata.Entities;
using Demokrata.Services.UsuarioService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demokrata.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService) 
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> GetAllUsuarios()
        {
            var usuarios = await _usuarioService.GetUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario?>> GetUsuarioById(int id)
        {
            var usuario = await _usuarioService.GetUsuarioById(id);
            return Ok(usuario);
        }

        [HttpGet("GetUsuariosByNombre")]
        public async Task<ActionResult<List<Usuario?>>> GetUsuariosByNombre(string nombre, int nroPagina, int cantidadRegistros)
        {
            var usuario = await _usuarioService.GetUsuariosByNombre(nombre, nroPagina, cantidadRegistros);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult> RegistrarUsuario(UsuarioDtoInsert usuarioDto)
        {
            Usuario usuario = new Usuario()
            {
                PrimerNombre = usuarioDto.PrimerNombre,
                SegundoNombre = usuarioDto.SegundoNombre,
                PrimerApellido = usuarioDto.PrimerApellido,
                SegundoApellido = usuarioDto.SegundoApellido,
                Sueldo = usuarioDto.Sueldo,
                FechaNacimiento = usuarioDto.FechaNacimiento
            };
            var rpta = await _usuarioService.AddUsuario(usuario);
            if (rpta.Codigo == 1)
                return Ok(rpta.Resultado);
            else if (rpta.Codigo == 0)
                return NotFound();
            else
                return Conflict(rpta.Mensaje);
        }

        [HttpPut]
        public async Task<ActionResult> EditarUsuario(UsuarioDtoUpdate usuarioDto)
        {
            Usuario usuario = new Usuario()
            {
                Id = usuarioDto.Id,
                PrimerNombre = usuarioDto.PrimerNombre,
                SegundoNombre = usuarioDto.SegundoNombre,
                PrimerApellido = usuarioDto.PrimerApellido,
                SegundoApellido = usuarioDto.SegundoApellido,
                Sueldo = usuarioDto.Sueldo,
                FechaNacimiento = usuarioDto.FechaNacimiento
            };
            var rpta = await _usuarioService.UpdateUsuario(usuario);
            if (rpta.Codigo == 1)
                return Ok(rpta.Resultado);
            else if (rpta.Codigo == 0)
                return NotFound();
            else
                return Conflict(rpta.Mensaje);
        }

        [HttpDelete]
        public async Task<ActionResult<List<Usuario>>> EliminarUsuario(int id)
        {
            var rpta = await _usuarioService.DeleteUsuario(id);
            if (rpta.Codigo == 1)
                return Ok(await _usuarioService.GetUsuarios());
            else if (rpta.Codigo == 0)
                return NotFound();
            else
                return Conflict(rpta.Mensaje);
        }
    }
}
