using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CegFramework.Northwind.Business.Abstract;
using CegFramework.Northwind.DataAccess.Abstract;
using CegFramework.Northwind.DataAccess.Concrete.EntityFramework;
using CegFramework.Northwind.Entities.ComplexTypes;
using CegFramework.Northwind.Entities.Concrete;

namespace CegFramework.Northwind.Business.Concrete.Managers
{
    public class UserManager:IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User GetByUserNameAndPassword(string name, string password)
        {
            return _userDal.Get(u => u.UserName == name && u.Password == password);
        }

        public List<UserRoleItem> GetUserRoles(User user)
        {
            return _userDal.GetUserRoles(user);
        }
    }
}
