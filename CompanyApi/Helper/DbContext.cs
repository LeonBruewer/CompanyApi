using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;
using CompanyApi.Interfaces;
using CompanyApi.Model;

namespace CompanyApi.Helper
{
    public class DbContext : IDbContext
    {
        private DbSettings _settings;
        public DbContext(IOptions<DbSettings> options)
        {
            _settings = options.Value;
        }

        public IDbConnection GetConnection()
        {

            var con = new SqlConnection(_settings.Connection);

            return con;
        }
    }
}
