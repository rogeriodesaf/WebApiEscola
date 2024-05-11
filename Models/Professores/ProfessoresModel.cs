using APIEscola.Models.Disciplinas;

namespace APIEscola.Models.Professores
{
    public class ProfessoresModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<DisciplinaModel> Disciplina { get; set; }
    }
}
