using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;

namespace Business.Concrate
{
    public class CompanyManager : ICompanyService
    {
        private readonly ICompanyDal _companyDal;

        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }

        public IDataResult<List<Company>> GetAll()
        {
            var companies = _companyDal.GetAll();
            return new SuccessDataResult<List<Company>>(companies);
        }

        public IDataResult<Company> GetById(int id)
        {
            var company = _companyDal.Get(x => x.Id == id);
            return new SuccessDataResult<Company>(company);
        }

        [ValidationAspect(typeof(CompanyValidator))]
        public IResult Add(Company company)
        {
            _companyDal.Add(company);
            return new SuccessResult("Şirket Eklendi");
        }

        public IResult Delete(Company company)
        {
            _companyDal.Delete(company);
            return new SuccessResult("Şirket Silindi");
        }

        [ValidationAspect(typeof(CompanyValidator))]
        public IResult Update(Company company)
        {
            _companyDal.Update(company);
            return new SuccessResult("Şirket Güncellendi");
        }
    }
}