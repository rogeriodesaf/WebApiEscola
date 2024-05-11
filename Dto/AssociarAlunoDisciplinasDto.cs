namespace APIEscola.Dto
{
    public class AssociarAlunoDisciplinasDto
    {
        public int AlunoId { get; set; }
        public List<int> DisciplinaIds { get; set; }
    }
}
