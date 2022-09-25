using Core.DataAccess;
using Core.Entities.Concreate;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUser2Dal : IEntityRepository<User2>
    {
        List<OperationClaim> GetClaims(User2 user);
    }
}
