using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrate;

namespace DataAccess.Abstract
{
    public interface ISalaryLineDal : IEntityRepository<SalaryLine>
    {
        void BulkDeleteBySalaryHeadId(int salaryHeadId);
    }
}