using csharpagencia.Model;
using csharpagencia.Repository;
using Microsoft.AspNetCore.Mvc;

namespace csharpagencia.Controllers
{

    [ApiController]
    [Route("Api/[controller]")]
    
public class UsuarioController : ControllerBase
    {
          private readonly IUsuarioRepository _repository;

        public UsuarioController(IUsuarioRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public  async Task<IActionResult> GetAll()
        {
             var usuarios = await _repository.GetUsuarios();
            return usuarios.Any() ? Ok(usuarios) : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var usuario = await _repository.GetUsuarioById(id);
            return usuario != null
            ? Ok(usuario) : NotFound("Usuário não encontrado.");
        }
          [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            _repository.AddUsuario(usuario);
            return await _repository.SaveChangesAsync()
            ? Ok("Usuário adicionado") : BadRequest("Algo deu errado.");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, Usuario usuario){
         var usuarioExiste = await _repository.GetUsuarioById(id);
            if (usuarioExiste == null) return NotFound("Usuário não encontrado");

            usuarioExiste.Nome = usuario.Nome ?? usuarioExiste.Nome;
            usuarioExiste.Telefone = usuario.Telefone ?? usuarioExiste.Telefone;
            usuarioExiste.Endereco = usuario.Endereco ?? usuarioExiste.Endereco;
            usuarioExiste.Cpf = usuario.Cpf ?? usuarioExiste.Cpf;
            usuarioExiste.Email = usuario.Email ?? usuarioExiste.Email;
            usuarioExiste.Senha = usuario.Senha ?? usuarioExiste.Senha;

            _repository.AtualizarUsuario(usuarioExiste);

            return await _repository.SaveChangesAsync()
            ? Ok("Usuário atualizado.") : BadRequest("Algo deu errado.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var usuarioExiste = await _repository.GetUsuarioById(id);
            if (usuarioExiste == null)
                return NotFound("Usuário não encontrado");

            _repository.DeletarUsuario(usuarioExiste);

            return await _repository.SaveChangesAsync()
            ? Ok("Usuário deletado.") : BadRequest("Algo deu errado.");
        }
        }
    }
