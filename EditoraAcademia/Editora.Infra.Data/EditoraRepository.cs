using EditoraAcademia.Domain.Features.Editoras;
using EditoraAcademia.Domain.Features.Livros;
using System;
using System.Collections.Generic;
using System.Data;

namespace EditoraAcademia.Infra.Data
{
    public class EditoraRepository : IEditoraRepository
    {
        #region QUERYS

        private const string SqlInsereEditora =
            @"INSERT INTO TBEDITORAS
                (NOME
                 ,ENDERECO
                 ,TELEFONE)
            VALUES
                ({0}NOME
                 ,{0}ENDERECO
                 ,{0}TELEFONE)";

        private const string SqlEditaEditora =
            @"UPDATE TBEDITORAS
                SET
                    NOME = {0}NOME,
                    ENDERECO = {0}ENDERECO,
                    TELEFONE = {0}TELEFONE
                WHERE ID = {0}ID";

        private const string SqlDeletaEditora =
           @"DELETE FROM TBEDITORAS
                WHERE ID = {0}ID";

        private const string SqlDeletaEditorasLivros =
            @"DELETE FROM TBEDITORASLIVROS
                WHERE EDITORAID = {0}ID";

        private const string SqlSelecionaTodosEditoras =
           @"SELECT
                ID,
                NOME,
                ENDERECO,
                TELEFONE
            FROM
                TBEDITORAS ORDER BY NOME";

        private const string SqlSelecionaEditoraPorId =
           @"SELECT
                ID,
                NOME,
                ENDERECO,
                TELEFONE
            FROM
                TBEDITORAS
            WHERE ID = {0}ID";

        private const string SqlSelecionaEditoraPorNome =
           @"SELECT
                ID,
                NOME,
                ENDERECO,
                TELEFONE
            FROM
                TBEDITORAS
            WHERE NOME = {0}NOME";

        private const string SqlInsereEditoraLivro =
            @"INSERT INTO TBEDITORASLIVROS
                (LIVROID
                 ,EDITORAID)
            VALUES
                ({0}LIVROID
                 ,{0}EDITORAID)";

        private const string SqlEditaEditoraLivro =
            @"UPDATE TBEDITORASLIVROS
                SET
                    LIVROID = {0}LIVROID,
                    EDITORAID = {0}EDITORAID
                WHERE ID = {0}ID";

        private const string SqlSelecionaTodosLivros =
            @"SELECT
                TBLivros.*
            FROM
                TBEditoras
                INNER JOIN TBEditorasLivros ON TBEditoras.Id = TBEditorasLivros.EditoraID
                INNER JOIN TBLivros ON TBEditorasLivros.LivroID = TBLivros.Id
                WHERE TBEditoras.Id = {0}ID";

        #endregion QUERYS

        public Editora Add(Editora entidade)
        {
            entidade.Id = Db.Insert(SqlInsereEditora, GetParametros(entidade));

            foreach (var item in entidade.Livros)
            {
                Db.Insert(SqlInsereEditoraLivro, GetParametros(item.Id, entidade.Id));
            }

            return entidade;
        }

        public void Delete(int id)
        {
            var parms = new Dictionary<string, object> { { "ID", id } };

            Db.Delete(SqlDeletaEditorasLivros, parms);
            Db.Delete(SqlDeletaEditora, parms);
        }

        public Editora GetByName(string nome)
        {
            var parms = new Dictionary<string, object> { { "NOME", nome } };

            var resultado = Db.Get(SqlSelecionaEditoraPorNome, Converter, parms);

            return resultado;
        }

        public bool Existe(string nome)
        {
            var parms = new Dictionary<string, object> { { "NOME", nome } };

            var resultado = Db.Get(SqlSelecionaEditoraPorNome, Converter, parms);

            return resultado != null;
        }

        public List<Editora> GetAll()
        {
            return Db.GetAll(SqlSelecionaTodosEditoras, Converter);
        }

        public IList<Livro> GetLivrosFromEditoras(int id)
        {
            var parms = new Dictionary<string, object> { { "ID", id } };

            return Db.GetAll(SqlSelecionaTodosLivros, ConverterLivro, parms);
        }

        public Editora GetById(int id)
        {
            var parms = new Dictionary<string, object> { { "ID", id } };

            return Db.Get(SqlSelecionaEditoraPorId, Converter, parms);
        }

        public Editora Update(Editora entidade)
        {
            Db.Update(SqlEditaEditora, GetParametros(entidade));

            var parms = new Dictionary<string, object> { { "ID", entidade.Id } };

            foreach (var item in entidade.Livros)
            {
                Db.Delete(SqlDeletaEditorasLivros, parms);
            }

            foreach (var item in entidade.Livros)
            {
                Db.Insert(SqlInsereEditoraLivro, GetParametros(item.Id, entidade.Id));
            }

            return entidade;
        }

        private Dictionary<string, object> GetParametros(Editora entidade)
        {
            return new Dictionary<string, object>
            {
                { "ID", entidade.Id },
                { "NOME", entidade.Nome},
                { "ENDERECO", entidade.Endereco},
                { "TELEFONE", entidade.Telefone},
            };
        }

        private Dictionary<string, object> GetParametros(int livroId, int editoraId)
        {
            return new Dictionary<string, object>
            {
                { "LIVROID", livroId},
                { "EDITORAID", editoraId}
            };
        }

        private static Func<IDataReader, Editora> Converter = reader =>
          new Editora
          {
              Id = Convert.ToInt32(reader["ID"]),
              Nome = Convert.ToString(reader["NOME"]),
              Endereco = Convert.ToString(reader["ENDERECO"]),
              Telefone = Convert.ToString(reader["TELEFONE"]),
          };

        private static Func<IDataReader, Livro> ConverterLivro = reader =>
          new Livro
          {
              Id = Convert.ToInt32(reader["ID"]),
              Titulo = Convert.ToString(reader["TITULO"]),
              Ano = Convert.ToString(reader["ANO"]),
              Autor = Convert.ToString(reader["AUTOR"]),
              Volume = Convert.ToString(reader["VOLUME"]),
          };
    }
}
