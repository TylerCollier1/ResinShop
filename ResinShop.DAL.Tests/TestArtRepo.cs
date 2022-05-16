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

        [SetUp]
        public void Setup()
        {
            ArtRepository setup = new ArtRepository(FactoryMode.TEST);
            setup.SetKnownGoodState();
            db = setup;
        }


        [Test]
        public void TestGet()
        {
            Assert.AreEqual(1, db.Get(1).Data.ArtId);
        }

        [Test]
        public void TestAddNewArt()
        {
            Art expected = new Art
            {
                Height = 12,
                Width = 12,
                MaterialQuantity = 1,
                ColorQuantity = 1, 
                AdvancedFeatureId = 1,
                Cost = 396
            };

            db.Insert(expected);
            expected.ArtId = 4;

            Assert.AreEqual(expected.ArtId, db.Get(4).Data.ArtId);
        }

        [Test]
        public void TestUpdateArt()
        {
            Art art = db.Get(1).Data;
            art.Height = 15;
            art.Width = 23;
            art.MaterialQuantity = 1;
            art.ColorQuantity = 1;
            art.Cost = 948.75M;
            db.Update(art);

            Assert.AreEqual(art.ArtId, db.Get(1).Data.ArtId);
            Assert.AreEqual(art.Height, db.Get(1).Data.Height);
        }

        [Test]
        public void TestDeleteArt()
        {
            db.Delete(1);
            Assert.AreEqual(null, db.Get(1).Data);
        }
    }
}
