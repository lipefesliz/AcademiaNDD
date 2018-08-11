using EditoraAcademia.Domain.Features.Livros;
using EditoraAcademia.Domain.Exceptions;
using System.Collections.Generic;

namespace EditoraAcademia.App
{
    public class LivroService
    {
        private ILivroRepository _livroRepository;

        public LivroService(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public void Add(Livro entidade)
        {
            entidade.Valida();

            bool livroEncontrado = _livroRepository.Existe(entidade.Titulo);

            if (livroEncontrado)
                throw new NomeDuplicadoException();

            _livroRepository.Add(entidade);
        }

        public void Update(Livro entidade)
        {
            entidade.Valida();

            Livro livroEncontrado = _livroRepository.GetByTitulo(entidade.Titulo);
            if (livroEncontrado.Id != entidade.Id)
                throw new NomeDuplicadoException();

            _livroRepository.Update(entidade);
        }

        public void Delete(Livro entidade)
        {
            if (RegistroComDependecia(entidade.Id))
                throw new DependenciaException();

            _livroRepository.Delete(entidade.Id);
        }

        private bool RegistroComDependecia(int id)
        {
            return _livroRepository.RegistroComDependencia(id);
        }

        public Livro SelecionaPorId(int id)
        {
            return _livroRepository.GetById(id);
        }

        public List<Livro> SelecionaTudo()
        {
            return _livroRepository.GetAll();
        }
    }
}
