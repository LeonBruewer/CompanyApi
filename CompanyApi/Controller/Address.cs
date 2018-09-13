﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CompanyApi.Controller
{
    public class Address : Microsoft.AspNetCore.Mvc.Controller
    {
        private Repository.Address repo = new Repository.Address();
        [Route("api/[Controller]")]
        [HttpGet()]
        public IActionResult Get()
        {
            var retval = repo.GetModelList();

            return Ok(retval);
        }
    }
}