using System;
using System.Threading.Tasks;
using MaisAprendizado.Data;
using MaisAprendizado.Models;
using MaisAprendizadoAngular.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AngularMVC.Controllers
{


    [ApiController]

    public class PessoasController : Controller
    {
        [Route("api/[controller]/Get")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Get([FromBody] Pessoa pessoa)
        {
            Pessoa usuario = new Pessoa();
            try
            {
                using (var data = new PessoaData())
                    usuario = data.Get(pessoa.Email, pessoa.Senha);
                if (usuario == null)
                {
                    return new { mensagem = "usuarioErrado" };
                }
                var token = TokenService.GenerateToken(usuario);
                usuario.Senha = "";
                return new
                {
                    usuario = usuario,
                    token = token
                };
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
        [Route("api/[controller]/isProfessor")]
        [HttpGet]
        public async Task<ActionResult<dynamic>> isProfessor(int pessoaId)
        {
            Pessoa pessoa = new Pessoa();
            try
            {
                using (var data = new PessoaData())
               pessoa = data.isProfessor(pessoaId);
                    return new{ pessoa = pessoa.PessoaId } ;
                
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
        [Route("api/[controller]/historicoCompra")]
        [HttpGet]
        public async Task<ActionResult<dynamic>> HistoricoCompra(int pessoaId)
        {
            try
            {
                using (var data = new PessoaData())
               
                    return data.HistoricoCompra(pessoaId);
                
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
        [Route("api/[controller]/editarUsuario")]
        [HttpPost]
        public async Task<ActionResult<dynamic>> editarUsuario([FromBody] Pessoa pessoa)
        {
            int pessoaUpdate;
            Pessoa novaPessoa = new Pessoa();
            try
            {
                using (var data = new PessoaData())
                    pessoaUpdate = data.Update(pessoa);
                using (var data = new PessoaData())
                    novaPessoa = data.Read(pessoaUpdate);

                return Ok(novaPessoa);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }


    }
}