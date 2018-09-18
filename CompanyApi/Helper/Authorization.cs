using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyApi.Interfaces;
using System.Text;

namespace CompanyApi.Helper
{
    public class Authorization : IAuthorization
    {
        private const string _TestUsername = "Importantuser";
        private const string _TestPassword = "Securepassword";

        public bool IsValid(string Authorization)
        {
            var FromBase64 = Convert.FromBase64String(Authorization.Substring(6));
            string userData = Encoding.UTF8.GetString(FromBase64);

            string[] UserData = userData.Split(':');

            if (_TestUsername == UserData[0] && _TestPassword == UserData[1])
                return true;
            else
                return false;
        }
    }
}
