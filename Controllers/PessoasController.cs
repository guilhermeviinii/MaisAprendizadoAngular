using System;
using System.Threading.Tasks;
using MaisAprendizado.Data;
using MaisAprendizado.Models;
using Microsoft.AspNetCore.Mvc;

namespace AngularMVC.Controllers
{


    [ApiController]
    [Route("api/[controller]")]

    public class PessoasController : Controller
    {
        [Route("api/[controller]/Get")]
         [HttpGet]
        public IActionResult Get(string email, string senha)
        {
            Pessoa usuario = new Pessoa();
            try
            {
                using(var data = new PessoaData())
                usuario = data.Get(email, senha);
                return Ok("");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
       
        
    }
}