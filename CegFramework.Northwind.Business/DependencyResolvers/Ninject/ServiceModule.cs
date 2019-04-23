using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CegFramework.Core.Utilities.Common;
using CegFramework.Northwind.Business.Abstract;
using Ninject.Modules;

namespace CegFramework.Northwind.Business.DependencyResolvers.Ninject
{
    public class ServiceModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().ToConstant(WcfProxy<IProductService>.CreateChannel());
        }
    }
}
