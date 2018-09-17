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
    public class CompanyRepo : IRepository<Company, CompanyDto>
    {
        IDbConnection con;

        public CompanyRepo(IDbContext dbContext)
        {
            con = dbContext.GetConnection();
        }

        public List<Company> GetModelList()
        {
            string query = @"SELECT Id,
                                    CompanyName,
                                    PostalCode,
                                    City,
                                    Street
                            FROM
                                    viCompany";

            return con.Query<Company>(query).ToList();
        }

        public List<Company> GetById(int Id)
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
            return con.Query<Company>(query, param).ToList();
        }
        public CompanyDto Add(CompanyDto model)
        {
            return _AddOrUpdate(model);
        }

        public CompanyDto Update(CompanyDto model)
        {
            return _AddOrUpdate(model, model.Id);
        }

        private CompanyDto _AddOrUpdate(CompanyDto model, object Id = null)
        {
            string query = "dbo.spAddOrUpdateAddress";
            DynamicParameters param = new DynamicParameters();

            param.Add("@Id", Id);
            param.Add("@CompanyName", model.CompanyName);
            param.Add("@AddressId", model.AddressId);

            var retvalue = con.QueryFirstOrDefault<CompanyDto>(query, param, null, null, CommandType.StoredProcedure);

            return retvalue;
        }
    }
}
