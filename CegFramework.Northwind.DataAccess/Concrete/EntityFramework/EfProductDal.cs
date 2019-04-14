using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CegFramework.Core.DataAccess.EntityFramework;
using CegFramework.Northwind.DataAccess.Abstract;
using CegFramework.Northwind.Entities.Concrete;

namespace CegFramework.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal :EfEntityRepositoryBase<Product,NorthwindContext>, IProductDal
    {



    }
}
