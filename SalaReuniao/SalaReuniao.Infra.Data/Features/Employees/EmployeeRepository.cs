using System;
using System.Collections.Generic;
using System.Data;
using SalaReuniao.Domain.Exceptions;
using SalaReuniao.Domain.Features.Employees;

namespace SalaReuniao.Infra.Data.Features.Employees
{
    public class EmployeeRepository : IEmployeeRepository
    {
        #region

        private const string sqlInsertEmployee =
            @"INSERT INTO TBEMPLOYEES
                (NAME,
                 POST,
                 BRANCHLINE)
            VALUES
                ({0}NAME,
                 {0}POST,
                 {0}BRANCHLINE)";

        private const string sqlDeleteEmployee = @"DELETE FROM TBEMPLOYEES WHERE ID = {0}ID";

        private const string sqlGetEmployee =
            @"SELECT
                 ID,
                 NAME,
                 POST,
                 BRANCHLINE
            FROM TBEMPLOYEES WHERE ID = {0}ID";

        private const string sqlGetAllEmployees =
            @"SELECT
                 ID,
                 NAME,
                 POST,
                 BRANCHLINE
            FROM TBEMPLOYEES";

        string sqlUpdateEmployee =
            @"UPDATE TBEMPLOYEES
                SET
                    NAME = {0}NAME,
                    POST = {0}POST,
                    BRANCHLINE = {0}BRANCHLINE
                WHERE ID = {0}ID";

        private const string SqlSelectEmployeeByName =
            @"SELECT
                 ID,
                 NAME,
                 POST,
                 BRANCHLINE
            FROM TBEMPLOYEES WHERE NAME = {0}NAME";

        private const string sqlIsTied = @"SELECT * FROM TBSCHEDULES WHERE EMPLOYEEID = {0}ID";

        #endregion

        public Employee Add(Employee employee)
        {
            employee.Validate();

            employee.Id = Db.Insert(sqlInsertEmployee, GetParameters(employee));

            return employee;
        }

        public void Delete(long id)
        {
            if (id <= 0)
                throw new IdentifierUndefinedException();

            if (IsTiedTo(id))
                throw new TiedException();

            var parms = new Dictionary<string, object> { { "ID", id } };

            Db.Delete(sqlDeleteEmployee, parms);
        }

        public bool Exist(string name)
        {
            var parms = new Dictionary<string, object> { { "NAME", name } };

            var result = Db.Get(SqlSelectEmployeeByName, Converter, parms);

            return result != null;
        }

        public Employee Get(long id)
        {
            if (id <= 0)
                throw new IdentifierUndefinedException();

            var parms = new Dictionary<string, object> { { "ID", id } };

            return Db.Get(sqlGetEmployee, Converter, parms);
        }

        public IList<Employee> GetAll()
        {
            return Db.GetAll(sqlGetAllEmployees, Converter);
        }

        public Employee GetByName(string name)
        {
            var parms = new Dictionary<string, object> { { "NAME", name } };

            var employee = Db.Get(SqlSelectEmployeeByName, Converter, parms);

            return employee;
        }

        public bool IsTiedTo(long id)
        {
            if (id <= 0)
                throw new IdentifierUndefinedException();

            var parms = new Dictionary<string, object> { { "ID", id } };

            var result = Db.Get(sqlIsTied, ConverterScheduleEmployee, parms);

            return result != null;
        }

        public Employee Update(Employee employee)
        {
            employee.Validate();

            Db.Update(sqlUpdateEmployee, GetParameters(employee));

            return employee;
        }

        private static Func<IDataReader, Employee> Converter = reader =>
          new Employee
          {
              Id = Convert.ToInt32(reader["ID"]),
              Name = Convert.ToString(reader["NAME"]),
              Post = Convert.ToString(reader["POST"]),
              BranchLine = Convert.ToInt32(reader["BRANCHLINE"])
          };

        private static Func<IDataReader, Employee> ConverterScheduleEmployee = reader =>
            new Employee
            {
                Id = Convert.ToInt32(reader["ID"])
            };

        private Dictionary<string, object> GetParameters(Employee employee)
        {
            return new Dictionary<string, object>
            {
                { "ID", employee.Id },
                { "NAME", employee.Name},
                { "POST", employee.Post},
                { "BRANCHLINE", employee.BranchLine}
            };
        }
    }
}
