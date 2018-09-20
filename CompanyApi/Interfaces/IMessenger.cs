using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyApi.Interfaces
{
    public interface IMessenger
    {
        bool SendIntercom(string message);
    }
}
