using EditoraAcademia.Domain.Exceptions;
using EditoraAcademia.Domain.Features.Editoras;
using EditoraAcademia.Domain.Features.Livros;
using System;
using System.Collections.Generic;

namespace EditoraAcademia.App
{
    public class EditoraService
    {
        private IEditoraRepository _editoraRepository;

        public EditoraService(IEditoraRepository editoraRepository)
        {
            _editoraRepository = editoraRepository;
        }

        public void Add(Editora entidade)
        {
            entidade.Valida();

            bool editoraEncontrada = _editoraRepository.Existe(entidade.Nome);

            if (editoraEncontrada)
                throw new NomeDuplicadoException();

            _editoraRepository.Add(entidade);
        }

        public void Update(Editora entidade)
        {
            entidade.Valida();

            Editora editoraEncontrada = _editoraRepository.GetByName(entidade.Nome);
            if (editoraEncontrada != null)
            {
                if (editoraEncontrada.Id != entidade.Id)
                    throw new NomeDuplicadoException();
            }

            _editoraRepository.Update(entidade);
        }

        public void Delete(Editora entidade)
        {
            _editoraRepository.Delete(entidade.Id);
        }

        public Editora SelecionaPorId(int id)
        {
            return _editoraRepository.GetById(id);
        }

        public List<Editora> SelecionaTudo()
        {
            return _editoraRepository.GetAll();
        }

        public IList<Livro> GetLivrosFromEditoras(int id)
        {
            return _editoraRepository.GetLivrosFromEditoras(id);
        }
    }
}
