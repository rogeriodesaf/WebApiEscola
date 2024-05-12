using APIEscola.Dto.Alunos;
using APIEscola.Models;
using APIEscola.Models.Alunos;

namespace APIEscola.Repositorios.Services.Alunos
{
    public interface IAlunoInterface
    {    public  Task<ResponseModel<List<AlunoModel>>> getAlunos();
        public Task<ResponseModel<AlunoModel>> getAlunosPorId(int id);
        public Task<ResponseModel<List<AlunoModel>>> getAlunosPorDisciplinaId(int idDisciplina);
        public Task<ResponseModel<List<AlunoModel>>> postAlunos(AlunoCriacaoDto alunoCriacaoDto);
        public Task<ResponseModel<List<AlunoModel>>> putAlunos(AlunoEdicaoDto alunoEdicaoDto);  
        public Task<ResponseModel<List<AlunoModel>>> deleteAlunos(int id);

        public Task<ResponseModel<List<AlunoModel>>> AssociarAlunoADisciplinas(int alunoId, List<int> disciplinaIds);
        public Task<ResponseModel<List<AlunoModel>>> GetAllAlunosWithDisciplinasAsync();
    }

}
