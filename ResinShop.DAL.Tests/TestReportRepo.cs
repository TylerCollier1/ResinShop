using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ResinShop.Core;
using ResinShop.Core.DTO;
using ResinShop.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResinShop.DAL.Tests
{
    public class TestReportRepo
    {
        ReportsRepository db;

        [SetUp]
        public void Setup()
        {
            ConfigProvider cp = new ConfigProvider();
            db = new ReportsRepository(cp.Config);
        }

        [Test]
        public void TestCustomerInfo()
        {
            Response<List<CustomerInfo>> actual = db.GetCustomerInfo(1);
            Assert.IsTrue(actual.Success);

            Assert.AreEqual(1, db.GetCustomerInfo(1).Data.Count);
        }

        [Test]
        public void TestCustomerOrders()
        {
            Response<List<CustomerOrders>> actual = db.GetCustomerOrders(1);
            Assert.IsTrue(actual.Success);

            Assert.AreEqual(1, db.GetCustomerOrders(1).Data.Count);
        }

        [Test]
        public void TestCustomerQuotes()
        {
            Response<List<CustomerQuotes>> actual = db.GetCustomerQuotes(1);
            Assert.IsTrue(actual.Success);

            Assert.AreEqual(1, db.GetCustomerQuotes(1).Data.Count);
        }

    }
}
