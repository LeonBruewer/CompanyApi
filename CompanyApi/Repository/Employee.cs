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
    }
}
