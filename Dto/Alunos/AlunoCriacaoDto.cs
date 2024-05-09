using APIEscola.VinculoDto;

namespace APIEscola.Dto.Alunos
{
    public class AlunoCriacaoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DisciplinaVinculoDTO DisciplinaCriacao { get; set; }

    }
}
