using System;
using System.Collections.Generic;
using Projeto_Prova_Tdd.Domain.Features.Results;
using Projeto_Prova_Tdd.Domain.Exceptions;
using Projeto_Prova_Tdd.Domain.Features.Students;
using System.Data;

namespace Projeto_Prova_Tdd.Infra.Data.Features.Results
{
    public class ResultRepository : IResultRepository
    {
        static Student student = new Student();

        #region

        private const string sqlInsertResult =
            @"INSERT INTO TBRESULTS
                (GRADE,
                 STUDENTID)
            VALUES
                ({0}GRADE,
                {0}STUDENTID)";

        private const string sqlDeleteResult = @"DELETE FROM TBRESULTS WHERE ID = {0}ID";

        private const string sqlGetResult =
            @"SELECT
                 ID,
                 GRADE,
                 STUDENTID
            FROM TBRESULTS WHERE ID = {0}ID";

        private const string sqlGetAllResults =
            @"SELECT
                 ID,
                 GRADE,
                 STUDENTID
            FROM TBRESULTS";

        string sqlUpdateResult =
            @"UPDATE TBRESULTS
                SET
                    GRADE = {0}GRADE,
                    STUDENTID = {0}STUDENTID
                WHERE ID = {0}ID";

        private const string SqlSelectResultByStudent =
            @"SELECT
                 ID,
                 GRADE,
                 STUDENTID
            FROM TBRESULTS WHERE  STUDENTID = {0}ID";

        private const string sqlIsTied = @"SELECT * FROM TBAUDITIONS WHERE RESULTID = {0}ID";

        #endregion

        public Result Add(Result result)
        {
            result.Validate();

            result.Id = Db.Insert(sqlInsertResult, GetParameters(result));

            return result;
        }

        public void Delete(long id)
        {
            if (id <= 0)
                throw new IdentifierUndefinedException();

            if (IsTiedTo(id))
                throw new IsTiedException();

            var parms = new Dictionary<string, object> { { "ID", id } };

            Db.Delete(sqlDeleteResult, parms);
        }

        public bool Exist(long id)
        {
            var parms = new Dictionary<string, object> { { "ID", id } };

            var result = Db.Get(SqlSelectResultByStudent, Converter, parms);

            return result != null;
        }

        public Result Get(long id)
        {
            if (id <= 0)
                throw new IdentifierUndefinedException();

            var parms = new Dictionary<string, object> { { "ID", id } };

            return Db.Get(sqlGetResult, Converter, parms);
        }

        public IList<Result> GetAll()
        {
            return Db.GetAll(sqlGetAllResults, Converter);
        }

        public Result GetByStudent(long id)
        {
            var parms = new Dictionary<string, object> { { "ID", id } };

            var result = Db.Get(SqlSelectResultByStudent, Converter, parms);

            return result;
        }

        public bool IsTiedTo(long id)
        {
            if (id <= 0)
                throw new IdentifierUndefinedException();

            var parms = new Dictionary<string, object> { { "ID", id } };

            var result = Db.Get(sqlIsTied, ConverterAuditionResult, parms);

            return result != null;
        }

        public Result Update(Result result)
        {
            result.Validate();

            Db.Update(sqlUpdateResult, GetParameters(result));

            return result;
        }

        private static Func<IDataReader, Result> Converter = reader =>
          new Result(student)
          {
              Id = Convert.ToInt32(reader["ID"]),
              Grade = Convert.ToDouble(reader["GRADE"])
          };

        private static Func<IDataReader, Student> ConverterStudent = reader =>
          new Student
          {
              Id = Convert.ToInt32(reader["ID"]),
              Name = Convert.ToString(reader["NAME"]),
              Age = Convert.ToInt32(reader["AGE"])
          };

        private static Func<IDataReader, Result> ConverterAuditionResult = reader =>
            new Result(student)
            {
                Id = Convert.ToInt32(reader["ID"])
            };

        private Dictionary<string, object> GetParameters(Result result)
        {
            return new Dictionary<string, object>
            {
                { "ID", result.Id },
                { "GRADE", result.Grade},
                { "STUDENTID", result.Student.Id},
            };
        }
    }
}
