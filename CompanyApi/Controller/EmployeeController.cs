using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CompanyApi.Interfaces;
using CompanyApi.Model;
using CompanyApi.Model.dto;

namespace CompanyApi.Controller
{
    [Route("api/Employee")]
    public class EmployeeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private IRepository<Employee, EmployeeDto> _repo;

        public EmployeeController(IRepository<Employee, EmployeeDto> repo)
        {
            _repo = repo;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            List<Employee> retval;

            retval = _repo.GetModelList();

            if (retval.Count == 0)
                return StatusCode(StatusCodes.Status204NoContent);

            return Ok(retval);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int Id)
        {
            List<Employee> retval;

            retval = _repo.GetById(Id);

            if (retval.Count == 0)
                return StatusCode(StatusCodes.Status204NoContent);

            return Ok(retval);
        }

        [HttpPost()]
        public IActionResult Add([FromBody] EmployeeDto obj)
        {
            EmployeeDto newObj = _repo.Add(obj);
            return Ok(newObj);
        }

        [HttpPut()]
        public IActionResult Update([FromBody] EmployeeDto obj)
        {
            EmployeeDto newObj = _repo.Update(obj);
            return Ok(newObj);
        }
    }
}
