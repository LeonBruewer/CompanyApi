using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CompanyApi.Controller
{
    public class Employee : Microsoft.AspNetCore.Mvc.Controller
    {
        Repository.Employee repo = new Repository.Employee();

        [HttpGet("/Employee")]
        public JsonResult GetEmployee()
        {
            return new JsonResult(repo.GetModelList());
        }
    }
}
