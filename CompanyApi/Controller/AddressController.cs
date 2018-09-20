using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CompanyApi.Model;
using CompanyApi.Model.dto;
using CompanyApi.Interfaces;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace CompanyApi.Controller
{
    [Route("api/Address")]
    public class AddressController : Microsoft.AspNetCore.Mvc.Controller
    {
        IRepository<Address, AddressDto> _repo;
        IAuthorization _auth;

        public AddressController(IRepository<Address, AddressDto> repo, IAuthorization auth)
        {
            _repo = repo;
            _auth = auth;
        }

        [Authorize(Roles = "1")]
        [HttpGet()]
        public IActionResult Get([FromHeader] string Authorization)
        {
            List<Address> retval;
            retval = _repo.GetModelList();

            if (retval.Count == 0)
                return StatusCode(StatusCodes.Status204NoContent);

            return Ok(retval);
        }

        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult Get(int Id, [FromHeader] string Authorization)
        {
            List<Address> retval;
            retval = _repo.GetById(Id);

            if (retval.Count == 0)
                return StatusCode(StatusCodes.Status204NoContent);

            return Ok(retval);
        }

        [Authorize(Roles = "1")]
        [HttpPost()]
        public IActionResult Add([FromBody] AddressDto obj, [FromHeader] string Authorization)
        {
            try
            {
                AddressDto newObj = _repo.Add(obj);
                return Ok(newObj);
            }
            catch (Helper.RepositoryException<Model.enums.InsertResultType> ex)
            {
                switch (ex.Type)
                {
                    case Model.enums.InsertResultType.OK:
                        return StatusCode(StatusCodes.Status201Created);
                    case Model.enums.InsertResultType.SQLERROR:
                        return StatusCode(StatusCodes.Status500InternalServerError);
                    case Model.enums.InsertResultType.EXISTINGPRIMARYKEY:
                        return StatusCode(StatusCodes.Status409Conflict);
                    case Model.enums.InsertResultType.INVALIDARGUMENT:
                        return StatusCode(StatusCodes.Status406NotAcceptable);
                    case Model.enums.InsertResultType.ERROR:
                        return StatusCode(StatusCodes.Status503ServiceUnavailable);
                    default:
                        break;
                }
                throw;
            }
        }

        [Authorize(Roles = "1")]
        [HttpPut()]
        public IActionResult Update([FromBody] AddressDto obj, [FromHeader] string Authorization)
        {
            AddressDto newObj = _repo.Update(obj);
            return Ok(newObj);
        }
    }
}
