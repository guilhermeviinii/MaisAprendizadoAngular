using System;
using System.Threading.Tasks;
using MaisAprendizado.Data;
using Microsoft.AspNetCore.Mvc;

namespace AngularMVC.Controllers
{
     [ApiController]
    [Route("api/[controller]")]
    public class CursoController : Controller
    {
        [HttpGet]
        public IActionResult Get()
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