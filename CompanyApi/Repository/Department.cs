using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace CompanyApi.Repository
{
    public class Department
    {
        SqlConnection con = new SqlConnection(global::CompanyApi.Properties.Resources.tappqaConString);
        public List<Model.Department> GetModelList()
        {
            string query = @"SELECT Id,
                                    DepartmentName,
                                    ManagerFirstName,
                                    ManagerLastName,
                                    CompanyName
                            FROM
                                    viDepartment";

            return con.Query<Model.Department>(query).ToList();
        }

        public List<Model.Department> GetById(int Id)
        {
            string query = @"SELECT Id,
                                    DepartmentName,
                                    ManagerFirstName,
                                    ManagerLastName,
                                    CompanyName
                            FROM
                                    viDepartment
                            WHERE Id = @Id";

            var param = new DynamicParameters();
            param.Add("@Id", Id);
            return con.Query<Model.Department>(query, param).ToList();
        }
    }
}
