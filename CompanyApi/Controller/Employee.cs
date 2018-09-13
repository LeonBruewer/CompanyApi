using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CompanyApi.Controller
{
    public class Employee : Microsoft.AspNetCore.Mvc.Controller
    {
        private Repository.Employee repo = new Repository.Employee();

        [Route("api/[Controller]")]
        [HttpGet("{id}")]
        public IActionResult Get(int Id)
        {
            List<Model.Employee> retval;
            if (Id > 0)
            {
                retval = repo.GetById(Id);
            }
            else
            {
                retval = repo.GetModelList();
            }

            return Ok(retval);
        }
    }
}
