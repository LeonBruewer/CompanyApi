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
    public class DepartmentRepo
    {
        SqlConnection con = new SqlConnection(global::CompanyApi.Properties.Resources.tappqaConString);

        private static DepartmentRepo _Instance;

        public static DepartmentRepo GetInstance()
        {
            if (_Instance == null)
                _Instance = new DepartmentRepo();

            return _Instance;
        }

        private DepartmentRepo()
        {

        }

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

        public Department Add(DepartmentDto model)
        {
            return _AddOrUpdate(model);
        }

        public Department Update(DepartmentDto model)
        {
            return _AddOrUpdate(model, model.Id);
        }

        private Department _AddOrUpdate(DepartmentDto model, object Id = null)
        {
            string query = "dbo.spAddOrUpdateAddress";
            DynamicParameters param = new DynamicParameters();

            param.Add("@Id", Id);
            param.Add("@DepartmentName", model.DepartmentName);
            param.Add("@CompanyId", model.CompanyId);
            param.Add("@ManagerId", model.ManagerId);

            var retvalue = con.QueryFirstOrDefault<Department>(query, param, null, null, CommandType.StoredProcedure);

            return retvalue;
        }
    }
}
