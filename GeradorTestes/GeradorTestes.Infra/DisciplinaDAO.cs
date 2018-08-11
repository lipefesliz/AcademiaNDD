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
    public class DisciplinaDAO
    {
        #region SCRIPTS SQL
        private const string _sqlInsert = "INSERT INTO TBDisciplinas (Nome) VALUES({0}Nome)";

        private const string _sqlSelectGetByName = "SELECT * FROM TBDisciplinas WHERE Nome = {0}Nome";

        private const string _sqlSelectAll = "SELECT * FROM TBDisciplinas order by Nome";

        private const string _sqlDelete = "DELETE FROM TBDisciplinas WHERE ID={0}ID";

        private const string _sqlUpdate = "UPDATE TBDisciplinas set Nome = {0}Nome WHERE ID={0}ID";
        
        #endregion
        public Disciplina Add(Disciplina disciplina)
        {
            disciplina.ID = Db.Insert(_sqlInsert, Take2(disciplina));

            return disciplina;
        }
        public void Update(Disciplina disciplina)
        {
            Dictionary<string, object> parms = new Dictionary<string, object> {
                { "ID", disciplina.ID },
                { "Nome", disciplina.Nome}
            };
            Db.Update(_sqlUpdate, parms);
        }
        public void Delete(Disciplina disciplina) {
            Dictionary<string, object> parms = new Dictionary<string, object>
            {
                { "ID", disciplina.ID}
            };
            Db.Update(_sqlDelete, parms);
        }
        public IList<Disciplina> GetAll()
        {
            return Db.GetAll<Disciplina>(_sqlSelectAll, Make);
        }
        public bool GetByName(Disciplina disciplina)
        {
            Dictionary<string, object> parms = new Dictionary<string, object> { { "Nome", disciplina.Nome } };
            Disciplina d = Db.Get<Disciplina>(_sqlSelectGetByName, Make, parms);
            if (d != null)
                return true;
            return false;
        }
        private Dictionary<string, object> Take2(Disciplina disciplina)
        {
            return new Dictionary<string, object>
            {
                { "ID", disciplina.ID },
                { "Nome", disciplina.Nome }
            };
        }

        private Disciplina Make(IDataReader reader)
        {
            Disciplina disciplina = new Disciplina();

            disciplina.ID = Convert.ToInt32(reader["ID"]);
            disciplina.Nome = Convert.ToString(reader["Nome"]);
            return disciplina;
        }

  


    }
}
