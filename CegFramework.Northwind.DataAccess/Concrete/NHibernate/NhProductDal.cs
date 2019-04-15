using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CegFramework.Core.DataAccess.NHibernate;
using CegFramework.Northwind.DataAccess.Abstract;
using CegFramework.Northwind.Entities.ComplexTypes;
using CegFramework.Northwind.Entities.Concrete;
using NHibernate.Linq;

namespace CegFramework.Northwind.DataAccess.Concrete.NHibernate
{
    public class NhProductDal:NhEntityRepositoryBase<Product>, IProductDal
    {
        private NHibernateHelper _nHibernateHelper;
        public NhProductDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }

        public List<ProductDetail> GetProductDetails()
        {
            using (var session=_nHibernateHelper.OpenSession())
            {
                var result = from p in session.Query<Product>()
                    join c in session.Query<Category>() on p.CategoryId equals c.CategoryId
                    select new ProductDetail
                    {
                        ProductName = p.ProductName,
                        ProductId = p.ProductId,
                        QuantityPerUnit = p.QuantityPerUnit,
                        CategoryName = c.CategoryName,
                        UnitPrice = p.UnitPrice,
                        ReorderLevel = p.ReorderLevel,
                        Discontinued = p.Discontinued,
                        UnitsOnOrder = p.UnitsOnOrder,
                        UnitsInStock = p.UnitsInStock,
                        SupplierId = p.SupplierId
                    };
                return result.ToList();
            }
        }
    }
}
