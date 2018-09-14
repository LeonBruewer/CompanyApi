using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace CompanyApi.Repository
{
    public class CityRepo
    {
        SqlConnection con = new SqlConnection(global::CompanyApi.Properties.Resources.tappqaConString);

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

        public List<Model.City> GetModelList()
        {
            string query = @"SELECT PostalCode,
                                    CityName
                            FROM
                                    viCity";

            return con.Query<Model.City>(query).ToList();
        }

        public List<Model.City> GetById(int PostalCode)
        {
            string query = @"SELECT PostalCode,
                                    CityName
                            FROM 
                                    viCity
                            WHERE PostalCode = @PostalCode";

            var param = new DynamicParameters();
            param.Add("@PostalCode", PostalCode);
            return con.Query<Model.City>(query, param).ToList();
        }

        public Model.City Add(Model.City model)
        {
            return _AddOrUpdate(model);
        }

        public Model.City Update(Model.City model)
        {
            return _AddOrUpdate(model, model.PostalCode);
        }

        private Model.City _AddOrUpdate(Model.City model, object PostalCode = null)
        {
            string query = "dbo.spAddOrUpdateAddress";
            DynamicParameters param = new DynamicParameters();

            param.Add("@PostalCode", PostalCode);
            param.Add("@City", model.CityName);

            var retvalue = con.QueryFirstOrDefault<Model.City>(query, param, null, null, CommandType.StoredProcedure);

            return retvalue;
        }
    }
}
