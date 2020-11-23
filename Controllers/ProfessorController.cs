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

    }
}
