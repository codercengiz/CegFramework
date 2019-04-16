using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using CegFramework.Core.Aspects.Postsharp;
using CegFramework.Core.Aspects.Postsharp.CacheAspects;
using CegFramework.Core.Aspects.Postsharp.LogAspects;
using CegFramework.Core.Aspects.Postsharp.TransactionAspects;
using CegFramework.Core.Aspects.Postsharp.ValidationAspects;
using CegFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using CegFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using CegFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using CegFramework.Northwind.Business.Abstract;
using CegFramework.Northwind.Business.ValidationRules.FluentValidation;
using CegFramework.Northwind.DataAccess.Abstract;
using CegFramework.Northwind.Entities.Concrete;
using FluentValidation.Resources;

namespace CegFramework.Northwind.Business.Concrete.Managers
{
    public class ProductManager:IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [CacheAspect(typeof(MemoryCacheManager) )]
        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        public List<Product> GetAllProducts()
        {
            return _productDal.GetList();
        }

        public Product GetProductById(int id)
        {
            return _productDal.Get(x=> x.ProductId==id);
        }


        [FluentValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Product AddProduct(Product product)
        {
           // ValidatorTool.FluentValidate(new ProductValidator(), product);
            return _productDal.Add(product);
        }
        [FluentValidationAspect(typeof(ProductValidator))]
        public Product UpdateProduct(Product product)
        {
            //ValidatorTool.FluentValidate(new ProductValidator(), product);
            return _productDal.Update(product);
        }

        [TransactionScopeAspect]
        public void TransactionalOperation(Product product1, Product product2)
        {
            _productDal.Add(product1);
            _productDal.Update(product2);
        }


        /* this below is transactinal method with dont use ASPECT
        public void TransactionalOperation(Product product1, Product product2)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                 _productDal.Add(product1);
                            _productDal.Update(product2);
                            scope.Complete();
                }
                catch 
                {
                   scope.Dispose();
                }
            }
            
           
        }*/
    }
}
