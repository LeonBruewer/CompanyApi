using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace CompanyApi.Controller
{
    [Route("api/Address")]
    public class Address : Microsoft.AspNetCore.Mvc.Controller
    {
        private Repository.Address _repo = Repository.Address.GetInstatnce();

        [HttpGet()]
        public IActionResult Get()
        {
            List<Model.Address> retval;
            
            retval = _repo.GetModelList();
            
            if (retval.Count == 0)
                return StatusCode(StatusCodes.Status204NoContent);

            return Ok(retval);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int Id)
        {
            List<Model.Address> retval;

            retval = _repo.GetById(Id);

            if (retval.Count == 0)
                return StatusCode(StatusCodes.Status204NoContent);

            return Ok(retval);
        }
        
        [HttpPost()]
        public IActionResult Add([FromBody] Model.dto.AddressDto obj)
        {
            try
            {
                Model.dto.AddressDto newObj = _repo.Add(obj);
                return Ok(newObj);
            }
            catch (Helper.RepositoryException<Model.enums.InsertResultType> ex)
            {
                switch (ex.Type)
                {
                    case Model.enums.InsertResultType.OK:
                        return StatusCode(StatusCodes.Status201Created);
                        break;
                    case Model.enums.InsertResultType.SQLERROR:
                        return StatusCode(StatusCodes.Status500InternalServerError);
                        break;
                    case Model.enums.InsertResultType.EXISTINGPRIMARYKEY:
                        return StatusCode(StatusCodes.Status409Conflict);
                        break;
                    case Model.enums.InsertResultType.INVALIDARGUMENT:
                        return StatusCode(StatusCodes.Status406NotAcceptable);
                        break;
                    case Model.enums.InsertResultType.ERROR:
                        return StatusCode(StatusCodes.Status503ServiceUnavailable);
                        break;
                    default:
                        break;
                }
                throw;
            }
        }

        [HttpPut()]
        public IActionResult Update([FromBody] Model.dto.AddressDto obj)
        {
            Model.dto.AddressDto newObj = _repo.Update(obj);
            return Ok(newObj);
        }
    }
}
