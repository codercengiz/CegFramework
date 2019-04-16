using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CegFramework.Northwind.Entities.Concrete;

namespace CegFramework.Northwind.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAllProducts();

        Product GetProductById(int id);

        Product AddProduct(Product product);
        Product UpdateProduct(Product product);
        void TransactionalOperation(Product product1, Product product2);

    }
}
