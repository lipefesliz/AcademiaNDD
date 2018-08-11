using Mercado.Dominio;
using Mercado.Dominio.Interfaces;
using Mercado.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.Serviço
{
    public class ProdutoService : IProdutoService
    {
        private IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public IList<Produto> GetByName(string nome)
        {
            try
            {
                return _repository.BuscarPorNome(nome);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Add(Produto entidade)
        {
            try
            {
                entidade.Validacao();
                if (_repository.BuscarPorNome(entidade.Nome).Count == 0)
                {
                    _repository.Adicionar(entidade);
                }
                else
                {
                    throw new Exception("O Produto já existe!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Produto entidade)
        {
            try
            {
                entidade.Validacao();
                var pro = _repository.BuscarPorNome(entidade.Nome);
                if (entidade.Equals(pro))
                {
                    return;
                }
                else
                {
                    if (pro.Count == 0) // || pro.Id == produto.Id
                    {
                        _repository.Editar(entidade);
                    }
                    else
                    {
                        throw new Exception("Ja existe um produto com esse nome!");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(Produto entidade)
        {
            try
            {
                entidade.Validacao();
                _repository.Excluir(entidade);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<Produto> GetAll()
        {
            try
            {
                return _repository.BuscarTodos();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
