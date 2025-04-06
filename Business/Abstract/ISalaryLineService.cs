using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrate;

namespace Business.Abstract
{
    public interface ISalaryLineService
    {
        IResult BulkAdd(SalaryHead salaryHead, List<SalaryLine> salaryLines);
        IResult DeleteBySalaryLineId(int salaryLineId);
        IResult DeleteBySalaryHeadId(int salaryHeadId);
        IResult BulkInsertOrUpdate(SalaryHead salaryHead, List<SalaryLine> salaryLines);
    }
}