using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CegFramework.Northwind.Business.Abstract;
using CegFramework.Northwind.Entities.Concrete;
using CegFramework.Northwind.MvcWebUI.Models;

namespace CegFramework.Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: Product
        public ActionResult Index()
        {
            var model = new ProductListViewModel
            {
                Products = _productService.GetAllProducts()
            };

            return View(model);
        }

        public string Add()
        {
            _productService.AddProduct(new Product
            {
                CategoryId = 1,
                ProductName = "CustomAdded",
                QuantityPerUnit = "2",
                UnitPrice = 23,
                SupplierId = 1,

            });
            return "Added";
        }

        public string AddUpdate()
        {
            _productService.TransactionalOperation(new Product
            {
                CategoryId = 1,
                ProductName = "CustomAdded3",
                QuantityPerUnit = "2",
                UnitPrice = 23,
                SupplierId = 1,

            },
                new Product
                {
                    CategoryId = 1,
                    ProductName = "CustomAdded",
                    QuantityPerUnit = "2",
                    UnitPrice = 0,
                    SupplierId = 1,

                });
            return "done";
        }
    }
}