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

      

        public async Task<ResponseModel<List<ProfessoresModel>>> associarProfessorDisciplinaId(int idProfessor, List<int> disciplinaId)
        {
            var response = new ResponseModel<List<ProfessoresModel>>();
            try
            {
                var professor = await _context.Professor
                    .Include(b =>b.Disciplina)
                    .FirstAsync(a =>a.Id == idProfessor);
                //validations

                var disciplina = await _context.Disciplina
                    .Where(disdB => disciplinaId.Contains(disdB.Id))
                    .ToArrayAsync();

             foreach(var disciplinas in disciplina)
                {
                    professor.Disciplina.Add(disciplinas);
                }

                await _context.SaveChangesAsync();

                response.Dados = await _context.Professor
                    .Include(a => a.Disciplina).ToListAsync();
                response.Mensagem = "Glória a Deus!";
            }
            catch (Exception ex)
            {

                response.Mensagem = "Deu errado "+ex.Message;
                response.Status = false;
                return response;
            }

            return response;
        }
        public async Task<ResponseModel<List<ProfessoresModel>>> deleteProfessor(int id)
        {
            var response = new ResponseModel<List<ProfessoresModel>>();
            try
            {
                var professor = await _context.Professor.FirstOrDefaultAsync(a => a.Id == id);
                if(professor == null)
                {
                    response.Mensagem = "deu errado!";
                    response.Status = false;
                    return response;
                }
                _context.Professor.Remove(professor);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Professor.ToListAsync();
                response.Mensagem = "Professor deletado!";
            }
            catch (Exception ex)
            {

                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
            return response;
        }

        public async  Task<ResponseModel<List<ProfessoresModel>>> GetAllProfessoresComDisciplinas()
        {
            var response = new ResponseModel<List<ProfessoresModel>>();
            try
            {
                var professores = await _context.Professor
                    .Include(a =>a.Disciplina)
                    .ToListAsync();

                response.Dados = professores;
                response.Mensagem = "Legal, tá dando certo!";
                
            }
            catch (Exception ex)
            {

                response.Mensagem = "droga "+ex.Message;
                response.Status = false;
                return response;
            }
            return response;
        }

        public async Task<ResponseModel<List<ProfessoresModel>>> getProfessores()
        {
            var response = new ResponseModel<List<ProfessoresModel>>();
            try
            {
                var professores = await _context.Professor.ToListAsync();
                if(professores != null)
                {
                    response.Dados = professores;
                    response.Status = false;
                    response.Mensagem = "Professor adicionado com sucesso!";
                }

               
            }
            catch (Exception ex)
            {

                response.Mensagem = "Deu algo muito errado " + ex.Message;
                response.Status = false;
                return response;
            }
            return response;
        }

        public async  Task<ResponseModel<ProfessoresModel>> getProfessorPorDisciplinaId(int idDisciplina)
        {
            var response = new ResponseModel<ProfessoresModel>();
            try
            {
                var professor = await _context.Professor
                    .Include(a => a.Disciplina)
                    .FirstOrDefaultAsync(profBanco => profBanco.Id == idDisciplina);

                response.Dados = professor;
                response.Mensagem = "Deu certo";
               

                
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
            return response;
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

        public async Task<ResponseModel<List<ProfessoresModel>>> putProfessor(ProfessorEdicaoDto professorEdicaoDto)
        {
            var response = new ResponseModel<List<ProfessoresModel>>();
            try
            {
                var professores = await _context.Professor
                    .FirstOrDefaultAsync(a => a.Id == professorEdicaoDto.Id);
                if(professores != null)
                {
                    professores.Id = professorEdicaoDto.Id;
                    professores.Nome = professorEdicaoDto.Nome;
                }

                _context.Professor.Update(professores);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Professor.ToListAsync();
                response.Mensagem = "deu certo !";
            }
            catch (Exception ex)
            {

               response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
            return response;
        }
    }
}
