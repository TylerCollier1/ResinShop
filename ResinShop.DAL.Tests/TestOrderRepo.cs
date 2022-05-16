using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ResinShop.Core.Entities;
using ResinShop.DAL.Repositories;

namespace ResinShop.DAL.Tests
{
    public class TestOrderRepo
    {
        OrderRepository db;
        CustomerRepository cr;
        ArtRepository ar;

        [SetUp]
        public void Setup()
        {
            OrderRepository setup = new OrderRepository(FactoryMode.TEST);
            setup.SetKnownGoodState();
            db = setup;
        }

        [Test]
        public void TestGet()
        {
            Assert.AreEqual(1, db.Get(1).Data.OrderId);
        }

        [Test]
        public void TestAddNewOrder()
        {
            Order expected = new Order
            {
                CustomerId = 4, // need to double check
                ArtId = 4,  // need to double check
                OrderDate = new DateTime(2022, 10, 3)
            };

            Assert.AreEqual(expected, db.Get(4).Data);
            Assert.AreEqual(expected, db.Get(4).Data);
        }

        [Test]
        public void TestUpdateOrder()
        {
            Order order = db.Get(3).Data;
            order.ArtId = 5;        // need to double check
            order.CustomerId = 5;   // need to double check
            order.OrderDate = new DateTime(2022, 06, 20);
            db.Update(order);

            Assert.AreEqual(order.ArtId, ar.Get(5).Data);
            Assert.AreEqual(order.CustomerId, cr.Get(5).Data);
        }

        [Test]
        public void TestDeleteOrder()
        {
            db.Delete(1);
            Assert.AreEqual(null, db.Get(1).Data);
        }
    }
}
