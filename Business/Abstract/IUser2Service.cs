using Core.Entities.Concreate;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUser2Service
    {

        List<OperationClaim> GetClaims(User2 user);
        void Add(User2 user);
        User2 GetByMail(string email);
    }
}
