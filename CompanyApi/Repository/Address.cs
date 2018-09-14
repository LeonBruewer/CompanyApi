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

        public Model.Address Add(Model.Address model)
        {
            return _AddOrUpdate(model);
        }

        public Model.Address Update(Model.Address model)
        {
            return _AddOrUpdate(model, model.Id);
        }

        private Model.Address _AddOrUpdate(Model.Address model, object Id = null)
        {
            string query = "dbo.spAddOrUpdateAddress";
            DynamicParameters param = new DynamicParameters();

            int PostalCode = model.PostalCode;
            string Street = model.Street;

            param.Add("@Id", Id);
            param.Add("@PostalCode", PostalCode);
            param.Add("@Street", Street);

            var retvalue = con.QueryFirstOrDefault<Model.Address>(query, param, null, null, CommandType.StoredProcedure);

            return retvalue;
        }
    }
}
