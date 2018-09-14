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

        public Model.Department Add(Model.dto.DepartmentDto model)
        {
            return _AddOrUpdate(model);
        }

        public Model.Department Update(Model.dto.DepartmentDto model)
        {
            return _AddOrUpdate(model, model.Id);
        }

        private Model.Department _AddOrUpdate(Model.dto.DepartmentDto model, object Id = null)
        {
            string query = "dbo.spAddOrUpdateAddress";
            DynamicParameters param = new DynamicParameters();

            param.Add("@Id", Id);
            param.Add("@DepartmentName", model.DepartmentName);
            param.Add("@CompanyId", model.CompanyId);
            param.Add("@ManagerId", model.ManagerId);

            var retvalue = con.QueryFirstOrDefault<Model.Department>(query, param, null, null, CommandType.StoredProcedure);

            return retvalue;
        }
    }
}
