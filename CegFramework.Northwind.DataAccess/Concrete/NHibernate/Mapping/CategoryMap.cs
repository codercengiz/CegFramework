using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CegFramework.Northwind.Entities.Concrete;
using FluentNHibernate.Mapping;

namespace CegFramework.Northwind.DataAccess.Concrete.NHibernate.Mapping
{
    class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Table(@"Categories");
            LazyLoad();
            Id(x => x.CategoryId).Column("CategoryID");
            Map(x => x.CategoryName).Column("CategoryName");
            Map(x => x.Description).Column("Description");
            Map(x => x.Picture).Column("Picture");
        }

    }
}
