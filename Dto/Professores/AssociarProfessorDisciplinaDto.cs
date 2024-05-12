namespace APIEscola.Dto.Professores
{
    public class AssociarProfessorDisciplinaDto
    {
        public int ProfessorId { get; set; }
        public List<int> DisciplinaId { get; set; }
    }
}
