using System.Linq;
using CursoOnline.Dominio.Alunos;

namespace CursoOnline.Dados.Repositorios
{
    public class AlunoRepositorio : RepositorioBase<Aluno>, IAlunoRepositorio
    {
        public AlunoRepositorio(ApplicationDbContext context) : base(context)
        {
            
        }

        public Aluno ObterPeloCpf(string cpf)
        {
            var entidade = Context.Set<Aluno>().Where(c => c.Nome.Contains(cpf));
            if (entidade.Any())
                return entidade.First();
            return null;
        }
    }
}