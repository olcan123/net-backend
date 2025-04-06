using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using ServiceStack;

namespace Business.Concrate
{
    public class EmployeeManager : IEmployeeService
    {

        private readonly IEmployeeDal _employeeDal;

        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        public IDataResult<List<Employee>> GetAll()
        {
            var employees = _employeeDal.GetAll();
            return new SuccessDataResult<List<Employee>>(employees);
        }

        public IDataResult<Employee> GetById(int id)
        {
            var employee = _employeeDal.Get(x => x.Id == id);
            return new SuccessDataResult<Employee>(employee);
        }

        public IDataResult<List<Employee>> GetByCompanyId(int companyId)
        {
            var employees = _employeeDal.GetAll(x => x.CompanyId == companyId && x.IsActive == true);
            return new SuccessDataResult<List<Employee>>(employees);
        }

        [ValidationAspect(typeof(EmployeeValidator))]
        public IResult Add(Employee employee)
        {
            _employeeDal.Add(employee);
            return new SuccessResult("Çalışan Eklendi");
        }

        public IResult Delete(Employee employee)
        {
            _employeeDal.Delete(new Employee { Id = employee.Id });
            return new SuccessResult("Çalışan Silindi");
        }

        [ValidationAspect(typeof(EmployeeValidator))]
        public IResult Update(Employee employee)
        {
            _employeeDal.Update(employee);
            return new SuccessResult("Çalışan Güncellendi");
        }
    }
}