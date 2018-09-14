using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace CompanyApi.Controller
{
    [Route("api/Address")]
    public class Address : Microsoft.AspNetCore.Mvc.Controller
    {
        
        private Repository.Address repo = new Repository.Address();

        [HttpGet()]
        public IActionResult Get()
        {
            List<Model.Address> retval;

            retval = repo.GetModelList();
            
            if (retval.Count == 0)
                return StatusCode(StatusCodes.Status204NoContent);

            return Ok(retval);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int Id)
        {
            List<Model.Address> retval;

            retval = repo.GetById(Id);

            if (retval.Count == 0)
                return StatusCode(StatusCodes.Status204NoContent);

            return Ok(retval);
        }


        [HttpPost()]
        public IActionResult AddOrUpdate([FromBody] Model.Address obj)
        {
            return Ok(obj.PostalCode);
        }

        
    }
}
