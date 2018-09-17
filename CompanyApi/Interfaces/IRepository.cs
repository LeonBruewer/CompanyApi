using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyApi.Interfaces
{
    public interface IRepository<T, Dto>
    {
        List<T> GetModelList();
        List<T> GetById(int Id);
        Dto Add(Dto Model);
        Dto Update(Dto Model);
    }
}
