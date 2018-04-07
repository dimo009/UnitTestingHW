using DBase;
using DBase.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ExtendedDatabaseTest
{
    [TestFixture]
    public class ExtendedDBTests
    {
        private PeopleDatabase database;

        [SetUp]
        public void TestInitialization()
        {
            this.database = new PeopleDatabase();
        }

        [Test]
        public void InitializeConstructorWithParameters()
        {
            var firstPerson = new People(10L, "Tap");
            var secondPerson = new People(20L, "TapTaDranka");

            var list = new IPerson[] { firstPerson, secondPerson };

            this.database = new PeopleDatabase(list);

            Assert.AreEqual(2, this.database.Count, $"Constructor doesn't work with {typeof(IPerson)} as parameter");
        }

        [Test]
        public void DatabaseInitializeConstructorWithNullLeadsToEmptyDB()
        {
            // Assert
            Assert.DoesNotThrow(() => this.database = new PeopleDatabase(null));
        }

        [Test]

        public void AddingPersonToDatabase()
        {
            var firstPerson = new People(10L, "Tap");



            this.database.Add(firstPerson);


            Assert.That(1, Is.EqualTo(this.database.Count));
        }

        [Test]
        public void RemovePersonFromDatabase()
        {
            var firstPerson = new People(10L, "Tap");
            var secondPerson = new People(20L, "TapTaDranka");

            var list = new IPerson[] { firstPerson, secondPerson };

            this.database = new PeopleDatabase(list);
            database.Remove(firstPerson);

            Assert.That(1, Is.EqualTo(this.database.Count));
        }

        [Test]
        [TestCase(1L, "1L", 1L, "1L")]
        [TestCase(1L, "1L", 10L, "1L")]
        [TestCase(1L, "1L", 1L, "10L")]
        public void CanNotAddPersonWithAlreadyExistingUsernameOrId(long firstId, string firstUsername, long secondId, string secondUsername)
        {
            // Arrange
            var firstPerson = new People(firstId, firstUsername);
            var secondPerson = new People(secondId, secondUsername);

            // Act
            this.database.Add(firstPerson);

            // Assert
            Assert.Throws<InvalidOperationException>(() => this.database.Add(secondPerson));
        }

        [Test]
        [TestCase(1L,"A",2L,"B",3L,"C",1L)]
        [TestCase(4L, "D", 5L, "E", 6L, "F", 5L)]
        public void FindItemByID(long firstId, string firstUsername, long secondId, string secondUsername, long thirdId, string thirdUsername, long keyId)
        {
            var firstPerson = new People(firstId, firstUsername);
            var secondPerson = new People(secondId, secondUsername);
            var thirdPerson = new People(thirdId, thirdUsername);

            this.database.Add(firstPerson);
            this.database.Add(secondPerson);
            this.database.Add(thirdPerson);

            var result = database.Find(keyId);

            Assert.That(keyId, Is.EqualTo(result.Id));


        }

        [Test]
        [TestCase(10L,"killer",20l,"idiot",30L,"sticky","killer")]
        public void FindItemByUsername(long firstId, string firstUsername, long secondId, string secondUsername, long thirdId, string thirdUsername, string usernameToFind)
        {
            var firstPerson = new People(firstId, firstUsername);
            var secondPerson = new People(secondId, secondUsername);
            var thirdPerson = new People(thirdId, thirdUsername);
            this.database.Add(firstPerson);
            this.database.Add(secondPerson);

            this.database.Add(thirdPerson);


            var foundPerson = this.database.Find(usernameToFind);

            Assert.That(usernameToFind, Is.EqualTo(foundPerson.Username));

        }

        [Test]
        public void UnableToFindNotExistingID()
        {
            var person = new People(1L, "Killer");

            this.database.Add(person);

            Assert.Throws<InvalidOperationException>(() => this.database.Find(40L));
        }

        [Test]
        public void UnableToFindNotExistingUsername()
        {
            var person = new People(20L, "tricky");
            this.database.Add(person);

            Assert.Throws<InvalidOperationException>(() => this.database.Find("Zetas"));
        }

        [Test]
        public void UnableToFindNullUsername()
        {
            var person = new People(20L, "tricky");
            this.database.Add(person);

            Assert.Throws<ArgumentNullException>(() => this.database.Find(null));
        }
    }
}
