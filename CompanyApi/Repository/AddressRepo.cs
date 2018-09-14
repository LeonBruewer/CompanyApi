﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace CompanyApi.Repository
{
    public class AddressRepo
    {
        SqlConnection con = new SqlConnection(global::CompanyApi.Properties.Resources.tappqaConString);

        private static AddressRepo _Instance;

        public static AddressRepo GetInstatnce()
        {
            if (_Instance == null)
                _Instance = new AddressRepo();

            return _Instance;
        }

        private AddressRepo()
        {

        }

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

        public Model.dto.AddressDto Add(Model.dto.AddressDto model)
        {
            return _AddOrUpdate(model);
        }

        public Model.dto.AddressDto Update(Model.dto.AddressDto model)
        {
            return _AddOrUpdate(model, model.Id);
        }

        private Model.dto.AddressDto _AddOrUpdate(Model.dto.AddressDto model, object Id = null)
        {
            string query = "dbo.spAddOrUpdateAddress";
            DynamicParameters param = new DynamicParameters();

            int PostalCode = model.PostalCode;
            string Street = model.Street;

            param.Add("@Id", Id);
            param.Add("@PostalCode", PostalCode);
            param.Add("@Street", Street);

            var retvalue = con.QueryFirstOrDefault<Model.dto.AddressDto>(query, param, null, null, CommandType.StoredProcedure);

            return retvalue;
        }
    }
}