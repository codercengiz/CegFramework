using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CegFramework.Core.DataAccess;
using CegFramework.Northwind.Entities.Concrete;

namespace CegFramework.Northwind.DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        //sometimes we have to write code for only product
        //such as: GetComplexProducts
        

    }
}
