using GeradorTestes.Domain;
using GeradorTestes.Infra.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorTestes.Infra
{

    public class MateriaDAO
    {
        #region SCRIPTS SQL
        private const string _sqlInsert = "INSERT INTO TBMaterias (Nome, SerieID, DisciplinaID) VALUES ({0}Nome, {0}SerieID, {0}DisciplinaID)";

        private const string _sqlSelectAll = "SELECT materias.ID , materias.Nome, materias.SerieID, series.Serie , materias.DisciplinaID, disciplina.Nome as 'disciplinaNome' FROM TBMaterias as materias"
                                            + " inner join TBSeries as series on series.ID = materias.SerieID"
                                             + "   inner join TBDisciplinas as disciplina on disciplina.ID = materias.DisciplinaID"
                                                + " group by disciplina.Nome , materias.ID , materias.Nome, materias.SerieID, series.Serie , materias.DisciplinaID "
                                                + "  order by disciplina.Nome, materias.Nome ";

        private const string _sqlUpdate = "UPDATE TBMaterias SET Nome = {0}Nome, SerieID = {0}SerieID, DisciplinaID = {0}DisciplinaID  WHERE ID = {0}ID ";

        private const string _sqlDelete = "DELETE FROM TBMaterias WHERE ID = {0}ID";

        private const string _sqlSelectByName = "SELECT * FROM TBMaterias WHERE Nome = {0}Nome and SerieID = {0}SerieID";

        public const string _sqlSelectByIDWhereSerieID = "SELECT * FROM TBMaterias WHERE SerieID = ({0}SerieID) ";

        public const string _sqlSelectByIDWhereDisciplinaID = "SELECT * FROM TBMaterias WHERE DisciplinaID = ({0}DisciplinaID) ";

        public const string _sqlSelectByIDWhereSerieIDAndDisciplinaID = "select * from TBMaterias {0}";
        #endregion

        public Materia Adicionar(Materia materia)
        {
            materia.ID = Db.Insert(_sqlInsert, Take2(materia));

            return materia;
        }

        public Materia Editar(Materia materia)
        {
            Db.Update(_sqlUpdate, Take2(materia));

            return materia;
        }
        public void Excluir(Materia materia)
        {
            Dictionary<string, object> parms = new Dictionary<string, object> { { "Id", materia.ID } };

            Db.Delete(_sqlDelete, parms);
        }

        public bool GetByName(Materia materia)
        {
            Dictionary<string, object> parms = new Dictionary<string, object> { { "Nome", materia.Nome }, { "SerieID", materia.serie.ID } };
            Materia m = Db.Get<Materia>(_sqlSelectByName, MakeGetByName, parms);

            if (m != null)
                return true;

            return false;
        }

        public bool GetByIDSerie(int id)
        {
            Dictionary<string, object> parms = new Dictionary<string, object> { { "SerieID", id } };

            Materia m = Db.Get<Materia>(_sqlSelectByIDWhereSerieID, MakeSerie, parms);

            if (m != null)
                return true;

            return false;
        }

        public IList<Materia> GetByIDSerieAndDisciplina(Serie serie = null, Disciplina disciplina = null)
        {
            Dictionary<string, object> parms;
            string where;
            if (serie.Nome != "" && disciplina.Nome == "")
            {
                parms = new Dictionary<string, object> { { "SerieNome", serie.Nome }, { "DisciplinaNome", disciplina.Nome } };
                where = "where SerieID in (select ID from TBSeries where Serie = {0}SerieNome) and DisciplinaID in (select ID from TBDisciplinas where Nome like '%%')";
            }
            else if (serie.Nome == "" && disciplina.Nome != "")
            {
                parms = new Dictionary<string, object> { { "SerieNome", serie.Nome }, { "DisciplinaNome", disciplina.Nome } };
                where = "where SerieID in (select ID from TBSeries where Serie like '%%') and DisciplinaID in (select ID from TBDisciplinas where Nome = {0}DisciplinaNome)";
            }
            else
            {
                parms = new Dictionary<string, object> { { "SerieNome", serie.Nome }, { "DisciplinaNome", disciplina.Nome } };
                where = "where SerieID in (select ID from TBSeries where Serie = {0}SerieNome) and DisciplinaID in (select ID from TBDisciplinas where Nome = {0}DisciplinaNome)";
            }
            string sql = string.Format(_sqlSelectByIDWhereSerieIDAndDisciplinaID, where);
            return Db.GetAll<Materia>(sql, MakeMateria, parms);
        }

        private static Func<IDataReader, Materia> MakeMateria = reader =>
            new Materia
            {
                ID = Convert.ToInt32(reader["ID"]),
                Nome = Convert.ToString(reader["Nome"]),
                serie = new Serie
                {
                    ID = Convert.ToInt32(reader["SerieID"])
                },
                disciplina = new Disciplina
                {
                    ID = Convert.ToInt32(reader["DisciplinaID"])
                }

            };
        private static Func<IDataReader, Materia> MakeSerie = reader =>
           new Materia
           {
               ID = Convert.ToInt32(reader["SerieID"])

           };

        public bool GetByIDDiciplina(int id)
        {
            Dictionary<string, object> parms = new Dictionary<string, object> { { "DisciplinaID", id } };

            Materia s = Db.Get<Materia>(_sqlSelectByIDWhereDisciplinaID, MakeDisciplina, parms);

            if (s != null)
                return true;

            return false;
        }

        private static Func<IDataReader, Materia> MakeDisciplina = reader =>
           new Materia
           {
               ID = Convert.ToInt32(reader["SerieID"])

           };

        private Dictionary<string, object> Take2(Materia materia)
        {
            return new Dictionary<string, object>
            {
                { "ID", materia.ID },
                { "Nome", materia.Nome },
                { "SerieID", materia.serie.ID },
                { "DisciplinaID", materia.disciplina.ID }
            };
        }

        public IList<Materia> GetAll()
        {
            return Db.GetAll<Materia>(_sqlSelectAll, Make);
        }

        private static Func<IDataReader, Materia> Make = reader =>
          new Materia
          {
              ID = Convert.ToInt32(reader["ID"]),
              Nome = Convert.ToString(reader["Nome"]),
              serie = new Serie
              {
                  ID = Convert.ToInt32(reader["SerieID"]),
                  Nome = Convert.ToString(reader["Serie"]),
              },
              disciplina = new Disciplina
              {
                  ID = Convert.ToInt32(reader["disciplinaID"]),
                  Nome = Convert.ToString(reader["disciplinaNome"])
              }

          };



        private static Func<IDataReader, Materia> MakeGetByName = reader =>
         new Materia
         {
             ID = Convert.ToInt32(reader["ID"]),
             Nome = Convert.ToString(reader["Nome"]),
             serie = new Serie
             {
                 ID = Convert.ToInt32(reader["SerieID"]),
             }

         };


    }
}
