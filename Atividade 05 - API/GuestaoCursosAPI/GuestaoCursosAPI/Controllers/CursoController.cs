using GuestaoCursosAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuestaoCursosAPI.Controllers
{
    public class CursoController : Controller
    {
        static List<Curso> cursos = new List<Curso>()
        {
            new Curso { Id = 1, Titulo = "Ciencia da computação", Descricao = "Curso de ciencia da computação", CargaHoraria = 300 },
            new Curso { Id = 2, Titulo = "Engenharia de software", Descricao = "Curso de Engenharia de software", CargaHoraria = 400 }

        };

        [HttpGet("cursos")]
        public ActionResult GetAllCursos()
        {
            try
            {
                return Ok(cursos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("cursos/{id:int}")]
        public ActionResult GetCursoById(int id)
        {
            try
            {
                var curso = cursos.Where(e => e.Id == id).FirstOrDefault();
                return Ok(curso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("cursos")]
        public ActionResult CreateCurso([FromBody] Curso curso)
        {
            try
            {
                var ultimoId = cursos.Select(e => e.Id).OrderDescending().FirstOrDefault();
                cursos.Add(new Curso { Id = ultimoId + 1, Titulo = curso.Titulo, Descricao = curso.Descricao, CargaHoraria = curso.CargaHoraria });
                return Ok("Curso criado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("cursos/{id:int}")]
        public ActionResult EditCurso(int id, [FromBody] Curso curso)
        {
            try
            {
                var cursoUpdate = cursos.Where(e => e.Id == id).FirstOrDefault();

                if (cursoUpdate == null)
                {
                    return NotFound($"Curso com ID {id} não foi encontrado.");
                }

                cursoUpdate.Titulo = curso.Titulo;
                cursoUpdate.Descricao = curso.Descricao;
                cursoUpdate.CargaHoraria = curso.CargaHoraria;

                return Ok("Curso alterado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("cursos/{id:int}")]
        public ActionResult DeleteCurso(int id)
        {
            try { 
                var cursoDelete = cursos.Where(e => e.Id == id).FirstOrDefault();
                if (cursoDelete == null)
                {
                    return NotFound($"Curso com ID {id} não foi encontrado.");
                }

                cursos.Remove(cursoDelete);

                return Ok("Curso deletado com sucesso");
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
