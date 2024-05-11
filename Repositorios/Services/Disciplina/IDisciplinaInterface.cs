using APIEscola.Dto.Alunos;
using APIEscola.Dto.Disciplinas;
using APIEscola.Models;
using APIEscola.Models.Alunos;
using APIEscola.Models.Disciplinas;

namespace APIEscola.Repositorios.Services.Disciplina
{
    public interface IDisciplinaInterface
    {    public  Task<ResponseModel<List<DisciplinaModel>>> getDisciplina();
        public Task<ResponseModel<DisciplinaModel>> getDisciplinaPorId(int id);
        public Task<ResponseModel<List<DisciplinaModel>>> getDisciplinaPorAlunoId(int idDisciplina);
        public Task<ResponseModel<List<DisciplinaModel>>> postDisciplina(DisciplinaCriacaoDto disciplinaCriacaoDto);
        public Task<ResponseModel<List<DisciplinaModel>>> putDisciplina(DisciplinaEdicaoDto disciplinaEdicaoDto);  
        public Task<ResponseModel<List<DisciplinaModel>>> deleteDisciplina(int id);
    }
}
