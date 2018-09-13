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

        
        public Model.Address AddOrUpdate(string[] Param)
        {
            string query = "dbo.spAddOrUpdateCity";
            DynamicParameters param = new DynamicParameters();

            for (int i = 0; i < Param.Length; i++)
            {
                if (Param[i] == "")
                    Param[i] = null;
            }

            string PostalCode = Param[0];
            string City = Param[1];
            
            param.Add("@PostalCode", PostalCode);
            param.Add("@City", City);

            var retvalue = con.QueryFirstOrDefault<Model.Address>(query, param, null, null, CommandType.StoredProcedure);

            return retvalue;
        }
    }
}
