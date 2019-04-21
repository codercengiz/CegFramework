using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CegFramework.Core.DataAccess;
using CegFramework.Core.DataAccess.EntityFramework;
using CegFramework.Core.DataAccess.NHibernate;
using CegFramework.Northwind.Business.Abstract;
using CegFramework.Northwind.Business.Concrete.Managers;
using CegFramework.Northwind.DataAccess.Abstract;
using CegFramework.Northwind.DataAccess.Concrete.EntityFramework;
using CegFramework.Northwind.DataAccess.Concrete.NHibernate;
using CegFramework.Northwind.DataAccess.Concrete.NHibernate.Helpers;
using CegFramework.Northwind.Entities.Concrete;
using Ninject.Modules;

namespace CegFramework.Northwind.Business.DependencyResolvers.Ninject
{
    public class BusinessModule:NinjectModule
    {
        public override void Load()
        {
            
            
            //Bind<IQueryableRepository<Product>>().To<EfQueryableRepositoryBase<Product>>();
            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepositoryBase<>));
            Bind<DbContext>().To<NorthwindContext>();
            Bind<NHibernateHelper>().To<SqlServerHelper>();


            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();

            Bind<IUserService>().To<UserManager>().InSingletonScope();
            Bind<IUserDal>().To<EfUserDal>().InSingletonScope();
        }
    }
}
