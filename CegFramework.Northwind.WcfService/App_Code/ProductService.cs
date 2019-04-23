using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CegFramework.Northwind.Business.Abstract;
using CegFramework.Northwind.Business.DependencyResolvers.Ninject;
using CegFramework.Northwind.Entities.Concrete;

/// <summary>
/// Summary description for ProductService
/// </summary>
public class ProductService:IProductService
{
    public ProductService()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private IProductService _productService = InstanceFactory.GetInstance<IProductService>();
    public Product AddProduct(Product product)
    {
        return _productService.AddProduct(product);
    }

    public List<Product> GetAllProducts()
    {
        return _productService.GetAllProducts();
    }

    public Product GetProductById(int id)
    {
        return _productService.GetProductById(id);
    }

    public void TransactionalOperation(Product product1, Product product2)
    {
         _productService.TransactionalOperation(product1,product2);
    }

    public Product UpdateProduct(Product product)
    {
        return _productService.UpdateProduct(product);
    }
}