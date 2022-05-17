using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ResinShop.Core.Entities;
using ResinShop.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResinShop.DAL.Tests
{
    public class TestCustomerRepo
    {
        CustomerRepository db;
        DBFactory dbf;

        [SetUp]
        public void Setup()
        {
            ConfigProvider cp = new ConfigProvider();
            dbf = new DBFactory(cp.Config, FactoryMode.TEST);
            db = new CustomerRepository(dbf);
            dbf.GetDbContext().Database.ExecuteSqlRaw("SetKnownGoodState");
        }

        [Test]
        public void TestGetOneCustomer()
        {
            Assert.AreEqual(1, db.Get(1).Data.CustomerId);
        }

        [Test]
        public void TestAddNewCustomer()
        {
            Customer expected = new Customer
            {
                FirstName = "Wanda",
                LastName = "James",
                Email = "wjames@test.com",
                PhoneNumber = "5041234567",
                StreetAddress = "425 Malbee Lane",
                City = "New Hope",
                StateName = "NJ",
                ZipCode = "98042"
            };

            db.Insert(expected);
            expected.CustomerId = 4;

            Assert.AreEqual(expected.CustomerId, db.Get(4).Data.CustomerId);
        }

        [Test]
        public void TestUpdateCustomer()
        {
            Customer customer = db.Get(1).Data;
            customer.FirstName = "Adeline";
            customer.LastName = "Fulcher";
            customer.Email = "afulcher4@tiny.cc";
            customer.PhoneNumber = "2164319017";
            customer.StreetAddress = "58164 Algoma Hill";
            customer.City = "Cleveland";
            customer.StateName = "OH";
            customer.ZipCode = "44105";
            db.Update(customer);

            Assert.AreEqual(customer.CustomerId, db.Get(1).Data.CustomerId);
            Assert.AreEqual(customer.FirstName, db.Get(1).Data.FirstName);
        }

        [Test]
        public void TestDeleteCustomer()
        {
            db.Delete(1);
            Assert.AreEqual(null, db.Get(1).Data);
        }

    }
}