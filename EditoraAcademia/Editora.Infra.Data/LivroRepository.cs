using EditoraAcademia.Domain.Features.Livros;
using System;
using System.Collections.Generic;
using System.Data;

namespace EditoraAcademia.Infra.Data
{
    public class LivroRepository : ILivroRepository
    {
        #region QUERYS

        private const string SqlInsereLivro =
            @"INSERT INTO TBLIVROS
                (TITULO
                 ,ANO
                 ,AUTOR
                 ,VOLUME)
            VALUES
                ({0}TITULO
                 ,{0}ANO
                 ,{0}AUTOR
                 ,{0}VOLUME)";

        private const string SqlEditaLivro =
            @"UPDATE TBLIVROS
                SET
                    TITULO = {0}TITULO,
                    ANO = {0}ANO,
                    AUTOR = {0}AUTOR,
                    VOLUME = {0}VOLUME
                WHERE ID = {0}ID";

        private const string SqlDeletaLivro =
           @"DELETE FROM TBLIVROS
                WHERE ID = {0}ID";

        private const string SqlSelecionaTodosLivros =
           @"SELECT
                ID,
                TITULO,
                ANO,
                AUTOR,
                VOLUME
            FROM
                TBLIVROS ORDER BY TITULO";

        private const string SqlSelecionaLivroPorId =
           @"SELECT
                ID,
                TITULO,
                ANO,
                AUTOR,
                VOLUME
            FROM
                TBLIVROS
            WHERE ID = {0}ID";

        private const string SqlSelecionaLivroPorTitulo =
           @"SELECT
                ID,
                TITULO,
                ANO,
                AUTOR,
                VOLUME
            FROM
                TBLIVROS
            WHERE TITULO = {0}TITULO";

        private const string SqlVerificaDependencia =
           @"SELECT
                ID,
                LIVROID,
                EDITORAID
            FROM
                TBEDITORASLIVROS
            WHERE LIVROID = {0}ID";

        #endregion QUERYS

        public Livro Add(Livro entidade)
        {
            entidade.Id = Db.Insert(SqlInsereLivro, GetParametros(entidade));

            return entidade;
        }

        public void Delete(int id)
        {
            var parms = new Dictionary<string, object> { { "ID", id } };

            Db.Delete(SqlDeletaLivro, parms);
        }

        public Livro GetByTitulo(string titulo)
        {
            var parms = new Dictionary<string, object> { { "TITULO", titulo } };

            var resultado = Db.Get(SqlSelecionaLivroPorTitulo, Converter, parms);

            return resultado;
        }

        public bool Existe(string titulo)
        {
            var parms = new Dictionary<string, object> { { "TITULO", titulo } };

            var resultado = Db.Get(SqlSelecionaLivroPorTitulo, Converter, parms);

            return resultado != null;
        }

        public List<Livro> GetAll()
        {
            return Db.GetAll(SqlSelecionaTodosLivros, Converter);
        }

        public Livro GetById(int id)
        {
            var parms = new Dictionary<string, object> { { "ID", id } };

            return Db.Get(SqlSelecionaLivroPorId, Converter, parms);
        }

        public bool RegistroComDependencia(int id)
        {
            var parms = new Dictionary<string, object> { { "ID", id } };

            var resultado = Db.Get(SqlVerificaDependencia, ConverterEditorasLivros, parms);

            return resultado != null;
        }

        public Livro Update(Livro entidade)
        {
            Db.Update(SqlEditaLivro, GetParametros(entidade));

            return entidade;
        }

        private Dictionary<string, object> GetParametros(Livro livro)
        {
            return new Dictionary<string, object>
            {
                { "ID", livro.Id },
                { "TITULO", livro.Titulo },
                { "ANO", livro.Ano },
                { "AUTOR", livro.Autor},
                { "VOLUME", livro.Volume},
            };
        }

        private static Func<IDataReader, Livro> Converter = reader =>
          new Livro
          {
              Id = Convert.ToInt32(reader["ID"]),
              Titulo = Convert.ToString(reader["TITULO"]),
              Ano = Convert.ToString(reader["ANO"]),
              Autor = Convert.ToString(reader["AUTOR"]),
              Volume = Convert.ToString(reader["VOLUME"]),
          };

        private static Func<IDataReader, Livro> ConverterEditorasLivros = reader =>
            new Livro
            {
                Id = Convert.ToInt32(reader["ID"])
            };
    }
}
