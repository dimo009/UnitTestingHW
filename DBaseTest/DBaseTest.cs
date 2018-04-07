using DBase;
using NUnit.Framework;
using System;
using System.Linq;

namespace DBaseTest
{
   

   [TestFixture]
    public class DBaseTest
    {
        private Database<int> database;

        [Test]
        public void TestAddFuction()
        {

            var db = InstantiateDB();

            db.Add(6);

            Assert.That(db.Count, Is.EqualTo(4));
            Assert.That(db.Last(), Is.EqualTo(6));
        }

        [Test]
        public void TestRemoveFunction()
        {
            var db = InstantiateDB();
            
            db.Remove();
           

            Assert.That(db.Count, Is.EqualTo(2));

        

        }
        

        [Test]
        [TestCase(2)]
        [TestCase(2, 3)]
        [TestCase(2, 3, 4, 5)]
        [TestCase(2, 3, 4, 5, 6, 7)]
        [TestCase(2, 3, 4, 5, 6, 7, 8, 9)]
        public void DirectDatabaseInitializationConstructorWithCollectionOfNumbersWorksCorrectly(params int[] numbers)
        {
            
            var db = new Database<int>(numbers);

            
            db.Add(int.MaxValue);
            db.Remove();
            var databaseContent = db.Fetch();

            
            for (int i = 0; i < numbers.Length; i++)
            {
                Assert.AreEqual(databaseContent[i], numbers[i]);
            }
        }


        


        [Test]
        public void CanNotInitializeDatabaseWithCollectionContainingMoreThanItsCapacity()
        {
            // Arrange
            var testCollection = new int[17];

            // Assert
            Assert.Throws<InvalidOperationException>(() => this.database = new Database<int>(testCollection));
        }

        private Database<int> InstantiateDB()
        {
            var db = new Database<int> { 4, 3, 5 };

            return db;
        }
    }
}

