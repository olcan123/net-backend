using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrate;

namespace Business.Abstract
{
    public interface ICompanyService
    {
        IDataResult<List<Company>> GetAll();
        IDataResult<Company> GetById(int id);

        IResult Add(Company company);
        IResult Update(Company company);
        IResult Delete(Company company);
    }
}