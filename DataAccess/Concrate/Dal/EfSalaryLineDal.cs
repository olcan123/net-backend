using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrate.EntityFramework.Context;
using EFCore.BulkExtensions;
using Entities.Concrate;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrate.Dal
{
    public class EfSalaryLineDal : EfEntityRepositoryBase<SalaryLine, EmpCalcContext>, ISalaryLineDal
    {
        public void BulkDeleteBySalaryHeadId(int salaryHeadId)
        {
            using var context = new EmpCalcContext();
            context.SalaryLines.Where(x => x.SalaryHeadId == salaryHeadId).ExecuteDelete();
        }
    }
}