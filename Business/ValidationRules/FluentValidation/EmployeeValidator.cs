using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrate;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(e=>e.FirstName).NotEmpty().WithMessage("Ad Boş Olamaz.");
            RuleFor(e=>e.FirstName).MaximumLength(100).WithMessage("Ad 100 Karakterden Oluşmalıdır.");
            RuleFor(e=>e.LastName).NotEmpty().WithMessage("Soyad Boş Olamaz.");
            RuleFor(e=>e.LastName).MaximumLength(100).WithMessage("Soyad 100 Karakterden Oluşmalıdır.");
            RuleFor(e=>e.Address).NotEmpty().WithMessage("Adres Boş Olamaz.");
            RuleFor(e=>e.Address).MaximumLength(250).WithMessage("Adres 250 Karakterden Oluşmalıdır.");
            RuleFor(e=>e.City).NotEmpty().WithMessage("Şehir Boş Olamaz.");
            RuleFor(e=>e.City).MaximumLength(50).WithMessage("Şehir 50 Karakterden Oluşmalıdır.");
            RuleFor(e=>e.Country).NotEmpty().WithMessage("Ülke Boş Olamaz.");
            RuleFor(e=>e.Country).MaximumLength(50).WithMessage("Ülke 50 Karakterden Oluşmalıdır.");
            RuleFor(e=>e.IsoftId).NotEmpty().WithMessage("Isoft Id Boş Olamaz.");
            RuleFor(e=>e.NationalIdentity).NotEmpty().WithMessage("Kimlik Numarası Boş Olamaz.");
            RuleFor(e=>e.NationalIdentity).MaximumLength(21).WithMessage("Kimlik Numarası 21 Karakterden Oluşmalıdır.");
        }
    }
}