using APIEscola.Dto.Professores;
using APIEscola.Models;
using APIEscola.Models.Professores;
using APIEscola.Repositorios.Services.Professores;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIEscola.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorInterface _professorInterface;
        public ProfessorController(IProfessorInterface professorInterface)
        {
            _professorInterface = professorInterface;
        }
        [HttpPost("AdicionarProfessor")]
        public async Task<ActionResult<List<ProfessoresModel>>> postProfessore(ProfessorCriacaoDto professorCriacaoDto)
        {
            var professores = await _professorInterface.postProfessor(professorCriacaoDto);
            if(professores == null)
            {
                return NotFound(professores.Mensagem);
            }
            return Ok(professores); 
        }
        [HttpGet("ListarProfessores")]
        public async Task<ActionResult<List<ProfessoresModel>>> getProfessores()
        {
            var professores = await _professorInterface.getProfessores();
            if(professores == null)
            {
                return NotFound(professores.Mensagem);
            }
            return Ok(professores);
        }
        [HttpPut("EditarProfessor")]
        public async Task<ActionResult<List<ProfessoresModel>>> putProfessor(ProfessorEdicaoDto professorrEdicaoDto)
        {
            var professor = await _professorInterface.putProfessor(professorrEdicaoDto);
            if(professor.Dados == null)
            {
                return NotFound(professor.Mensagem);
            }
            return Ok(professor);
        }
        [HttpDelete("ExcluirProfessor/{id}")]
        public async Task<ActionResult<ResponseModel<List<ProfessoresModel>>>> deleteProfessor(int id)
        {
            var professores = await _professorInterface.deleteProfessor(id);
            if(professores is null)
            {
                return BadRequest(professores.Mensagem);
            }
            return Ok(professores);
        }
        [HttpGet("ListarProfessoresPorId/{id}")]
        public async Task<ActionResult<ResponseModel<List<ProfessoresModel>>>> getProfessorPorDisciplinaId(int id)
        {
            var professores = await _professorInterface.getProfessorPorDisciplinaId(id);
            if (professores is null)
            {
                return BadRequest(professores.Mensagem);
            }
            return Ok(professores);
        }
        [HttpPost("AssociarProfessorDisciplina")]
        public async Task<ActionResult<ResponseModel<List<ProfessoresModel>>>> associarProfessorDisciplinaId(AssociarProfessorDisciplinaDto associarDto)
        {
            var professor = await _professorInterface.associarProfessorDisciplinaId(associarDto.ProfessorId, associarDto.DisciplinaId);
            if(professor is null)
            {
                return NotFound(professor.Mensagem);

            }
            return Ok(professor);
        }
        [HttpGet("LIstarProfessoresComDisciplinas")]
        public async Task<ActionResult<ResponseModel<List<ProfessoresModel>>>> GetAllProfessoresComDisciplinas()
        {
            var professores = await _professorInterface.GetAllProfessoresComDisciplinas();
            if(professores == null)
            {
                return NotFound(professores.Mensagem);
            }
            return Ok(professores);
        }
        
    }
}
