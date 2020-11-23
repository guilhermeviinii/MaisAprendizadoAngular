using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MaisAprendizado.Data;
using MaisAprendizado.Models;
using Microsoft.AspNetCore.Mvc;

namespace AngularMVC.Controllers
{
    [ApiController]
    
    public class CursoController : Controller
    {
        [Route("api/[controller]/Get")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
           
            try
            {
                using (var data = new CursoData())
                 
                        return Ok(data.Read());



            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
        [Route("api/[controller]/Read/{nome?}")]
        [HttpGet]
        public async Task<IActionResult> Read(string nome)
        {
           
            try
            {
                using (var data = new CursoData())
                 
                        return Ok(data.Consulta());



            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}