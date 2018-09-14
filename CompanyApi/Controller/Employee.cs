﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace CompanyApi.Controller
{
    [Route("api/[Controller]")]
    public class Employee : Microsoft.AspNetCore.Mvc.Controller
    {
        private Repository.Employee repo = new Repository.Employee();

        [HttpGet()]
        public IActionResult Get()
        {
            List<Model.Employee> retval;

            retval = repo.GetModelList();

            if (retval.Count == 0)
                return StatusCode(StatusCodes.Status204NoContent);

            return Ok(retval);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int Id)
        {
            List<Model.Employee> retval;

            retval = repo.GetById(Id);

            if (retval.Count == 0)
                return StatusCode(StatusCodes.Status204NoContent);

            return Ok(retval);
        }

        [HttpPost()]
        public IActionResult Add([FromBody] Model.dto.EmployeeDto obj)
        {
            Model.Employee newObj = repo.Add(obj);
            return Ok(newObj);
        }

        [HttpPut()]
        public IActionResult Update([FromBody] Model.dto.EmployeeDto obj)
        {
            Model.Employee newObj = repo.Update(obj);
            return Ok(newObj);
        }
    }
}
