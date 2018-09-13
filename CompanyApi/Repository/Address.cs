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
            string query = @"SELECT Id,
                                    PostalCode,
                                    City,
                                    Street
                            FROM viAddress";

            return con.Query<Model.Address>(query).ToList();
        }

        public List<Model.Address> GetById(int Id)
        {
            string query = @"SELECT Id,
                                    PostalCode,
                                    City,
                                    Street
                            FROM
                                    viAddress
                            WHERE Id = @Id";

            var param = new DynamicParameters();
            param.Add("@Id", Id);
            return con.Query<Model.Address>(query, param).ToList();
        }
    }
}
