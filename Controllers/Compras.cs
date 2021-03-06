using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MaisAprendizado.Data;
using MaisAprendizado.Models;
using Microsoft.AspNetCore.Mvc;

namespace AngularMVC.Controllers
{
     [ApiController]
    public class ComprasController : Controller
    {
        [Route("api/[controller]/comprar")]
        [HttpPost]
        public async Task<ActionResult<dynamic>> Comprar(Compra compra, int alunoid)
        {
                int id;
            try
            {
                var data = new CompraData();
                    data.Create(compra, alunoid);
                    return Ok();



            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}