using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using CompanyApi.Interfaces;
using CompanyApi.Model;
using CompanyApi.Model.dto;

namespace CompanyApi.Repository
{
    public class EmployeeRepo
    {
        SqlConnection con = new SqlConnection(global::CompanyApi.Properties.Resources.tappqaConString);

        private static EmployeeRepo _Instance;

        public static EmployeeRepo GetInstance()
        {
            if (_Instance == null)
                _Instance = new EmployeeRepo();

            return _Instance;
        }

        private EmployeeRepo()
        {

        }

        public List<Employee> GetModelList()
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

            return con.Query<Employee>(query).ToList();
        }

        public List<Employee> GetById(int Id)
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
            return con.Query<Employee>(query, param).ToList();
        }

        public Employee Add(EmployeeDto model)
        {
            return _AddOrUpdate(model);
        }

        public Employee Update(EmployeeDto model)
        {
            return _AddOrUpdate(model, model.Id);
        }

        private Employee _AddOrUpdate(EmployeeDto model, object Id = null)
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

            var retvalue = con.QueryFirstOrDefault<Employee>(query, param, null, null, CommandType.StoredProcedure);

            return retvalue;
        }
    }
}
