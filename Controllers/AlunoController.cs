using System;
using System.Threading.Tasks;
using MaisAprendizado.Data;
using MaisAprendizado.Models;
using Microsoft.AspNetCore.Mvc;

namespace AngularMVC.Controllers
{
    [ApiController]
    
    public class AlunoController : Controller
    {
        [Route("api/[controller]/Get")]
        [HttpGet]
        public  IActionResult Get()
        {
            try
            {
                return Ok("");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [Route("api/[controller]/registroAluno")]
        [HttpPost]
        public async Task<IActionResult> RegistroAluno([FromBody] Aluno aluno)
        {
            
            try
            {
                using (var data = new AlunoData())  
                data.Create(aluno);                   
                return Ok();



            }
            catch(Exception ex)
            {
                 return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}
