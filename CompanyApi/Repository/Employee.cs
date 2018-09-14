using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace CompanyApi.Repository
{
    public class Employee
    {
        SqlConnection con = new SqlConnection(global::CompanyApi.Properties.Resources.tappqaConString);
        public List<Model.Employee> GetModelList()
        {
            string query = @"SELECT Id,
                                    FirstName,
                                    LastName,
                                    BirthDate,
                                    Gender,
                                    PhoneNumber,
                                    City,
                                    Street
                            FROM
                                    viEmployee";

            return con.Query<Model.Employee>(query).ToList();
        }

        public List<Model.Employee> GetById(int Id)
        {
            string query = @"SELECT Id,
                                    FirstName,
                                    LastName,
                                    BirthDate,
                                    Gender,
                                    PhoneNumber,
                                    City,
                                    Street
                            FROM
                                    viEmployee
                            WHERE Id = @Id";

            var param = new DynamicParameters();
            param.Add("@Id", Id);
            return con.Query<Model.Employee>(query, param).ToList();
        }

        public Model.Employee Add(Model.dto.EmployeeDto model)
        {
            return _AddOrUpdate(model);
        }

        public Model.Employee Update(Model.dto.EmployeeDto model)
        {
            return _AddOrUpdate(model, model.Id);
        }

        private Model.Employee _AddOrUpdate(Model.dto.EmployeeDto model, object Id = null)
        {
            string query = "dbo.spAddOrUpdateAddress";
            DynamicParameters param = new DynamicParameters();

            param.Add("@Id", Id);
            param.Add("@FirstName", model.FirstName);
            param.Add("@LastName", model.LastName);
            param.Add("@BirthDate", model.BirthDate);
            param.Add("@Gender", model.Gender);
            param.Add("@PhoneNumber", model.PhoneNumber);
            param.Add("@DepartmentId", model.DepartmentId);
            param.Add("@AddressId", model.AddressId);

            var retvalue = con.QueryFirstOrDefault<Model.Employee>(query, param, null, null, CommandType.StoredProcedure);

            return retvalue;
        }
    }
}
