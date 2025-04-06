using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrate;

namespace Business.Abstract
{
    public interface IEmployeeService
    {
        IDataResult<List<Employee>> GetAll();
        IDataResult<Employee> GetById(int id);
        IDataResult<List<Employee>> GetByCompanyId(int companyId);

        IResult Add(Employee employee);
        IResult Delete(Employee employee);
        IResult Update(Employee employee);
    }
}