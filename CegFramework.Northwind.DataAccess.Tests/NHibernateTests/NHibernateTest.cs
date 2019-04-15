using System;
using CegFramework.Northwind.DataAccess.Concrete.EntityFramework;
using CegFramework.Northwind.DataAccess.Concrete.NHibernate;
using CegFramework.Northwind.DataAccess.Concrete.NHibernate.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CegFramework.Northwind.DataAccess.Tests.NHibernateTests
{
    [TestClass]
    public class NHibernateTest
    {
        [TestMethod]
        public void Get_all_returns_all_products()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());

            var result = productDal.GetList();

            Assert.AreEqual(77, result.Count);
        }
        [TestMethod]
        public void Get_all_with_parameters_returns_filtered_products()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());

            var result = productDal.GetList(x => x.ProductName.Contains("ab"));

            Assert.AreEqual(4, result.Count);
        }
        [TestMethod]
        public void Get_all_returns_all_categories()
        {
            NhCategoryDal categoryDal = new NhCategoryDal(new SqlServerHelper());

            var result = categoryDal.GetList();

            Assert.AreEqual(8, result.Count);
        }
        [TestMethod]
        public void Get_all_productdetails()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());

            var result = productDal.GetProductDetails();

            Assert.AreEqual(77, result.Count);
        }
    }
}
