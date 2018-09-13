using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CompanyApi.Repository
{
    public class Department
    {
        SqlConnection con = new SqlConnection(global::CompanyApi.Properties.Resources.tappqaConString);
        public List<Model.Department> GetModelList()
        {
            List<Model.Department> result = new List<Model.Department>();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM viDepartment", con);
            DataTable table = new DataTable();

            adapter.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                Model.Department model = new Model.Department()
                {
                    DepartmentName = row[1].ToString(),
                    Manager = row[2].ToString(),
                    Company = row[3].ToString()
                };

                result.Add(model);
            }

            return result;
        }
    }
}
