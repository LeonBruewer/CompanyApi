using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyApi.Model.dto
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public int AddressId { get; set; }
    }
}
