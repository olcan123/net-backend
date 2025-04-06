using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;

namespace Business.Concrate
{
    public class IsoftAccountManager : IIsoftAccountService
    {
        private readonly IIsoftAccountDal _isoftAccountDal;

        public IsoftAccountManager(IIsoftAccountDal isoftAccountDal)
        {
            _isoftAccountDal = isoftAccountDal;
        }

        public IDataResult<IsoftAccount> Get(int id)
        {
            var isoftAccount = _isoftAccountDal.Get(x => x.Id == id);
            return new SuccessDataResult<IsoftAccount>(isoftAccount);
        }

        public IDataResult<IsoftAccount> GetByCompanyId(int companyId)
        {
            var isoftAccount = _isoftAccountDal.Get(x => x.CompanyId == companyId);
            return new SuccessDataResult<IsoftAccount>(isoftAccount);
        }

        public IDataResult<List<IsoftAccount>> GetAll()
        {
            var isoftAccounts = _isoftAccountDal.GetAll();
            return new SuccessDataResult<List<IsoftAccount>>(isoftAccounts);
        }

        public IResult Add(IsoftAccount isoftAccount)
        {
            _isoftAccountDal.Add(isoftAccount);
            return new SuccessResult("Isoft hesabı eklendi");
        }

        public IResult Delete(IsoftAccount isoftAccount)
        {
            _isoftAccountDal.Delete(isoftAccount);
            return new SuccessResult("Isoft hesabı silindi");
        }

        public IResult Update(IsoftAccount isoftAccount)
        {
            _isoftAccountDal.Update(isoftAccount);
            return new SuccessResult("Isoft hesabı güncellendi");
        }
    }
}