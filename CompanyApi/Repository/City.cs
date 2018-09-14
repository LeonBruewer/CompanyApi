﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace CompanyApi.Repository
{
    public class City
    {
        SqlConnection con = new SqlConnection(global::CompanyApi.Properties.Resources.tappqaConString);

        private static City _Instance;

        public static City GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new City();
            }

            return _Instance;
        }

        private City()
        {

        }

        public List<Model.City> GetModelList()
        {
            string query = @"SELECT PostalCode,
                                    CityName
                            FROM
                                    viCity";

            return con.Query<Model.City>(query).ToList();
        }

        public List<Model.City> GetById(int PostalCode)
        {
            string query = @"SELECT PostalCode,
                                    CityName
                            FROM 
                                    viCity
                            WHERE PostalCode = @PostalCode";

            var param = new DynamicParameters();
            param.Add("@PostalCode", PostalCode);
            return con.Query<Model.City>(query, param).ToList();
        }

        public Model.City Add(Model.City model)
        {
            return _AddOrUpdate(model);
        }

        public Model.City Update(Model.City model)
        {
            return _AddOrUpdate(model, model.PostalCode);
        }

        private Model.City _AddOrUpdate(Model.City model, object PostalCode = null)
        {
            string query = "dbo.spAddOrUpdateAddress";
            DynamicParameters param = new DynamicParameters();

            param.Add("@PostalCode", PostalCode);
            param.Add("@City", model.CityName);

            var retvalue = con.QueryFirstOrDefault<Model.City>(query, param, null, null, CommandType.StoredProcedure);

            return retvalue;
        }
    }
}
