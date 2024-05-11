using APIEscola.Models.Disciplinas;
using System.Text.Json.Serialization;

namespace APIEscola.Models.Alunos
{
    public class AlunoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
       // [JsonIgnore]
        public ICollection<DisciplinaModel> Disciplinas { get; set; }
    }

   
}
