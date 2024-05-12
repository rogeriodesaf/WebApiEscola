using APIEscola.Models.Alunos;
using APIEscola.Models.Professores;
using System.Text.Json.Serialization;

namespace APIEscola.Models.Disciplinas
{
    public class DisciplinaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
       [JsonIgnore]
        public ICollection<AlunoModel> Alunos { get; set; }
       
    }
}
