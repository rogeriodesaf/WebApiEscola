using APIEscola.Dto.Professores;
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
    }
}
