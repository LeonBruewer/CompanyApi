using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace CompanyApi.Controller
{
    [Route("api/Department")]
    public class Department : Microsoft.AspNetCore.Mvc.Controller
    {
        private Repository.Department repo = new Repository.Department();

        [HttpGet()]
        public IActionResult Get()
        {
            List<Model.Department> retval;

            retval = repo.GetModelList();

            if (retval.Count == 0)
                return StatusCode(StatusCodes.Status204NoContent);

            return Ok(retval);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int Id)
        {
            List<Model.Department> retval;

            retval = repo.GetById(Id);

            if (retval.Count == 0)
                return StatusCode(StatusCodes.Status204NoContent);

            return Ok(retval);
        }

        [HttpPost()]
        public IActionResult Add([FromBody] Model.dto.DepartmentDto obj)
        {
            Model.Department newObj = repo.Add(obj);
            return Ok(newObj);
        }

        [HttpPut()]
        public IActionResult Update([FromBody] Model.dto.DepartmentDto obj)
        {
            Model.Department newObj = repo.Update(obj);
            return Ok(newObj);
        }
    }
}
