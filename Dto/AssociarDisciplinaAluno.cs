namespace APIEscola.Dto
{
    public class AssociarDisciplinaAluno
    {
        public string IdAluno { get; set; }
        public List<int> IdDisciplinas { get; set; }
    }
}
