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
        [Route("api/[controller]/BuscarCursoPorNome")]
        [HttpGet]
        public async Task<IActionResult> BuscarCursoPorNome(string nome)
        {
            try
            {
                using (var data = new CursoData())

                    return Ok(data.BuscarCursoPorNome(nome));



            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
        [Route("api/[controller]/buscarTodosCursoPorId")]
        [HttpGet]
        public async Task<ActionResult<dynamic>> buscarTodosCursoPorId(int id)
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                using (var data = new CursoData())

                    cursos = data.buscarTodosCursoPorId(id);
                    return new { 
                        cursos = cursos
                    };



            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
        [Route("api/[controller]/buscarTodosCursoCriadoPorId")]
        [HttpGet]
        public async Task<ActionResult<dynamic>> buscarTodosCursoCriadoPorId(int id)
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                using (var data = new CursoData())

                    cursos = data.buscarTodosCursoCriadoPorId(id);
                    return new { 
                        cursos = cursos
                    };



            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        
        [Route("api/[controller]/criarCurso")]
        [HttpPost]
        
        public IActionResult criarCurso([FromBody]Curso curso1)
        {
            try
            {

                using (var data = new CursoData())
                    data.Create(curso1);
                return Ok("");



            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
        [Route("api/[controller]/editarCurso")]
        [HttpPost]
        
        public IActionResult editarCurso([FromBody]Curso curso1)
        {
            try
            {

                using (var data = new CursoData())
                    data.Update(curso1);
                return Ok("");



            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
        [Route("api/[controller]/Read")]
        [HttpGet]
        public async Task<IActionResult> Read()
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