﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CegFramework.Core.DataAccess.EntityFramework;
using CegFramework.Northwind.DataAccess.Abstract;
using CegFramework.Northwind.Entities.ComplexTypes;
using CegFramework.Northwind.Entities.Concrete;

namespace CegFramework.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal :EfEntityRepositoryBase<Product,NorthwindContext>, IProductDal
    {
        public List<ProductDetail> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                    join c in context.Categories on p.CategoryId equals c.CategoryId
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
