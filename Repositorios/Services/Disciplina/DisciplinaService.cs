using APIEscola.Data;
using APIEscola.Dto.Disciplinas;
using APIEscola.Models;
using APIEscola.Models.Alunos;
using APIEscola.Models.Disciplinas;
using Microsoft.EntityFrameworkCore;

namespace APIEscola.Repositorios.Services.Disciplina
{
    public class DisciplinaService : IDisciplinaInterface

    {
        private readonly AppDbContext _context;
        public DisciplinaService(AppDbContext context)
        {
            _context = context; 
        }
        public async Task<ResponseModel<List<DisciplinaModel>>> deleteDisciplina(int id)
        {
            ResponseModel<List<DisciplinaModel>> response = new ResponseModel<List<DisciplinaModel>>();
            try
            {
                var disciplinaDeletada = await _context.Disciplina
                    .FirstOrDefaultAsync(a => a.Id == id);
                if(disciplinaDeletada !=null)
                {
                    _context.Disciplina.Remove(disciplinaDeletada);
                    await _context.SaveChangesAsync();


                    response.Mensagem = "Disciplina deletada com sucesso!";
                    response.Status = false;
                    
                }
                
            }
            catch (Exception ex)
            {

               response.Mensagem= "Disciplina não encontrada"+ex.Message;
                response.Status= false;
                return response;
            }
            return response;
        }

        public async Task<ResponseModel<List<DisciplinaModel>>> getDisciplina()
        {
           ResponseModel<List<DisciplinaModel>> response = new ResponseModel<List<DisciplinaModel>>();
            try
            {
                var disciplinas = await _context.Disciplina.ToListAsync();
                if(disciplinas != null)
                {
                    response.Dados = await _context.Disciplina.ToListAsync();
                    response.Mensagem = "Sucess";
                    return response;
                }

                response.Mensagem = "Dados não encontrados";
                response.Status = false;
                return response;
            }
            catch (Exception ex)
            {

                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

       
        public async Task<ResponseModel<List<DisciplinaModel>>> postDisciplina(DisciplinaCriacaoDto disciplinaCriacaoDto)
        {
            ResponseModel<List<DisciplinaModel>> response = new ResponseModel<List<DisciplinaModel>>();
            try
            {
                var disciplinaCriada = new DisciplinaModel();
                {
                    disciplinaCriada.Nome = disciplinaCriacaoDto.Nome;
                }
                if(disciplinaCriada != null)
                {
                   _context.Disciplina.Add(disciplinaCriada);
                    await _context.SaveChangesAsync();

                   
                }
                response.Dados = await _context.Disciplina.AsNoTracking().ToListAsync();
                response.Mensagem = "Dados salvos";
                return response;
            }
            catch (Exception ex)
            {

                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public  async Task<ResponseModel<List<DisciplinaModel>>> putDisciplina(DisciplinaEdicaoDto disciplinaEdicaoDto)
        {
            var response = new ResponseModel<List<DisciplinaModel>>();
            try
            {
                var disciplinaEditada = await _context.Disciplina.AsNoTracking()
                    .FirstOrDefaultAsync(a => a.Id == disciplinaEdicaoDto.Id);
                if(disciplinaEditada == null)
                {
                    response.Mensagem = "eRRO";
                    response.Status = false;
                    return response;
                }


                var disciplina = new DisciplinaModel();
                {
                    disciplina.Id = disciplinaEdicaoDto.Id;
                    disciplina.Nome = disciplinaEdicaoDto.Nome;
                }

                _context.Disciplina.Update(disciplina);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Disciplina.AsNoTracking().ToListAsync();    
                response.Mensagem = "Disciplina Atualizada com sucesso";


            }
            catch (Exception ex)
            {

                response.Mensagem = "Deu errado" + ex.Message;
                response.Status = false;
                return response;
            }
            return response;
        }

       
        
          
            public async Task<ResponseModel<DisciplinaModel>> getDisciplinaPorId(int id)
            {
                var response = new ResponseModel<DisciplinaModel>();
                try
                {
                    var disciplina = await _context.Disciplina
                        .FirstOrDefaultAsync(a => a.Id == id);
                    if (disciplina == null)
                    {
                        response.Mensagem = "Erro";
                        response.Status = false;
                        return response;
                    }

                    response.Dados = disciplina;
                    response.Mensagem = "Sucesso!";
                }
                catch (Exception ex)
                {

                    response.Mensagem = "Deu errado hein " + ex.Message;
                    response.Status = false;
                    return response;
                }
                return response;
            }



        public async Task<ResponseModel<List<DisciplinaModel>>> getDisciplinaPorAlunoId(int idAluno)
        {
            var response = new ResponseModel<List<DisciplinaModel>>();
            try
            {
                var disciplina = await _context.Disciplina

                   .Where(bdDisc => bdDisc.Alunos.Any(alubd => alubd.Id == idAluno))
                   .Select(bdDisc => new DisciplinaModel
                   {
                       Id = bdDisc.Id,
                       Nome = bdDisc.Nome,
                       Alunos = bdDisc.Alunos.Where(alubd => alubd.Id == idAluno).ToList()

                   })
                   .ToListAsync();

                response.Dados = disciplina;
                response.Mensagem = "Deu certo né";
            }
            catch (Exception)
            {

                throw;
            }
            return response;
        }
    }

}
