using GeradorTestes.Domain;
using GeradorTestes.Infra.Database;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorTestes.Infra
{
    public class SerieDAO
    {
        #region SCRIPTS SQL
        public const string _sqlInsert = "INSERT INTO TBSeries (Serie) VALUES ({0}Serie)";

        public const string _sqlUpdate = "UPDATE TBSeries SET Serie={0}Serie WHERE Id={0}Id";

        public const string _sqlDelete = "DELETE FROM TBSeries WHERE Id={0}Id";

        public const string _sqlSelectAll = @" SELECT ID, Serie FROM TBSeries order by serie ";

        public const string _sqlSelectByName = "SELECT * FROM TBSeries WHERE Serie = ({0}Serie) ";

        #endregion

        public Serie Add(Serie serie)
        {
            serie.ID = Db.Insert(_sqlInsert, Take(serie));

            return serie;
        }
        public Serie Editar(Serie serie)
        {
            Db.Update(_sqlUpdate, Take(serie));

            return serie;
        }
        public void Excluir(Serie serie)
        {
            Dictionary<string, object> parms = new Dictionary<string, object> { { "Id", serie.ID } };

            Db.Delete(_sqlDelete, parms);
        }

        public bool GetByName(Serie serie)
        {
            Dictionary<string, object> parms = new Dictionary<string, object> { { "Serie", serie.Nome } };
            Serie s = Db.Get<Serie>(_sqlSelectByName, Make, parms);
            if (s != null)
                return true;

            return false;
        }
     
        public IList<Serie> GetAll()
        {
            return Db.GetAll(_sqlSelectAll, Make);
        }

        private static Func<IDataReader, Serie> Make = reader =>
          new Serie
          {
              ID = Convert.ToInt32(reader["ID"]),
              Nome = Convert.ToString(reader["Serie"])
          };



        private Dictionary<string, object> Take(Serie serie)
        {
            return new Dictionary<string, object>
            {
                { "ID", serie.ID },
                { "Serie", serie.Nome }
            };
        }



    }
}
