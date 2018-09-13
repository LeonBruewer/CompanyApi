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
    }
}
