using APIEscola.Data;
using APIEscola.Dto.Professores;
using APIEscola.Models;
using APIEscola.Models.Professores;
using Microsoft.EntityFrameworkCore;

namespace APIEscola.Repositorios.Services.Professores
{
    public class ProfessorService : IProfessorInterface
    {
        readonly private AppDbContext _context;
        public ProfessorService(AppDbContext context)
        {
            _context = context; 
        }
        public Task<ResponseModel<List<ProfessoresModel>>> deleteProfessor(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<ProfessoresModel>>> getProfessores()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<ProfessoresModel>>> getProfessorPorDisciplinaId(int idDisciplina)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<ProfessoresModel>> getProfessorPorId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<ProfessoresModel>>> postProfessor(ProfessorCriacaoDto professorCriacaoDto)
        {
           var response = new ResponseModel<List<ProfessoresModel>>();
            try
            {
                var professorCriado = new ProfessoresModel();
                {
                    professorCriado.Nome = professorCriacaoDto.Nome;
                }
                if(professorCriado != null)
                {
                    _context.Professor.Add(professorCriado);
                    await _context.SaveChangesAsync();

                }

                response.Dados =  await _context.Professor.ToListAsync();
                response.Mensagem = "Professor salvo com sucesso!";

               

               
            }
            catch (Exception ex)
            {

                response.Mensagem = "Deu muito errado viu " + ex.Message;
                response.Status = false;
                return response;
            }
            return response;
        }

        public Task<ResponseModel<List<ProfessoresModel>>> putProfessor(ProfessorEdicaoDto professorEdicaoDto)
        {
            throw new NotImplementedException();
        }
    }
}
