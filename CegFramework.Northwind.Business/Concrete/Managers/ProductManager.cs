using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using CegFramework.Core.Aspects.Postsharp;
using CegFramework.Core.Aspects.Postsharp.AuthorizationAspects;
using CegFramework.Core.Aspects.Postsharp.CacheAspects;
using CegFramework.Core.Aspects.Postsharp.ExceptionAspects;
using CegFramework.Core.Aspects.Postsharp.LogAspects;
using CegFramework.Core.Aspects.Postsharp.PerformanceAspects;
using CegFramework.Core.Aspects.Postsharp.TransactionAspects;
using CegFramework.Core.Aspects.Postsharp.ValidationAspects;
using CegFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using CegFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using CegFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using CegFramework.Core.Utilities.Mappings;
using CegFramework.Northwind.Business.Abstract;
using CegFramework.Northwind.Business.ValidationRules.FluentValidation;
using CegFramework.Northwind.DataAccess.Abstract;
using CegFramework.Northwind.Entities.Concrete;
using FluentValidation.Resources;
using PostSharp.Aspects.Dependencies;

namespace CegFramework.Northwind.Business.Concrete.Managers
{
    [LogAspect(typeof(DatabaseLogger))]
    public class ProductManager:IProductService
    {
        private IProductDal _productDal;
        private readonly IMapper _mapper;

        public ProductManager(IProductDal productDal, IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }

        [CacheAspect(typeof(MemoryCacheManager) )]
        //[SecuredOperation(Roles="Admin" )]
        public List<Product> GetAllProducts()
        {
            //return _productDal.GetList();

            //var products = AutoMapperHelper.MapToSameTypeList(_productDal.GetList());
            var products = _mapper.Map<List<Product>>(_productDal.GetList());
            return products;
        }

     

        public Product GetProductById(int id)
        {
            return _productDal.Get(x=> x.ProductId==id);
        }


        [FluentValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
       
       // [LogAspect(typeof(FileLogger))]
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

        [FluentValidationAspect(typeof(ProductValidator))]
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
