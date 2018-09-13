﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CompanyApi.Repository
{
    public class City
    {
        SqlConnection con = new SqlConnection(global::CompanyApi.Properties.Resources.tappqaConString);
        public List<Model.City> GetModelList()
        {
            List<Model.City> result = new List<Model.City>();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM viCity", con);
            DataTable table = new DataTable();

            adapter.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                Model.City model = new Model.City()
                {
                    PostalCode = (int)row[1],
                    CityName = row[2].ToString()
                };

                result.Add(model);
            }

            return result;
        }
    }
}