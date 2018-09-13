using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace CompanyApi.Repository
{
    public class Employee
    {
        SqlConnection con = new SqlConnection(global::CompanyApi.Properties.Resources.tappqaConString);
        public List<Model.Employee> GetModelList()
        {
            return con.Query<Model.Employee>("SELECT * FROM viEmployee").ToList();
        }
    }
}
