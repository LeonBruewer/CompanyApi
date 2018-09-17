using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace CompanyApi.Interfaces
{
    public interface IDbContext
    {
        IDbConnection GetConnection();
    }
}
