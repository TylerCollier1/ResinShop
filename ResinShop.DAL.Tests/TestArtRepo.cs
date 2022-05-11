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
    public class TestArtRepo
    {
        ArtRepository db;
        Art art = new Art
        {
            ArtId = 1,
            AdvancedFeatureId = 3, // need to consider string vs int
            Height = 32,
            Width = 12,
            MaterialQuantity = 1,
            ColorQuantity = 1,
            Cost = 1056
        };
        Art updateArt = new Art
        {
            ArtId = 1,
            AdvancedFeatureId = 3, // need to consider string vs int
            Height = 40,
            Width = 15,
            MaterialQuantity = 1,
            ColorQuantity = 1,
            Cost = 2012
        };
        Art addArt = new Art
        {
            AdvancedFeatureId = 3, // need to consider string vs int
            Height = 27,
            Width = 27,
            MaterialQuantity = 1,
            ColorQuantity = 1,
            Cost = 3001
        };
        [SetUp]
        public void Setup()
        {
            ArtRepository setup = new ArtRepository(FactoryMode.TEST);
            setup.Temp(); // change to our data name
            db = setup;
        }

        [Test]
        public void TestGet()
        {
            Assert.AreEqual(art.Height, db.Get(1).Data.Height);
        }

        [Test]
        public void TestAdd()
        {
            var add = db.Insert(addArt);
            Assert.IsTrue(add.Success);
            Assert.AreEqual(addArt.Width, db.Get(11).Data.Width);
        }
        [Test]
        public void TestUpdate()
        {
            var update = db.Update(addArt);
            Assert.IsTrue(update.Success);
            Assert.AreEqual(addArt.Height, db.Get(1).Data.Height);
        }
        [Test]
        public void TestDelete()
        {
            var delete = db.Delete(11);
            Assert.IsFalse(delete.Success);
        }
        [Test]
        public void ShouldNotDelete()
        {
            var delete = db.Delete(11);
            Assert.IsFalse(delete.Success);
        }
    }
}
