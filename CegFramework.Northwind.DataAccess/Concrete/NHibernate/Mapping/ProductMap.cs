using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CegFramework.Northwind.Entities.Concrete;
using FluentNHibernate.Mapping;

namespace CegFramework.Northwind.DataAccess.Concrete.NHibernate.Mapping
{
    public class ProductMap:ClassMap<Product>
    {
        public ProductMap()
        {
            Table(@"Products");
            LazyLoad();
            Id(x => x.ProductId).Column("ProductID");
            Map(x => x.CategoryId).Column("CategoryID");
            Map(x => x.ProductName).Column("ProductName");
            Map(x => x.Discontinued).Column("Discontinued");
            Map(x => x.QuantityPerUnit).Column("QuantityPerUnit");
            Map(x => x.ReorderLevel).Column("ReorderLevel");
            Map(x => x.SupplierId).Column("SupplierId");
            Map(x => x.UnitPrice).Column("UnitPrice");
            Map(x => x.UnitsInStock).Column("UnitsInStock");
            Map(x => x.UnitsOnOrder).Column("UnitsOnOrder");
        }

    }
}
