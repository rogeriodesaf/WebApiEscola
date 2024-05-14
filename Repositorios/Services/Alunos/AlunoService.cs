using APIEscola.Data;
using APIEscola.Dto.Alunos;
using APIEscola.Models;
using APIEscola.Models.Alunos;
using Microsoft.EntityFrameworkCore;

namespace APIEscola.Repositorios.Services.Alunos
{
    public class AlunoService : IAlunoInterface
    {
        private readonly AppDbContext _context;
        public AlunoService(AppDbContext context)
        {
            _context = context;
        }
    
        public async Task<ResponseModel<List<AlunoModel>>> deleteAlunos(int id)
        {
            ResponseModel<List<AlunoModel>> response = new ResponseModel<List<AlunoModel>>();
            try
            {
                var alunoDeletado = await _context.Aluno
                    .FirstOrDefaultAsync(a => a.Id == id);
                if(alunoDeletado != null)
                {
                    _context.Aluno.Remove(alunoDeletado);
                    await _context.SaveChangesAsync();
                    
                    response.Dados = await _context.Aluno.Include(a =>a.Disciplinas).ToListAsync();
                    response.Mensagem = "Sucess";
                    
                }

                return response;
            }
            catch (Exception ex)
            {

                response.Mensagem = "Erro"+ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async  Task<ResponseModel<List<AlunoModel>>> getAlunos()
        {
            ResponseModel<List<AlunoModel>> response = new ResponseModel<List<AlunoModel>>();
            try
            {
                var alunos = await _context.Aluno
              
                    .ToListAsync();
                if(alunos is null)
                {
                    response.Mensagem = "";
                    response.Status = false;
                    return response;
                }



                response.Dados = alunos;
                    
                   
                response.Mensagem = "Sucess";
                return response;
            }
            catch (Exception ex)
            {

                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<AlunoModel>>> getAlunosPorDisciplinaId(int idDisciplina)
        {
            ResponseModel<List<AlunoModel>> response = new ResponseModel<List<AlunoModel>>();
            try
            {
                /*var alunos = await _context.Aluno.Include(a=>a.Disciplinas)
                     .FirstOrDefaultAsync(b=>b.Id == idDisciplina);


                response.Dados = await _context.Aluno.Include(a => a.Disciplinas)
                    
                    .ToListAsync();
                response.Mensagem = "Dados retornados com sucesso";*/

                var alunos = await _context.Aluno
            .Where(a => a.Disciplinas.Any(d => d.Id == idDisciplina)) // Filtra pelos alunos associados à disciplina desejada
            .Select(a => new AlunoModel
            {
                Id = a.Id,
                Nome = a.Nome,
                Disciplinas = a.Disciplinas.Where(d => d.Id == idDisciplina).ToList() // Filtra e inclui apenas a disciplina desejada para cada aluno
            })
            .ToListAsync();

                /* response.Dados = await _context.Aluno.Include(a => a.Disciplinas)
                     .ToListAsync();*/
                response.Dados = alunos;
                response.Mensagem = "Dados retornados com sucesso";
            }
            catch (Exception)
            {

                throw;
            }
            return response;

            /*
             _context.Aluno: Aqui, _context representa o contexto do banco de
            dados que está sendo usado na aplicação. O _context.Aluno refere-se à 
            tabela (ou entidade) de Alunos no banco de dados. Isso permite que possamos 
            consultar os alunos diretamente no banco de dados usando o Entity Framework Core.
a => ...: O a é uma variável de iteração que representa cada aluno ( Aluno) sendo considerada
            durante a execução da consulta. No contexto do LINQ (Language Integrated Query),
            aé uma referência a cada objeto Aluno conforme a expressão lambda ( a => ...) é aplicada.
Where(a => a.Disciplinas.Any(d => d.Id == idDisciplina)):
Aqui estamos usando o método Where para filtrar os alunos ( a) com base em uma condição.
            A expressão a.Disciplinas.Any(d => d.Id == idDisciplina)significa que queremos
            apenas os alunos que possuem pelo menos uma disciplina cuja Id
            correspondência corresponde ao idDisciplinaque estamos especificando.
            O método Any verifica se pelo menos um elemento na coleção 
            ( Disciplinasdo aluno a) atende à condição fornecida.
Select(a => new AlunoModel { ... }):
O método Selecté usado para transformar cada aluno ( a) que 
            passou no filtro Whereem uma nova forma de dados, 
            especificamente em uma instância de AlunoModel.
Aqui, estamos criando uma nova instância AlunoModelpara cada 
            aluno selecionado ( a). As propriedades Ide Nomedo AlunoModelsão cumpridas com o Ide o Nomedo aluno a.
Disciplinas = a.Disciplinas.Where(d => d.Id == idDisciplina).ToList():
Dentro disso Select, estamos preenchendo a propriedade Disciplinasde cada um AlunoModel.
a.Disciplinas.Where(d => d.Id == idDisciplina)filtrar as disciplinas associadas ao aluno a,
            mantendo apenas aquelas cujo Idcorresponda ao idDisciplinadesejado.
O método ToList()converte o resultado do filtro em uma lista de disciplinas e 
            atribui essa lista à propriedade Disciplinasdo AlunoModel.
             */
        }

        public async Task<ResponseModel<AlunoModel>>getAlunosPorId(int id)
        {
           var response = new ResponseModel<AlunoModel>();
            try

            {
                var aluno = await _context.Aluno
                    .FirstOrDefaultAsync(a => a.Id == id);
                if(aluno != null)
                {
                    response.Dados = aluno;
                    response.Mensagem = "Dados retornados com sucess";

                }
            }
            catch (Exception ex)
            {

                response.Mensagem = "Deu errado" + ex.Message;
                response.Status = false;
                return response;
            }
            return response;
        }

        public async Task<ResponseModel<List<AlunoModel>>> postAlunos(AlunoCriacaoDto alunoCriacaoDto)
        {
            ResponseModel<List<AlunoModel>> response = new ResponseModel<List<AlunoModel>>();
            try
            {
                
              
              
                    var alunoCriado = new AlunoModel();
                    {
                        alunoCriado.Nome = alunoCriacaoDto.Nome;   
                    }


                    _context.Aluno.Add(alunoCriado);
                    await _context.SaveChangesAsync();

                    response.Dados = await _context.Aluno.ToListAsync();
                    response.Mensagem = "Dados salvos com sucesso!";
                    return response;
               
               
                    response.Mensagem = "Não foi possivel criar aluno!";
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

        public Task<ResponseModel<List<AlunoModel>>> putAlunos(AlunoEdicaoDto alunoEdicaoDto)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<AlunoModel>>> AssociarAlunoADisciplinas(int alunoId, List<int> disciplinaIds)
        {
            ResponseModel<List<AlunoModel>> response = new ResponseModel<List<AlunoModel>>();

            try
            {
                var aluno = await _context.Aluno
                .Include(a => a.Disciplinas)
                .FirstOrDefaultAsync(a => a.Id == alunoId);

                if (aluno == null)
                {
                    response.Mensagem = $"Aluno com ID {alunoId}não encontrado.";
                    return response;
                }

                var disciplinas = await _context.Disciplina
                    .Where(d => disciplinaIds.Contains(d.Id))
                    .ToListAsync();

                foreach (var disciplina in disciplinas)
                {
                    aluno.Disciplinas.Add(disciplina);
                }

                await _context.SaveChangesAsync();
                response.Dados = await _context.Aluno
                    .Include(a=>a.Disciplinas).ToListAsync();
                response.Mensagem = "Alunos associados as Disciplinas com sucesso";
                
            }
            catch (Exception ex)
            {

                response.Mensagem = ex.Message;
                return response;
            }
            return response;

        }

        public async Task<ResponseModel<List<AlunoModel>>> GetAllAlunosWithDisciplinasAsync()
        {
            var response = new ResponseModel<List<AlunoModel>>();
            try
            {
                var alunosComDisciplinas = await _context.Aluno
            .Include(a => a.Disciplinas)  // Incluir as disciplinas relacionadas com cada aluno
               
            .ToListAsync();

                response.Dados = alunosComDisciplinas;
                response.Mensagem = "Legal, tá dando certo!";

            }
            catch (Exception ex)
            {

                response.Mensagem = "droga " + ex.Message;
                response.Status = false;
                return response;
            }
            return response;
        }

    }
}
//GetAllAlunosWithDisciplinasAsync