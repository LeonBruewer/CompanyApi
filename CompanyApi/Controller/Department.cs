﻿using System;
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
        private Repository.Department _repo = Repository.Department.GetInstance();

        [HttpGet()]
        public IActionResult Get()
        {
            List<Model.Department> retval;

            retval = _repo.GetModelList();

            if (retval.Count == 0)
                return StatusCode(StatusCodes.Status204NoContent);

            return Ok(retval);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int Id)
        {
            List<Model.Department> retval;

            retval = _repo.GetById(Id);

            if (retval.Count == 0)
                return StatusCode(StatusCodes.Status204NoContent);

            return Ok(retval);
        }

        [HttpPost()]
        public IActionResult Add([FromBody] Model.dto.DepartmentDto obj)
        {
            Model.Department newObj = _repo.Add(obj);
            return Ok(newObj);
        }

        [HttpPut()]
        public IActionResult Update([FromBody] Model.dto.DepartmentDto obj)
        {
            Model.Department newObj = _repo.Update(obj);
            return Ok(newObj);
        }
    }
}
