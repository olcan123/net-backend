using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrate;

namespace Business.Abstract
{
    public interface IIsoftAccountService
    {
        IDataResult<List<IsoftAccount>> GetAll();
        IDataResult<IsoftAccount> Get(int id);
        IDataResult<IsoftAccount> GetByCompanyId(int companyId);
        IResult Add(IsoftAccount isoftAccount);
        IResult Delete(IsoftAccount isoftAccount);
        IResult Update(IsoftAccount isoftAccount);
    }
}