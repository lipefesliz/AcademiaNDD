using EditoraAcademia.Domain.Base;

namespace EditoraAcademia.Domain.Features.Livros
{
    public interface ILivroRepository : IRepository<Livro>
    {
        bool Existe(string nome);

        Livro GetByTitulo(string titulo);

        bool RegistroComDependencia(int id);
    }
}
