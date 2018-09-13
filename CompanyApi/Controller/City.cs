using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace CompanyApi.Controller
{
    public class City : Microsoft.AspNetCore.Mvc.Controller
    {
        private Repository.City repo = new Repository.City();

        [Route("api/[Controller]")]
        [HttpGet("{postalcode}")]

        public IActionResult Get(int PostalCode)
        {
            List<Model.City> retval;

            if (PostalCode > 0)
            {
                retval = repo.GetById(PostalCode);
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
