using AndersonLiz.Agenda.Doamain;
using AndersonLiz.Agenda.Doamain.Features.Contatos;
using System;
using System.Collections.Generic;
using System.Data;

namespace AndersonLiz.Agenda.Infra.Data
{
    public class ContatoRepository : IContatoRepository
    {
        #region QUERYS

        private const string SqlInsereContato =
            @"INSERT INTO TBCONTATOS
                (NOME
                 ,EMAIL
                 ,DEPARTAMENTO
                 ,ENDERECO
                 ,TELEFONE)
            VALUES
                ({0}NOME
                 ,{0}EMAIL
                 ,{0}DEPARTAMENTO
                 ,{0}ENDERECO
                 ,{0}TELEFONE)";

        private const string SqlEditaContato =
            @"UPDATE TBCONTATOS
                SET
                    NOME = {0}NOME,
                    EMAIL = {0}EMAIL,
                    DEPARTAMENTO = {0}DEPARTAMENTO,
                    ENDERECO = {0}ENDERECO,
                    TELEFONE = {0}TELEFONE
                WHERE ID = {0}ID";

        private const string SqlDeletaContato =
           @"DELETE FROM TBCONTATOS
                WHERE ID = {0}ID";

        private const string SqlSelecionaTodosContatos =
           @"SELECT
                ID,
                NOME,
                EMAIL,
                DEPARTAMENTO,
                ENDERECO,
                TELEFONE
            FROM
                TBCONTATOS";

        private const string SqlSelecionaContatoPorId =
           @"SELECT
                ID,
                NOME,
                EMAIL,
                DEPARTAMENTO,
                ENDERECO,
                TELEFONE
            FROM
                TBCONTATOS
            WHERE ID = {0}ID";

        private const string SqlSelecionaContatoPorNome =
           @"SELECT
                ID,
                NOME,
                EMAIL,
                DEPARTAMENTO,
                ENDERECO,
                TELEFONE
            FROM
                TBCONTATOS
            WHERE NOME = {0}NOME";

        private const string SqlSelecionaContatoPorNomeMaisId =
           @"SELECT
                ID,
                NOME,
                EMAIL,
                DEPARTAMENTO,
                ENDERECO,
                TELEFONE
            FROM
                TBCONTATOS
            WHERE ID = {0}ID AND NOME = {0}NOME";

        private const string SqlVerificaDependencia =
           @"SELECT
                ID,
                CONTATOID,
                COMPROMISSOID
            FROM
                TBCOMPROMISSOSCONTATOS
            WHERE CONTATOID = {0}ID";

        #endregion QUERYS

        public Contato Add(Contato entidade)
        {
            entidade.Id = Db.Insert(SqlInsereContato, GetParametros(entidade));

            return entidade;
        }

        public void Delete(int id)
        {
            var parms = new Dictionary<string, object> { { "ID", id } };

            Db.Delete(SqlDeletaContato, parms);
        }

        public bool Existe(string nome)
        {
            var parms = new Dictionary<string, object> { { "NOME", nome } };

            var resultado = Db.Get(SqlSelecionaContatoPorNome, Converter, parms);

            return resultado != null;
        }

        public bool Existe(int id, string nome)
        {
            var parms = new Dictionary<string, object> { { "ID", id }, { "NOME", nome} };

            var resultado = Db.Get(SqlSelecionaContatoPorNomeMaisId, Converter, parms);

            return resultado != null;
        }

        public List<Contato> GetAll()
        {
            return Db.GetAll(SqlSelecionaTodosContatos, Converter);
        }

        public Contato GetById(int id)
        {
            var parms = new Dictionary<string, object> { { "ID", id } };

            return Db.Get(SqlSelecionaContatoPorId, Converter, parms);
        }

        public bool RegistroComDependencia(int id)
        {
            var parms = new Dictionary<string, object> { { "ID", id } };

            var resultado = Db.Get(SqlVerificaDependencia, ConverterCompromissosContatos, parms);

            return resultado != null;
        }

        public Contato Update(Contato entidade)
        {
            Db.Update(SqlEditaContato, GetParametros(entidade));

            return entidade;
        }

        private Dictionary<string, object> GetParametros(Contato contato)
        {
            return new Dictionary<string, object>
            {
                { "ID", contato.Id },
                { "NOME", contato.Nome },
                { "EMAIL", contato.Email },
                { "DEPARTAMENTO", contato.Departamento },
                { "ENDERECO", contato.Endereco },
                { "TELEFONE", contato.Telefone },
            };
        }

        private static Func<IDataReader, Contato> Converter = reader =>
          new Contato
          {
              Id = Convert.ToInt32(reader["ID"]),
              Nome = Convert.ToString(reader["NOME"]),
              Email = Convert.ToString(reader["EMAIL"]),
              Departamento = Convert.ToString(reader["DEPARTAMENTO"]),
              Endereco = Convert.ToString(reader["ENDERECO"]),
              Telefone = Convert.ToString(reader["TELEFONE"])
          };

        private static Func<IDataReader, Contato> ConverterCompromissosContatos = reader =>
            new Contato
            {
                Id = Convert.ToInt32(reader["ID"])
            };
    }
}
