using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CegFramework.Northwind.Entities.ComplexTypes;
using CegFramework.Northwind.Entities.Concrete;

namespace CegFramework.Northwind.Business.Abstract
{
    public interface IUserService
    {
        User GetByUserNameAndPassword(string name, string password);
        List<UserRoleItem> GetUserRoles(User user);
    }
}
