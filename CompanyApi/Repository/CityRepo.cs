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
    public class CityRepo
    {
        SqlConnection con = new SqlConnection(Properties.Resources.tappqaConString);

        private static CityRepo _Instance;

        public static CityRepo GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new CityRepo();
            }

            return _Instance;
        }

        private CityRepo()
        {

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

        public City Add(City model)
        {
            return _AddOrUpdate(model);
        }

        public City Update(City model)
        {
            return _AddOrUpdate(model, model.PostalCode);
        }

        private City _AddOrUpdate(City model, object PostalCode = null)
        {
            string query = "dbo.spAddOrUpdateAddress";
            DynamicParameters param = new DynamicParameters();

            param.Add("@PostalCode", PostalCode);
            param.Add("@City", model.CityName);

            var retvalue = con.QueryFirstOrDefault<City>(query, param, null, null, CommandType.StoredProcedure);

            return retvalue;
        }
    }
}
