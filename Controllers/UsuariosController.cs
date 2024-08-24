using ExoApi.Domains;
using ExoApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExoApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;
        public UsuariosController(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // get -> /api/usuarios
        [HttpGet]
        public IActionResult Listar()
        {
            return StatusCode(200, _usuarioRepository.Listar());
        }

        // post -> /api/usuarios
        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            _usuarioRepository.Cadastrar(usuario);
            return StatusCode(201);
        }
        // get -> /api/usuarios/{id}
        [HttpGet("{id}")] // Faz a busca pelo ID.
        public IActionResult BuscarPorId(int id)
        {
            Usuario usuario = _usuarioRepository.BuscaPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }
        // put -> /api/usuarios/{id}
        // Atualiza.
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Usuario usuario)
        {
            _usuarioRepository.Atualizar(id, usuario);
            return StatusCode(204);
        }
        // delete -> /api/usuarios/{id}
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            if(_usuarioRepository.BuscaPorId(id) == null)
            {
                return StatusCode(404);
            }
                _usuarioRepository.Deletar(id);

                return StatusCode(204);
            }
        }
    }
