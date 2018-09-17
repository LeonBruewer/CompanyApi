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
    public class DepartmentRepo : IRepository<Department, DepartmentDto>
    {
        SqlConnection con = new SqlConnection(global::CompanyApi.Properties.Resources.tappqaConString);

        public List<Department> GetModelList()
        {
            string query = @"SELECT Id,
                                    DepartmentName,
                                    ManagerFirstName,
                                    ManagerLastName,
                                    CompanyName
                            FROM
                                    viDepartment";

            return con.Query<Department>(query).ToList();
        }

        public List<Department> GetById(int Id)
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
            return con.Query<Department>(query, param).ToList();
        }

        public DepartmentDto Add(DepartmentDto model)
        {
            return _AddOrUpdate(model);
        }

        public DepartmentDto Update(DepartmentDto model)
        {
            return _AddOrUpdate(model, model.Id);
        }

        private DepartmentDto _AddOrUpdate(DepartmentDto model, object Id = null)
        {
            string query = "dbo.spAddOrUpdateAddress";
            DynamicParameters param = new DynamicParameters();

            param.Add("@Id", Id);
            param.Add("@DepartmentName", model.DepartmentName);
            param.Add("@CompanyId", model.CompanyId);
            param.Add("@ManagerId", model.ManagerId);

            var retvalue = con.QueryFirstOrDefault<DepartmentDto>(query, param, null, null, CommandType.StoredProcedure);

            return retvalue;
        }
    }
}
