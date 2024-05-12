using APIEscola.Dto;
using APIEscola.Dto.Alunos;
using APIEscola.Models;
using APIEscola.Models.Alunos;
using APIEscola.Repositorios.Services.Alunos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIEscola.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        readonly private IAlunoInterface _alunoInterface;
        public AlunoController(IAlunoInterface alunoInterface)
        {
            _alunoInterface = alunoInterface;
        }
        [HttpPost("CriarAluno")]
        public async Task<ActionResult<ResponseModel<List<AlunoModel>>>> postAlunos(AlunoCriacaoDto alunoCriacaoDto)
        {
            var aluno = await _alunoInterface.postAlunos(alunoCriacaoDto);
            if (aluno.Dados != null)
            {
                return Ok(aluno);
            }
            return BadRequest(aluno.Mensagem);
        }
        [HttpGet("ListarAlunos")]
        public async Task<ActionResult<ResponseModel<List<AlunoModel>>>> getAlunos()
        {
            var aluno = await _alunoInterface.getAlunos();
            if (aluno.Dados == null)
            {
                return NotFound(aluno.Mensagem);
            }
            return Ok(aluno);
        }
        [HttpDelete("DeletarAlunos/{id}")]
        public async Task<ActionResult<ResponseModel<List<AlunoModel>>>> deleteAlunos(int id)
        {
            var aluno = await _alunoInterface.deleteAlunos(id);
            return Ok(aluno);
        }
        [HttpGet("ListarAlunosPorDisciplina/{id}")]
        public async Task<ActionResult<ResponseModel<List<AlunoModel>>>> getAlunosPorDisciplinaId(int id)
        {
            var aluno = await _alunoInterface.getAlunosPorDisciplinaId(id);
            return Ok(aluno);
        }
        [HttpPost("AssociarDisciplinas")]
        public async Task<ActionResult<ResponseModel<List<AlunoModel>>>> AssociarAlunoADisciplinas(AssociarAlunoDisciplinasDto associarDto)
        {
            try
            {
               var disciplinas = await _alunoInterface.AssociarAlunoADisciplinas(associarDto.AlunoId, associarDto.DisciplinaIds);
                //return Ok("Disciplinas associadas ao aluno com sucesso.");
                return Ok(disciplinas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao associar disciplinas ao aluno: {ex.Message}");
            }
        }
        [HttpGet("ListarAlunosPorId/{id}")]
        public async Task<ActionResult<List<AlunoModel>>> getAlunosPorId (int id)
        {
            var alunos = await _alunoInterface.getAlunosPorId(id);  
            if(alunos == null)
            {
                return NotFound(alunos.Mensagem);
            }
            return Ok(alunos);  
        }
        [HttpGet("ListarAlunosComSuasDisciplinas")]
        public async Task<ActionResult<ResponseModel<List<AlunoModel>>>> GetAllAlunosWithDisciplinasAsync()
        {
            var alunos = await _alunoInterface.GetAllAlunosWithDisciplinasAsync();
            if (alunos == null)
            {
                return NotFound(alunos.Mensagem);
            }
            return Ok(alunos);
        }
    }
}
