using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace CompanyApi.Repository
{
    public class City
    {
        SqlConnection con = new SqlConnection(global::CompanyApi.Properties.Resources.tappqaConString);
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
    }
}
