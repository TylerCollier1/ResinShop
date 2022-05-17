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
                CustomerId = 2, // need to double check
                ArtId = 3,  // need to double check
                OrderDate = new DateTime(2022, 11, 20)
            };

            var add = db.Insert(expected);
            Assert.IsTrue(add.Success);
            Assert.AreEqual(expected.ArtId, db.Get(4).Data.ArtId);
            Assert.AreEqual(expected.CustomerId, db.Get(4).Data.CustomerId);
        }

        [Test]
        public void TestUpdateOrder()
        {
            Order order = db.Get(3).Data;
            order.ArtId = 3;        // need to double check
            order.CustomerId = 1;   // need to double check
            order.OrderDate = new DateTime(2022, 10, 3);
            
            var update = db.Update(order);
            Assert.IsTrue(update.Success);
            Assert.AreEqual(order.ArtId, db.Get(3).Data.ArtId);
            Assert.AreEqual(order.CustomerId, db.Get(1).Data.CustomerId);
        }

        [Test]
        public void TestDeleteOrder()
        {
            db.Delete(1);
            Assert.AreEqual(null, db.Get(1).Data);
        }
    }
}
