using System;
using System.Collections.Generic;
using System.Data;
using AndersonLiz.Agenda.Doamain;
using AndersonLiz.Agenda.Doamain.Features.Compromissos;

namespace AndersonLiz.Agenda.Infra.Data
{
    public class CompromissoRepository : ICompromissoRepository
    {
        #region QUERYS

        private const string SqlInsereCompromisso =
            @"INSERT INTO TBCOMPROMISSOS
                (ASSUNTO
                 ,LOCAL
                 ,INICIO
                 ,TERMINO)
            VALUES
                ({0}ASSUNTO
                 ,{0}LOCAL
                 ,{0}INICIO
                 ,{0}TERMINO)";

        private const string SqlEditaCompromisso =
            @"UPDATE TBCOMPROMISSOS
                SET
                    ASSUNTO = {0}ASSUNTO,
                    LOCAL = {0}LOCAL,
                    INICIO = {0}INICIO,
                    TERMINO = {0}TERMINO
                WHERE ID = {0}ID";

        private const string SqlDeletaCompromisso =
           @"DELETE FROM TBCOMPROMISSOS
                WHERE ID = {0}ID";

        private const string SqlDeletaCompromissosContatos =
            @"DELETE FROM TBCOMPROMISSOSCONTATOS
                WHERE COMPROMISSOID = {0}ID";

        private const string SqlSelecionaTodosCompromissos =
           @"SELECT
                ID,
                ASSUNTO,
                LOCAL,
                INICIO,
                TERMINO
            FROM
                TBCOMPROMISSOS ORDER BY INICIO";

        private const string SqlSelecionaCompromissoPorId =
           @"SELECT
                ID,
                ASSUNTO,
                LOCAL,
                INICIO,
                TERMINO
            FROM
                TBCOMPROMISSOS
            WHERE ID = {0}ID";

        private const string SqlSelecionaCompromissoPorHorario =
           @"SELECT
                ID,
                ASSUNTO,
                LOCAL,
                INICIO,
                TERMINO
            FROM
                TBCOMPROMISSOS
            WHERE CAST(INICIO AS DATE) = CAST({0}INICIO AS DATE)";

        private const string SqlSelecionaCompromissoPorHorarioMaisId =
            @"SELECT
                ID,
                ASSUNTO,
                LOCAL,
                INICIO,
                TERMINO
            FROM
                TBCOMPROMISSOS
            WHERE ID = {0}ID AND CAST(INICIO AS DATE) = CAST({0}INICIO AS DATE)";

        private const string SqlInsereCompromissoContato =
            @"INSERT INTO TBCOMPROMISSOSCONTATOS
                (CONTATOID
                 ,COMPROMISSOID)
            VALUES
                ({0}CONTATOID
                 ,{0}COMPROMISSOID)";

        private const string SqlEditaCompromissoContato =
            @"UPDATE TBCOMPROMISSOSCONTATOS
                SET
                    CONTATOID = {0}CONTATOID,
                    COMPROMISSOID = {0}COMPROMISSOID
                WHERE ID = {0}ID";

        private const string SqlSelecionaTodosContatos =
            @"SELECT
                TBContatos.*
            FROM
                TBCompromissos
                INNER JOIN TBCompromissosContatos ON TBCompromissos.Id = TBCompromissosContatos.CompromissoID
                INNER JOIN TBContatos ON TBCompromissosContatos.ContatoID = TBContatos.Id
                WHERE TBCompromissos.Id = {0}ID";

        #endregion QUERYS

        public Compromisso Add(Compromisso entidade)
        {
            entidade.Id = Db.Insert(SqlInsereCompromisso, GetParametros(entidade));

            foreach (var item in entidade.Contatos)
            {
                Db.Insert(SqlInsereCompromissoContato, GetParametros(item.Id, entidade.Id));
            }

            return entidade;
        }

        public void Delete(int id)
        {
            var parms = new Dictionary<string, object> { { "ID", id } };

            Db.Delete(SqlDeletaCompromissosContatos, parms);
            Db.Delete(SqlDeletaCompromisso, parms);
        }

        public bool Existe(DateTime inicio)
        {
            var parms = new Dictionary<string, object> { { "INICIO", inicio.Date } };

            var resultado = Db.Get(SqlSelecionaCompromissoPorHorario, Converter, parms);

            return resultado != null;
        }

        public bool Existe(int id, DateTime inicio)
        {
            var parms = new Dictionary<string, object> { { "ID", id }, { "INICIO", inicio.Date } };

            var resultado = Db.Get(SqlSelecionaCompromissoPorHorarioMaisId, Converter, parms);

            return resultado != null;
        }

        public List<Compromisso> GetAll()
        {
            return Db.GetAll(SqlSelecionaTodosCompromissos, Converter);
        }

        public IList<Contato> GetContatosFromCompromissos(int id)
        {
            var parms = new Dictionary<string, object> { { "ID", id } };

            return Db.GetAll(SqlSelecionaTodosContatos, ConverterContato, parms);
        }

        public Compromisso GetById(int id)
        {
            var parms = new Dictionary<string, object> { { "ID", id } };

            return Db.Get(SqlSelecionaCompromissoPorId, Converter, parms);
        }

        public Compromisso Update(Compromisso entidade)
        {
            Db.Update(SqlEditaCompromisso, GetParametros(entidade));

            var parms = new Dictionary<string, object> { { "ID", entidade.Id } };

            foreach (var item in entidade.Contatos)
            {
                Db.Delete(SqlDeletaCompromissosContatos, parms);
            }

            foreach (var item in entidade.Contatos)
            {
                Db.Insert(SqlInsereCompromissoContato, GetParametros(item.Id, entidade.Id));
            }

            return entidade;
        }

        private Dictionary<string, object> GetParametros(Compromisso entidade)
        {
            return new Dictionary<string, object>
            {
                { "ID", entidade.Id },
                { "ASSUNTO", entidade.Assunto},
                { "LOCAL", entidade.Local},
                { "INICIO", entidade.Inicio},
                { "TERMINO", entidade.Termino},
            };
        }

        private Dictionary<string, object> GetParametros(int contatoId, int compromissoId)
        {
            return new Dictionary<string, object>
            {
                { "CONTATOID", contatoId},
                { "COMPROMISSOID", compromissoId}
            };
        }

        private static Func<IDataReader, Compromisso> Converter = reader =>
          new Compromisso
          {
              Id = Convert.ToInt32(reader["ID"]),
              Assunto = Convert.ToString(reader["ASSUNTO"]),
              Local = Convert.ToString(reader["LOCAL"]),
              Inicio = Convert.ToDateTime(reader["INICIO"]),
              Termino = Convert.ToDateTime(reader["TERMINO"])
          };

        private static Func<IDataReader, Contato> ConverterContato = reader =>
          new Contato
          {
              Id = Convert.ToInt32(reader["ID"]),
              Nome = Convert.ToString(reader["NOME"]),
              Email = Convert.ToString(reader["EMAIL"]),
              Departamento = Convert.ToString(reader["DEPARTAMENTO"]),
              Endereco = Convert.ToString(reader["ENDERECO"]),
              Telefone = Convert.ToString(reader["TELEFONE"])
          };
    }
}
