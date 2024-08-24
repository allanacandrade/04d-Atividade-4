using ExoApi.Domains;
using ExoApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProjetosController : ControllerBase
    {
        private readonly ProjetoRepository _projetoRepository;
        public ProjetosController(ProjetoRepository projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }
        
        [HttpGet]
        public IActionResult ListarProjetos()
        {
            return StatusCode(200, _projetoRepository.Listar());
        }
        // Código novo que completa o CRUD.
        [HttpPost]
        public IActionResult Cadastrar(Projeto projeto)
        {
            _projetoRepository.Cadastrar(projeto);

            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Projeto projeto = _projetoRepository.BuscarporId(id);
            if (projeto == null)
            {
                return StatusCode(404);
            }
                return StatusCode(200, projeto);
            
        }

        private IActionResult Notfound()
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Projeto projeto)
        {
            _projetoRepository.Atualizar(id, projeto);

            return StatusCode(204);
        }
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            if(_projetoRepository.BuscarporId(id) == null)
            {
                return StatusCode(404);
            }

            _projetoRepository.Deletar(id);

                return StatusCode(204);
           
            }
        }
    }
