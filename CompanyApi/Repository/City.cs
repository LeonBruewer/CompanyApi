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
            return con.Query<Model.City>("SELECT * FROM viCity").ToList();
        }

        public List<Model.City> GetById(int PostalCode)
        {
            var param = new DynamicParameters();
            param.Add("@PostalCode", PostalCode);
            return con.Query<Model.City>("SELECT * FROM viCity WHERE PostalCode = @PostalCode", param).ToList();
        }
    }
}
