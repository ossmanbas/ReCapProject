using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]

        public IResult Add(User user)
        {
            IResult result = BusinessRules.Run(CheckUserMailExists(user.Email));
            if (result != null)
            {
                return result;
            }

            _userDal.Add(user);
            return new SuccessResult();

        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult();
        }

        public IDataResult<List<User>> GetAll()
        {
            if (DateTime.Now.Hour == 21)
            {
                return new ErrorDataResult<List<User>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(x => x.Id == id));
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult();
        }

        private IResult CheckUserMailExists(string userMail)
        {
            var result = _userDal.GetAll(u => u.Email == userMail).Any(); // Any bize bool döner.
            if (result)
            {
                return new ErrorResult(Messages.MailNameAlreadyExists);
            }
            return new SuccessResult();

        }
    }
}
