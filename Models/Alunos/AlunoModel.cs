using APIEscola.Models.Disciplinas;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace APIEscola.Models.Alunos
{
    public class AlunoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [JsonIgnore]
        public ICollection<DisciplinaModel> Disciplinas { get; set; }

        [JsonProperty("Disciplinas")]  // Renomeia a propriedade na serialização JSON
        public List<string> NomesDisciplinas
        {
            get
            {
                return Disciplinas?.Select(d => d.Nome).ToList();
            }
        }
    }

   
}
