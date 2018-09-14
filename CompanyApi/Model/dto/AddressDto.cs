using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyApi.Model.dto
{
    public class AddressDto
    {
        public int Id { get; set; }
        public int PostalCode { get; set; }
        public string Street { get; set; }
    }
}
