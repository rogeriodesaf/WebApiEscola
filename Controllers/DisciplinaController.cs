using APIEscola.Dto.Disciplinas;
using APIEscola.Models;
using APIEscola.Models.Disciplinas;
using APIEscola.Repositorios.Services.Disciplina;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIEscola.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinaController : ControllerBase
    {
        readonly private IDisciplinaInterface _disciplinaInterface;
        public DisciplinaController(IDisciplinaInterface disciplinaInterface)
        {
            _disciplinaInterface = disciplinaInterface;
        }
        [HttpPost("CriarDisciplina")]
        public async Task<ActionResult<ResponseModel<List<DisciplinaModel>>>> postDisciplina(DisciplinaCriacaoDto disciplinaCriacaoDto)
        {
            var disciplina = await _disciplinaInterface.postDisciplina(disciplinaCriacaoDto);
            if (disciplina.Dados != null)
            {
                return Ok(disciplina);
            }
            return BadRequest(disciplina.Mensagem);
        }
        [HttpGet("ListarDisciplinas")]
        public async Task<ActionResult<ResponseModel<List<DisciplinaModel>>>> getDisciplina()
        {
            var disciplinas = await _disciplinaInterface.getDisciplina();
            if (disciplinas.Dados != null)
            {
                return Ok(disciplinas);
            }
            return BadRequest(disciplinas.Mensagem);
        }
        [HttpDelete("DisciplinaDeletada/{id}")]
        public async Task<ActionResult<ResponseModel<List<DisciplinaModel>>>> deleteDisciplina(int id)
        {
            var disciplinas = await _disciplinaInterface.deleteDisciplina(id);
            if (disciplinas.Dados == null)
            {
                return NotFound(disciplinas.Mensagem);
            }
            return Ok(disciplinas.Dados);
        }
        [HttpGet("GetAlunosPorDisciplinaId/{id}")]
        public async Task<ActionResult<ResponseModel<List<DisciplinaModel>>>> getDisciplinaPorAlunoId(int id)
        {
            var disciplinas = await _disciplinaInterface.getDisciplinaPorAlunoId(id);
            if (disciplinas.Dados == null)
            {
                return NotFound(disciplinas.Mensagem);
            }
            return Ok(disciplinas.Dados);


        }
        [HttpPut("EditarDisciplina")]
        public async Task<ActionResult<ResponseModel<List<DisciplinaModel>>>> putDisciplina(DisciplinaEdicaoDto disciplinaEdicaoDto)
        {
            var disciplina = await _disciplinaInterface.putDisciplina(disciplinaEdicaoDto);
            if(disciplina.Dados == null)
            {
                return NotFound(disciplina.Mensagem);
            }
            return Ok(disciplina);
        }
        [HttpGet("PegarDisciplinaPorID")]
        public  async Task<ActionResult<ResponseModel<List<DisciplinaModel>>>> getDisciplinaPorId(int id)
        {
            var disciplina = await _disciplinaInterface.getDisciplinaPorId(id);
            if(disciplina == null)
            {
                return NotFound(disciplina.Mensagem);
            }
            return Ok(disciplina);
        }
    }
}
