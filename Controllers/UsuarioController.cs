using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Threading.Tasks;
using WebAPI.Net.Models;
using WebAPI.Net.Repository.Interface;

namespace WebAPI.Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Retorna todos os usuários.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable>> GetUsuarios()
        {
            try
            {
                var usuarios = await _usuarioRepository.GetUsuarios();
                return Ok(usuarios);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao buscar usuários.");
            }
        }

        /// <summary>
        /// Retorna um usuário por ID.
        /// </summary>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            try
            {
                var usuario = await _usuarioRepository.GetUsuarios(id);
                if (usuario == null) return NotFound($"Usuário com id {id} não encontrado");
                return Ok(usuario);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao buscar o usuário.");
            }
        }

        /// <summary>
        /// Adiciona um novo usuário.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Usuario>> AddUsuario([FromBody] Usuario usuario)
        {
            try
            {
                if (usuario == null) return BadRequest("Dados inválidos.");
                var novoUsuario = await _usuarioRepository.AddUsuario(usuario);
                return CreatedAtAction(nameof(GetUsuario), new { id = novoUsuario.UserId }, novoUsuario);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar o usuário.");
            }
        }

        /// <summary>
        /// Atualiza um usuário existente.
        /// </summary>
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Usuario>> AtualizarUsuario(int id, [FromBody] Usuario usuario)
        {
            try
            {
                if (id != usuario.UserId) return BadRequest("ID do usuário não confere.");

                var usuarioExistente = await _usuarioRepository.GetUsuarios(id);
                if (usuarioExistente == null) return NotFound($"Usuário com id {id} não encontrado");

                var atualizado = await _usuarioRepository.AtualizarUsuario(usuario);
                return Ok(atualizado);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar o usuário.");
            }
        }

        /// <summary>
        /// Deleta um usuário por ID.
        /// </summary>
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Usuario>> DeletarUsuario(int id)
        {
            try
            {
                var usuario = await _usuarioRepository.GetUsuarios(id);
                if (usuario == null) return NotFound($"Usuário com id {id} não encontrado");

                var deletado = await _usuarioRepository.DeletarUsuario(id);
                return Ok(deletado);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar o usuário.");
            }
        }
    }
}
