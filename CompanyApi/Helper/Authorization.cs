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

        private const string _AccessToken = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsInZlciI6MSwia2lkIjoibWRjeG1kYmQifQ.eyJqdGkiOiJlYjc4ODdkYi03MTlkLTRmYzktOTE4NS1hMWI1MGY4ZTExYmUiLCJzdWIiOiIxMjgtNTA2OTQiLCJ0eXBlIjoxLCJleHAiOiIyMDE4LTA5LTIxVDE2OjA0OjMxWiIsImlhdCI6IjIwMTgtMDktMTdUMTY6MDQ6MzFaIiwiTG9jYXRpb25JRCI6MTIxNCwiU2l0ZUlEIjoiNjAwMzgtMjIxNDEiLCJJc0FkbWluIjpmYWxzZSwiVG9iaXRVc2VySUQiOjE3ODUyMzMsIlBlcnNvbklEIjoiMTI4LTUwNjk0IiwiRmlyc3ROYW1lIjoiTGVvbiIsIkxhc3ROYW1lIjoiQnLDvHdlciJ9.OGeD-GQBNaRSlyBmlQdD6N6ql-L7tlMqlRPjhzBrCv6Wd7TzkV78DLRTx8dy57R2uJPnDPWoLHQn9wzTGbG1IoSRPqIjrf4htVAm7zZijDBEVjmgzdwreM69j7v95xAc0e0DYrizj7TIVDWfeYCHZN7NuihLG3UL6UGZ2qokNN5fY1wnrTsfOOr6DUwCUgvaG4zEevHvm6lewiLg1g0fYziplL5mX68oHFZ995Ok-3uspVTrTfrX9jIEoaNzoM_M-L2TGjSuyeJJ62ECLYYIK-AverixaYaNZOWDW9x9oQW-nytoQ_Ywe6CeudW8W4rC7RXLTRILOVK1AgC1l60Tnw";

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

        public bool AccessTokenIsValid(string Authorization)
        {
            string RequestToken = Authorization.Substring(7);
            
            if (_AccessToken == RequestToken)
                return true;
            else
                return false;
        }
    }
}
