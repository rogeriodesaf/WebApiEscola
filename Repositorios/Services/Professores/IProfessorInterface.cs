using APIEscola.Dto.Professores;
using APIEscola.Models;
using APIEscola.Models.Professores;

namespace APIEscola.Repositorios.Services.Professores
{
    public interface IProfessorInterface
    {
        public Task<ResponseModel<List<ProfessoresModel>>> getProfessores();
        public Task<ResponseModel<ProfessoresModel>> getProfessorPorId(int id);
        public Task<ResponseModel<ProfessoresModel>> getProfessorPorDisciplinaId(int idDisciplina);
        public Task<ResponseModel<List<ProfessoresModel>>> postProfessor(ProfessorCriacaoDto professorCriacaoDto);
        public Task<ResponseModel<List<ProfessoresModel>>> putProfessor(ProfessorEdicaoDto professorEdicaoDto);
        public Task<ResponseModel<List<ProfessoresModel>>> deleteProfessor(int id);

        public Task<ResponseModel<List<ProfessoresModel>>> associarProfessorDisciplinaId(int idProfessor, List<int> disciplinaId);


    }
}
