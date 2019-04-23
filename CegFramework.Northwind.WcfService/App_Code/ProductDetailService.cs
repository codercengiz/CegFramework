using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CegFramework.Northwind.Business.Abstract;
using CegFramework.Northwind.Business.DependencyResolvers.Ninject;
using CegFramework.Northwind.Business.ServiceContracts.Wcf;
using CegFramework.Northwind.Entities.Concrete;

/// <summary>
/// Summary description for ProductDetailService
/// </summary>
public class ProductDetailService:IProductDetailService
{
    private IProductService _productService = InstanceFactory.GetInstance<IProductService>();

    public List<Product> GetAllProducts()
    {
       return  _productService.GetAllProducts();
    }
}