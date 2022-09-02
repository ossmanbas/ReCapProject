using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c=>c.BrandId).NotEmpty(); // İsim Boş Geçilemez
            RuleFor(c=>c.ColorId).NotEmpty(); // İsim Boş Geçilemez
            RuleFor(c=> c.ModelYear).NotEmpty(); // İsim en az 3 karakter olmalıdır.
            RuleFor(c => c.DailyPrice).GreaterThan(20000);
        }
    }
}
