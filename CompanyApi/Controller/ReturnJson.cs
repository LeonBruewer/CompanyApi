using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CompanyApi.Controller
{
    public class ReturnJson : Microsoft.AspNetCore.Mvc.Controller
    {
        
        

        [HttpGet("/Address")]
        public JsonResult GetAddress()
        {
            Repository.Address repo = new Repository.Address();
            
            return new JsonResult(repo.GetModelList());
        }

        [HttpGet("/City")]
        public JsonResult GetCity()
        {
            Repository.City repo = new Repository.City();

            return new JsonResult(repo.GetModelList());
        }

        [HttpGet("/Company")]
        public JsonResult GetCompany()
        {
            Repository.Company repo = new Repository.Company();

            return new JsonResult(repo.GetModelList());
        }

        [HttpGet("/Department")]
        public JsonResult GetDepartment()
        {
            Repository.Department repo = new Repository.Department();

            return new JsonResult(repo.GetModelList());
        }

        [HttpGet("/Employee")]
        public JsonResult GetEmployee()
        {
            Repository.Employee repo = new Repository.Employee();

            return new JsonResult(repo.GetModelList());
        }
    }
}
