using APIEscola.Models.Alunos;
using APIEscola.Models.Disciplinas;
using Microsoft.EntityFrameworkCore;

namespace APIEscola.Data
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)  
        {
           
    }
        public DbSet<AlunoModel> Aluno { get; set; }
        public DbSet<DisciplinaModel> Disciplina { get; set; }

    }
}
