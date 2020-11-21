using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AngularMVC.Controllers
{


    [ApiController]
    [Route("api/[controller]")]

    public class PessoasController : Controller
    {
         [HttpGet]
        public IActionResult Get()
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
       
        
    }
}