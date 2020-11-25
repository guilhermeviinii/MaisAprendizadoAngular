using System;
using System.Threading.Tasks;
using MaisAprendizado.Data;
using MaisAprendizado.Models;
using Microsoft.AspNetCore.Mvc;

namespace AngularMVC.Controllers
{

    [ApiController]

    public class ProfessorController : Controller
    {
        
        [Route("api/[controller]/Get")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            
            try
            {
                using (var data = new PessoaData())                     
                return Ok(data.Read());



            }
            catch(Exception ex)
            {
                 return BadRequest($"Erro: {ex.Message}");
            }
        }
        [Route("api/[controller]/registroProfessor")]
        [HttpPost]
        public async Task<IActionResult> RegistroProfessor([FromBody] Professor professor)
        {
            
            try
            {
                using (var data = new ProfessorData())  
                data.Create(professor);                   
                return Ok();



            }
            catch(Exception ex)
            {
                 return BadRequest($"Erro: {ex.Message}");
            }
        }

    }
}
