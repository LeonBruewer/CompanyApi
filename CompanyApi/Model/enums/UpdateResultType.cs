using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyApi.Model.enums
{
    public enum UpdateResultType
    {
        OK,
        SQLERROR,
        NOTFOUND,
        INVALIDARGUMENT,
        ERROR
    }
}
