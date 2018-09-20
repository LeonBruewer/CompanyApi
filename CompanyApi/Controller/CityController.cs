using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CompanyApi.Interfaces;
using CompanyApi.Model;
using CompanyApi.Model.dto;
using CompanyApi.Repository;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using TobitWebApiExtensions.Extensions;

namespace CompanyApi.Controller
{

    [Route("api/City")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private IRepository<City, CityDto> _repo;
        private IAuthorization _auth;

        public CityController(IRepository<City, CityDto> repo, IAuthorization auth)
        {
            _repo = repo;
            _auth = auth;
        }

        ////[Authorize(Roles = "1")]
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    var _user = HttpContext.GetTokenPayload<Auth.Models.LocationUserTokenPayload>();
        //    var groups = HttpContext.GetUacGroups();

        //    //_logger.LogInformation("Request started");

        //    //try
        //    //{
        //    //    throw new ArgumentException("MyObject");
        //    //}
        //    //catch (ArgumentException e)
        //    //{
        //    //    var logObj = new ExceptionData(e);
        //    //    logObj.CustomNumber = 123;
        //    //    logObj.CustomText = "abs";
        //    //    logObj.Add("start_time", DateTime.UtcNow);

        //    //    logObj.Add("myObject", new
        //    //    {
        //    //        TappId= 15,
        //    //        Name = "Sebastian"
        //    //    });
        //    //    _logger.Error(logObj);
        //    //}

        //    //throw new Exception("New exception");

        //    return Ok(groups);
        //}

        [Authorize(Roles = "1")]
        [HttpGet()]
        public IActionResult Get()
        {
            var user = HttpContext.GetTokenPayload<Auth.Models.LocationUserTokenPayload>();
            var groups = HttpContext.GetUacGroups();

            List<City> retval;
            retval = _repo.GetModelList();

            if (retval.Count == 0)
                return StatusCode(StatusCodes.Status204NoContent);

            return Ok(retval);
        }

        [Authorize(Roles = "1")]
        [HttpGet("{postalcode}")]
        public IActionResult Get(int PostalCode, [FromHeader] string Authorization)
        {
            List<City> retval;
            retval = _repo.GetById(PostalCode);

            if (retval.Count == 0)
                return StatusCode(StatusCodes.Status204NoContent);

            return Ok(retval);
        }

        [Authorize(Roles = "1")]
        [HttpPost()]
        public IActionResult Add([FromBody] CityDto obj, [FromHeader] string Authorization)
        {
            CityDto newObj = _repo.Add(obj);
            return Ok(newObj);
        }

        [Authorize(Roles = "1")]
        [HttpPut()]
        public IActionResult Update([FromBody] CityDto obj, [FromHeader] string Authorization)
        {
            CityDto newObj = _repo.Update(obj);
            return Ok(newObj);
        }
    }
}
