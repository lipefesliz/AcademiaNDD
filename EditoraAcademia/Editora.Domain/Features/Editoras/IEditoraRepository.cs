using EditoraAcademia.Domain.Base;
using EditoraAcademia.Domain.Features.Livros;
using System.Collections.Generic;

namespace EditoraAcademia.Domain.Features.Editoras
{
    public interface IEditoraRepository : IRepository<Editora>
    {
        bool Existe(string titulo);

        Editora GetByName(string nome);

        IList<Livro> GetLivrosFromEditoras(int id);
    }
}
