﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CompanyApi.Interfaces
{
    public interface IAuthorization
    {
        bool IsValid(string Authorization);
        bool AccessTokenIsValid(string Authorization);
    }
}
