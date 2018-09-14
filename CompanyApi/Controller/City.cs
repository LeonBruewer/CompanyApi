using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace CompanyApi.Controller
{
    [Route("api/City")]
    public class City : Microsoft.AspNetCore.Mvc.Controller
    {
        private Repository.City repo = new Repository.City();

        [HttpGet()]
        public IActionResult Get()
        {
            List<Model.City> retval;

            retval = repo.GetModelList();

            if (retval.Count == 0)
                return StatusCode(StatusCodes.Status204NoContent);

            return Ok(retval);
        }

        [HttpGet("{postalcode}")]
        public IActionResult Get(int PostalCode)
        {
            List<Model.City> retval;

            retval = repo.GetById(PostalCode);

            if (retval.Count == 0)
                return StatusCode(StatusCodes.Status204NoContent);

            return Ok(retval);
        }

        [HttpPost()]
        public IActionResult Add([FromBody] Model.City obj)
        {
            Model.City newObj = repo.Add(obj);
            return Ok(newObj);
        }

        [HttpPut()]
        public IActionResult Update([FromBody] Model.City obj)
        {
            Model.City newObj = repo.Update(obj);
            return Ok(newObj);
        }
    }
}
