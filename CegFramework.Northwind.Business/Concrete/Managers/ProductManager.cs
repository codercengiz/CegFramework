using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CegFramework.Northwind.Business.Abstract;
using CegFramework.Northwind.DataAccess.Abstract;
using CegFramework.Northwind.Entities.Concrete;

namespace CegFramework.Northwind.Business.Concrete.Managers
{
    public class ProductManager:IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAllProducts()
        {
            return _productDal.GetList();
        }

        public Product GetProductById(int id)
        {
            return _productDal.Get(x=> x.ProductId==id);
        }

        public Product AddProduct(Product product)
        {
            return _productDal.Add(product);
        }
    }
}
