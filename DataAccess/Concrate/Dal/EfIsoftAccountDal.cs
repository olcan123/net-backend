using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrate.EntityFramework.Context;
using Entities.Concrate;

namespace DataAccess.Concrate.Dal
{
    public class EfIsoftAccountDal : EfEntityRepositoryBase<IsoftAccount, EmpCalcContext>, IIsoftAccountDal
    {
        
    }
}