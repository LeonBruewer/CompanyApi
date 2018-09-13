using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CompanyApi.Repository
{
    public class Company
    {
        SqlConnection con = new SqlConnection(global::CompanyApi.Properties.Resources.tappqaConString);
        public List<Model.Company> GetModelList()
        {
            List<Model.Company> result = new List<Model.Company>();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM viCompany", con);
            DataTable table = new DataTable();

            adapter.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                Model.Company model = new Model.Company()
                {
                    CompanyName = row[0].ToString(),
                    PostalCode = (int)row[1],
                    City = row[2].ToString(),
                    Street = row[3].ToString()
                };

                result.Add(model);
            }

            return result;
        }
    }
}
