﻿using System;
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
    [Route("api/Company")]
    public class CompanyController : Microsoft.AspNetCore.Mvc.Controller
    {
        //private Repository.CompanyRepo _repo = Repository.CompanyRepo.GetInstance();
        private IRepository<Company, CompanyDto> _repo;

        public CompanyController(IRepository<Company, CompanyDto> repo)
        {
            _repo = repo;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            List<Company> retval;

            retval = _repo.GetModelList();
            
            if (retval.Count == 0)
                return StatusCode(StatusCodes.Status204NoContent);

            return Ok(retval);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int Id)
        {
            List<Company> retval;

            retval = _repo.GetById(Id);

            if (retval.Count == 0)
                return StatusCode(StatusCodes.Status204NoContent);

            return Ok(retval);
        }

        [HttpPost()]
        public IActionResult Add([FromBody] CompanyDto obj)
        {
            CompanyDto newObj = _repo.Add(obj);
            return Ok(newObj);
        }

        [HttpPut()]
        public IActionResult Update([FromBody] CompanyDto obj)
        {
            CompanyDto newObj = _repo.Update(obj);
            return Ok(newObj);
        }
    }
}
