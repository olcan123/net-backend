using Core.Utilities.Results;
using Entities.Concrate;

namespace Business.Abstract
{
    public interface ISalaryHeadService
    {
        IDataResult<List<SalaryHead>> GetAll();
        IDataResult<SalaryHead> GetById(int id);

        IResult Add(SalaryHead salaryHead);
        IResult Update(SalaryHead salaryHead);
        IResult Delete(int id);
    }
}