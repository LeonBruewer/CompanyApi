using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CompanyApi.Repository
{
    public class Employee
    {
        SqlConnection con = new SqlConnection(global::CompanyApi.Properties.Resources.tappqaConString);
        public List<Model.Employee> GetModelList()
        {
            List<Model.Employee> result = new List<Model.Employee>();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM viEmployee", con);
            DataTable table = new DataTable();

            adapter.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                Model.Employee model = new Model.Employee()
                {
                    FirstName = row[0].ToString(),
                    LastName = row[1].ToString(),
                    BirthDate = Convert.ToDateTime(row[2]),
                    Gender = row[3].ToString(),
                    PhoneNumber = row[4].ToString(),
                    City = row[5].ToString(),
                    Street = row[6].ToString()
                };

                result.Add(model);
            }

            return result;
        }
    }
}
