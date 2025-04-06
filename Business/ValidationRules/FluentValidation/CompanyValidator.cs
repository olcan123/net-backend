using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrate;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Şirket Adı Boş Olamaz.");
            RuleFor(c => c.UidNumber).NotEmpty().WithMessage("UID Numara Boş Olamaz.");
            RuleFor(c => c.UidNumber).Length(9).WithMessage("UID Numara 9 Karakterden Oluşmalıdır.");
            RuleFor(c=>c.Address).NotEmpty().WithMessage("Adres Boş Olamaz.");
            RuleFor(c=>c.Address).MaximumLength(250).WithMessage("Adres 250 Karakterden Oluşmalıdır.");
            RuleFor(c=>c.City).NotEmpty().WithMessage("Şehir Boş Olamaz.");
            RuleFor(c=>c.City).MaximumLength(50).WithMessage("Şehir 50 Karakterden Oluşmalıdır.");
            RuleFor(c=>c.Country).NotEmpty().WithMessage("Ülke Boş Olamaz.");
            RuleFor(c=>c.Country).MaximumLength(50).WithMessage("Ülke 50 Karakterden Oluşmalıdır.");
            RuleFor(c=>c.RepresentativeName).NotEmpty().WithMessage("Sorumlu Kişi Adı Boş Olamaz.");
            RuleFor(c=>c.RepresentativeName).MaximumLength(50).WithMessage("Sorumlu Kişi Adı 50 Karakterden Oluşmalıdır.");
        }
        
    }
}