using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CompanyApi.Controller
{
    public class Employee : Microsoft.AspNetCore.Mvc.Controller
    {
        [HttpGet("/Employee")]
        public JsonResult GetEmployee()
        {
            return new JsonResult(new List<object>(){
                new {id=1, name="name"}
            });
        }
    }
}
