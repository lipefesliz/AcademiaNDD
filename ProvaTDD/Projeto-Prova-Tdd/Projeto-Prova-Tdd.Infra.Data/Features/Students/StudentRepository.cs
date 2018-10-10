using System;
using System.Collections.Generic;
using Projeto_Prova_Tdd.Domain.Features.Students;
using Projeto_Prova_Tdd.Domain.Exceptions;
using System.Data;

namespace Projeto_Prova_Tdd.Infra.Data.Features.Students
{
    public class StudentRepository : IStudentRepository
    {
        #region

        private const string sqlInsertStudent =
            @"INSERT INTO TBSTUDENTS
                (NAME,
                 AGE)
            VALUES
                ({0}NAME,
                 {0}AGE)";

        private const string sqlDeleteStudent = @"DELETE FROM TBSTUDENTS WHERE ID = {0}ID";

        private const string sqlGetStudent =
            @"SELECT
                 ID,
                 NAME,
                 AGE
            FROM TBSTUDENTS WHERE ID = {0}ID";

        private const string sqlGetAllStudents =
            @"SELECT
                 ID,
                 NAME,
                 AGE
            FROM TBSTUDENTS";

        string sqlUpdateStudent =
            @"UPDATE TBSTUDENTS
                SET
                    NAME = {0}NAME,
                    AGE = {0}AGE
                WHERE ID = {0}ID";

        private const string SqlSelectStudentByName =
            @"SELECT
                 ID,
                 NAME,
                 AGE
            FROM TBSTUDENTS WHERE NAME = {0}NAME";

        private const string sqlIsTied = @"SELECT * FROM TBRESULTS WHERE STUDENTID = {0}ID";

        #endregion

        public Student Add(Student student)
        {
            student.Validate();

            student.Id = Db.Insert(sqlInsertStudent, GetParameters(student));

            return student;
        }

        public void Delete(long id)
        {
            if (id <= 0)
                throw new IdentifierUndefinedException();

            if (IsTiedTo(id))
                throw new IsTiedException();

            var parms = new Dictionary<string, object> { { "ID", id } };

            Db.Delete(sqlDeleteStudent, parms);
        }

        public bool Exist(string name)
        {
            var parms = new Dictionary<string, object> { { "NAME", name } };

            var result = Db.Get(SqlSelectStudentByName, Converter, parms);

            return result != null;
        }

        public Student Get(long id)
        {
            if (id <= 0)
                throw new IdentifierUndefinedException();

            var parms = new Dictionary<string, object> { { "ID", id } };

            return Db.Get(sqlGetStudent, Converter, parms);
        }

        public IList<Student> GetAll()
        {
            return Db.GetAll(sqlGetAllStudents, Converter);
        }

        public Student GetByName(string name)
        {
            var parms = new Dictionary<string, object> { { "NAME", name } };

            var student = Db.Get(SqlSelectStudentByName, Converter, parms);

            return student;
        }

        public bool IsTiedTo(long id)
        {
            if (id <= 0)
                throw new IdentifierUndefinedException();

            var parms = new Dictionary<string, object> { { "ID", id } };

            var result = Db.Get(sqlIsTied, ConverterResultStudent, parms);

            return result != null;
        }

        public Student Update(Student student)
        {
            student.Validate();

            Db.Update(sqlUpdateStudent, GetParameters(student));

            return student;
        }

        private static Func<IDataReader, Student> Converter = reader =>
          new Student
          {
              Id = Convert.ToInt32(reader["ID"]),
              Name = Convert.ToString(reader["NAME"]),
              Age = Convert.ToInt32(reader["AGE"])
          };

        private static Func<IDataReader, Student> ConverterResultStudent = reader =>
            new Student
            {
                Id = Convert.ToInt32(reader["ID"])
            };

        private Dictionary<string, object> GetParameters(Student student)
        {
            return new Dictionary<string, object>
            {
                { "ID", student.Id },
                { "NAME", student.Name},
                { "AGE", student.Age}
            };
        }
    }
}
