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
            string query = @"SELECT Id,
                                    CompanyName,
                                    PostalCode,
                                    City,
                                    Street
                            FROM
                                    viCompany";

            return con.Query<Model.Company>(query).ToList();
        }

        public List<Model.Company> GetById(int Id)
        {
            string query = @"SELECT Id,
                                    CompanyName,
                                    PostalCode,
                                    City,
                                    Street
                            FROM
                                    viCompany
                            WHERE Id = @Id";

            var param = new DynamicParameters();
            param.Add("@Id", Id);
            return con.Query<Model.Company>(query, param).ToList();
        }
    }
}
