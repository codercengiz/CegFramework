using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using CegFramework.Northwind.Entities.Concrete;

namespace CegFramework.Northwind.Business.Abstract
{
    [ServiceContract] //if you use this service in WCF
    public interface IProductService
    {
        [OperationContract]//if you use this service in WCF
        List<Product> GetAllProducts();
        [OperationContract]
        Product GetProductById(int id);
        [OperationContract]
        Product AddProduct(Product product);

        [OperationContract]
        Product UpdateProduct(Product product);

        [OperationContract]
        void TransactionalOperation(Product product1, Product product2);

    }
}
