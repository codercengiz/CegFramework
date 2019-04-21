using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CegFramework.Core.DataAccess.EntityFramework;
using CegFramework.Northwind.DataAccess.Abstract;
using CegFramework.Northwind.Entities.ComplexTypes;
using CegFramework.Northwind.Entities.Concrete;
using NHibernate.Hql.Ast.ANTLR.Tree;

namespace CegFramework.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal:EfEntityRepositoryBase<User,NorthwindContext>, IUserDal
    {
        public List<UserRoleItem> GetUserRoles(User user)
        {
            using (NorthwindContext context= new NorthwindContext())
            {
                var result = from ur in context.UserRoles
                    join r in context.Roles
                        on ur.UserId equals user.UserId
                    where ur.UserId == user.UserId
                    select new UserRoleItem {RoleName = r.Name};
                return result.ToList();
            }
        }
    }
}
