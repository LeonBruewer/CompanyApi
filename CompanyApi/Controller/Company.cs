using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CompanyApi.Controller
{
    public class Company : Microsoft.AspNetCore.Mvc.Controller
    {
        private Repository.Company repo = new Repository.Company();

        [Route("api/[Controller]")]
        [HttpGet()]
        public IActionResult Get()
        {
            var retval = repo.GetModelList();

            return Ok(retval);
        }
    }
}
