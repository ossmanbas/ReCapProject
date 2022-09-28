using Business.Abstract;
using Core.Entities.Concreate;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class User2Manager : IUser2Service
    {
        IUser2Dal _user2Dal;

        public User2Manager(IUser2Dal userDal)
        {
            _user2Dal = userDal;
        }

        public List<OperationClaim> GetClaims(User2 user)
        {
            return _user2Dal.GetClaims(user);
        }

        public void Add(User2 user)
        {
            _user2Dal.Add(user);
        }

        public User2 GetByMail(string email)
        {
            return _user2Dal.Get(u => u.Email == email);
        }
    }

}
