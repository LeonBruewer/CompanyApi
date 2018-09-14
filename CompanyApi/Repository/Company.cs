using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace CompanyApi.Repository
{
    public class Company
    {
        SqlConnection con = new SqlConnection(global::CompanyApi.Properties.Resources.tappqaConString);
        public List<Model.Company> GetModelList()
        {
            string query = @"SELECT Id,
                                    CompanyName,
                                    PostalCode,
                                    City,
                                    Street
                            FROM
                                    viCompany";

            return con.Query<Model.Company>(query).ToList();
        }

        public List<Model.Company> GetById(int Id)
        {
            string query = @"SELECT Id,
                                    CompanyName,
                                    PostalCode,
                                    City,
                                    Street
                            FROM
                                    viCompany
                            WHERE Id = @Id";

            var param = new DynamicParameters();
            param.Add("@Id", Id);
            return con.Query<Model.Company>(query, param).ToList();
        }
        public Model.Company Add(Model.dto.CompanyDto model)
        {
            return _AddOrUpdate(model);
        }

        public Model.Company Update(Model.dto.CompanyDto model)
        {
            return _AddOrUpdate(model, model.Id);
        }

        private Model.Company _AddOrUpdate(Model.dto.CompanyDto model, object Id = null)
        {
            string query = "dbo.spAddOrUpdateAddress";
            DynamicParameters param = new DynamicParameters();

            param.Add("@Id", Id);
            param.Add("@CompanyName", model.CompanyName);
            param.Add("@AddressId", model.AddressId);

            var retvalue = con.QueryFirstOrDefault<Model.Company>(query, param, null, null, CommandType.StoredProcedure);

            return retvalue;
        }
    }
}
