using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using CompanyApi.Interfaces;
using CompanyApi.Model;
using CompanyApi.Model.dto;
namespace CompanyApi.Repository
{
    public class AddressRepo : IRepository<Address, AddressDto>
    {
        SqlConnection con = new SqlConnection(global::CompanyApi.Properties.Resources.tappqaConString);

        public List<Address> GetModelList()
        {
            string query = @"SELECT Id,
                                    PostalCode,
                                    City,
                                    Street
                            FROM viAddress";

            return con.Query<Address>(query).ToList();
        }

        public List<Address> GetById(int Id)
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
            return con.Query<Address>(query, param).ToList();
        }

        public AddressDto Add(AddressDto model)
        {
            return _AddOrUpdate(model);
        }

        public AddressDto Update(AddressDto model)
        {
            return _AddOrUpdate(model, model.Id);
        }

        private AddressDto _AddOrUpdate(AddressDto model, object Id = null)
        {
            string query = "dbo.spAddOrUpdateAddress";
            DynamicParameters param = new DynamicParameters();

            int PostalCode = model.PostalCode;
            string Street = model.Street;

            param.Add("@Id", Id);
            param.Add("@PostalCode", PostalCode);
            param.Add("@Street", Street);

            var retvalue = con.QueryFirstOrDefault<AddressDto>(query, param, null, null, CommandType.StoredProcedure);

            return retvalue;
        }
    }
}
