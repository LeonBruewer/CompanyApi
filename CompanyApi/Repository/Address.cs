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
            //List<Model.Address> result = new List<Model.Address>();

            //SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM viAddress", con);
            //DataTable table = new DataTable();

            //adapter.Fill(table);

            //foreach (DataRow row in table.Rows)
            //{
            //    Model.Address model = new Model.Address()
            //    {
            //        PostalCode = (int)row[0],
            //        City = row[1].ToString(),
            //        Street = row[2].ToString()
            //    };

            //    result.Add(model);
            //}

            //return result;

            return con.Query<Model.Address>("SELECT * FROM viAddress").ToList();
        }
    }
}
