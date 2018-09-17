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
    public class CityRepo : IRepository<City, CityDto>
    {
        IDbConnection con;

        public CityRepo(IDbContext dbContext)
        {
            con = dbContext.GetConnection();
        }

        public List<City> GetModelList()
        {
            string query = @"SELECT PostalCode,
                                    CityName
                            FROM
                                    viCity";

            return con.Query<City>(query).ToList();
        }

        public List<City> GetById(int PostalCode)
        {
            string query = @"SELECT PostalCode,
                                    CityName
                            FROM 
                                    viCity
                            WHERE PostalCode = @PostalCode";

            var param = new DynamicParameters();
            param.Add("@PostalCode", PostalCode);
            return con.Query<City>(query, param).ToList();
        }

        public CityDto Add(CityDto model)
        {
            return _AddOrUpdate(model);
        }

        public CityDto Update(CityDto model)
        {
            return _AddOrUpdate(model, model.PostalCode);
        }

        private CityDto _AddOrUpdate(CityDto model, object PostalCode = null)
        {
            string query = "dbo.spAddOrUpdateAddress";
            DynamicParameters param = new DynamicParameters();

            param.Add("@PostalCode", PostalCode);
            param.Add("@City", model.CityName);

            var retvalue = con.QueryFirstOrDefault<CityDto>(query, param, null, null, CommandType.StoredProcedure);

            return retvalue;
        }
    }
}
