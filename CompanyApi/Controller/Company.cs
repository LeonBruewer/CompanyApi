using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace CompanyApi.Controller
{
    public class Company : Microsoft.AspNetCore.Mvc.Controller
    {
        private Repository.Company repo = new Repository.Company();

        [Route("api/[Controller]")]
        [HttpGet("{id}")]
        public IActionResult Get(int Id)
        {
            List<Model.Company> retval;

            if (Id > 0)
            {
                retval = repo.GetById(Id);
            }
            else
            {
                retval = repo.GetModelList();
            }

            if (retval.Count == 0)
                return StatusCode(StatusCodes.Status204NoContent);

            return Ok(retval);
        }
    }
}
