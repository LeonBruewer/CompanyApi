using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace CompanyApi.Repository
{
    public class Address
    {
        SqlConnection con = new SqlConnection(global::CompanyApi.Properties.Resources.tappqaConString);
        public List<Model.Address> GetModelList()
        {
            return con.Query<Model.Address>("SELECT * FROM viAddress").ToList();
        }

        public List<Model.Address> GetById(int Id)
        {
            var param = new DynamicParameters();
            param.Add("@Id", Id);
            return con.Query<Model.Address>("SELECT * FROM viAddress WHERE Id = @Id", param).ToList();
        }
    }
}
