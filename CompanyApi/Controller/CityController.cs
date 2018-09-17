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

namespace CompanyApi.Controller
{
    [Route("api/City")]
    public class CityController : Microsoft.AspNetCore.Mvc.Controller
    {
        IRepository<City, CityDto> _repo;

        public CityController(IRepository<City, CityDto> repo)
        {
            _repo = repo;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            List<City> retval;

            retval = _repo.GetModelList();

            if (retval.Count == 0)
                return StatusCode(StatusCodes.Status204NoContent);

            return Ok(retval);
        }

        [HttpGet("{postalcode}")]
        public IActionResult Get(int PostalCode)
        {
            List<City> retval;

            retval = _repo.GetById(PostalCode);

            if (retval.Count == 0)
                return StatusCode(StatusCodes.Status204NoContent);

            return Ok(retval);
        }

        [HttpPost()]
        public IActionResult Add([FromBody] CityDto obj)
        {
            CityDto newObj = _repo.Add(obj);
            return Ok(newObj);
        }

        [HttpPut()]
        public IActionResult Update([FromBody] CityDto obj)
        {
            CityDto newObj = _repo.Update(obj);
            return Ok(newObj);
        }
    }
}
