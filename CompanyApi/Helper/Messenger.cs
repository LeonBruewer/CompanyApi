using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyApi.Interfaces;
using Chayns.Backend.Api.Helper;
using Chayns.Backend.Api.Models;
using Chayns.Backend.Api.Repository;
using Chayns.Backend.Api.Models.Data;
using Chayns.Backend.Api.Credentials.Base;
using Microsoft.Extensions.Options;
using CompanyApi.Model;
using Chayns.Backend.Api.Credentials;

namespace CompanyApi.Helper
{
    public class Messenger : IMessenger
    {
        private TappSecret _tapp;

        public Messenger(IOptions<TappSecret> options)
        {
            _tapp = options.Value;
        }

        public bool SendIntercom(string message)
        {
            var cred = new SecretCredentials(_tapp.Secret, 430034);
            var intercomRepo = new IntercomRepository(cred);
            
            var intercomData = new IntercomData(158756)
            {
                Message = message
            };

            intercomRepo.SendIntercomMessage(intercomData);

            return true;
        }
    }
}
