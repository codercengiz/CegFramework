using System;
using CegFramework.Northwind.Business.Concrete.Managers;
using CegFramework.Northwind.DataAccess.Abstract;
using CegFramework.Northwind.Entities.Concrete;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CegFramework.Northwind.Business.Tests
{
    [TestClass]
    public class ProductManagerTest
    {
        [ExpectedException(typeof(ValidationException))]//If there is no ValidationException test is success.
        [TestMethod]
        public void Product_validation_check()
        {
            Mock<IProductDal> mock= new Mock<IProductDal>();
            ProductManager productManager= new ProductManager(mock.Object);

            productManager.AddProduct(new Product());
        }
    }
}
