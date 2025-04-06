using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using EFCore.BulkExtensions;
using Entities.Concrate;
using ServiceStack;

namespace Business.Concrate
{
    public class SalaryLineManager : ISalaryLineService
    {
        private readonly ISalaryHeadService _salaryHeadService;
        private readonly ISalaryLineDal _salaryLineDal;

        public SalaryLineManager(ISalaryHeadService salaryHeadService, ISalaryLineDal salaryLineDal)
        {
            _salaryHeadService = salaryHeadService;
            _salaryLineDal = salaryLineDal;
        }

        public IResult BulkAdd(SalaryHead salaryHead, List<SalaryLine> salaryLines)
        {
            _salaryHeadService.Add(salaryHead);

            foreach (SalaryLine line in salaryLines)
                line.SalaryHeadId = salaryHead.Id;

            _salaryLineDal.BulkAdd(salaryLines);
            return new SuccessResult("Maaş Başlığı Eklendi");
        }

        public IResult BulkInsertOrUpdate(SalaryHead salaryHead, List<SalaryLine> salaryLines)
        {
            _salaryHeadService.Update(salaryHead);

            foreach (SalaryLine line in salaryLines)
                line.SalaryHeadId = salaryHead.Id;

            _salaryLineDal.BulkInsertOrUpdate(salaryLines);
            return new SuccessResult("Maaş Başlığı Güncellendi");
        }

        public IResult DeleteBySalaryHeadId(int salaryHeadId)
        {
            _salaryLineDal.BulkDeleteBySalaryHeadId(salaryHeadId);
            var result = _salaryHeadService.Delete(salaryHeadId);
            return new SuccessResult(result.Message);
        }

        public IResult DeleteBySalaryLineId(int salaryLineId)
        {
            _salaryLineDal.Delete(new SalaryLine { Id = salaryLineId });
            return new SuccessResult("Maaş Başlığı Silindi");
        }
    }
}