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
    public class SalaryHeadManager : ISalaryHeadService
    {
        private readonly ISalaryHeadDal _salaryHeadDal;

        public SalaryHeadManager(ISalaryHeadDal salaryHeadDal)
        {
            _salaryHeadDal = salaryHeadDal;
        }

        public IDataResult<List<SalaryHead>> GetAll()
        {
            var salaryHeads = _salaryHeadDal.GetAll(null, x => x.SalaryLines);
            return new SuccessDataResult<List<SalaryHead>>(salaryHeads);
        }

        public IDataResult<SalaryHead> GetById(int id)
        {
            var salaryHead = _salaryHeadDal.Get(x => x.Id == id, x => x.SalaryLines);
            return new SuccessDataResult<SalaryHead>(salaryHead);
        }

        public IResult Add(SalaryHead salaryHead)
        {
            _salaryHeadDal.Add(salaryHead);
            return new SuccessResult("Maaş Başlığı Eklendi");
        }

        public IResult Delete(int id)
        {
            _salaryHeadDal.Delete(new SalaryHead { Id = id });
            return new SuccessResult("Maaş Başlığı Silindi");
        }

        public IResult Update(SalaryHead salaryHead)
        {
            _salaryHeadDal.Update(salaryHead);
            return new SuccessResult("Maaş Başlığı Güncellendi");
        }
    }
}