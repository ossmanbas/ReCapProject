using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Email).EmailAddress(); // İsim Boş Geçilemez
            RuleFor(u => u.Password).NotNull(); // İsim Boş Geçilemez
            RuleFor(u => u.FirstName).MinimumLength(3); // İsim en az 3 karakter olmalıdır.
            RuleFor(u => u.LastName).MinimumLength(3);
        }
    }
}
