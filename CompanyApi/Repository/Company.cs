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
            return con.Query<Model.Company>("SELECT * FROM viCompany").ToList();
        }
    }
}
