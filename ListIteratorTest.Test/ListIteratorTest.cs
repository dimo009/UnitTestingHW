using System;
using System.Collections.Generic;
using System.Text;
using IteratorTest;
using NUnit.Framework;

namespace ListIteratorTest.Test
{
    [TestFixture]
    public class ListIteratorTest
    {
       
        private ListIterator listIterator;
        private string[] arguments;


        [SetUp]
        public void TestInit()
        {
            this.arguments = new string[] { "qwe", "asd", "zxc" };
            this.listIterator = new ListIterator(this.arguments);
        }

        [Test]
        public void CannotInitializeWithEmptyConstructor()

        {
            Assert.Throws<ArgumentNullException>(() => this.listIterator = new ListIterator(null));
        }



        [Test]
        public void MoveReturnsTrueWhenSuccessful()
        {
            
            Assert.AreEqual(true, this.listIterator.Move());
            Assert.AreEqual(true, this.listIterator.Move());
        }


        [Test]
        public void TestMoveMethodIfReturnsFalse()
        {
    
            listIterator.Move();
            listIterator.Move();
            listIterator.Move();

            Assert.AreEqual(false, this.listIterator.Move());
        }
        [Test]
        public void HasNextReturnsTrue()
        {
            listIterator.Move();

            Assert.That(true, Is.EqualTo(this.listIterator.HasNext()));
        }

        [Test]
        public void HasNextReturnsFalse()
        {
            listIterator.Move();
            listIterator.Move();
            listIterator.Move();
            listIterator.Move();

            Assert.That(false, Is.EqualTo(this.listIterator.HasNext()));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void TestThatPrintMethodReturnsTheProperResult(int currentElement)

        {
            for (int i = 0; i < currentElement; i++)
            {
                this.listIterator.Move();
            }

            Assert.AreEqual(this.arguments[currentElement], listIterator.Print());
        }

        [Test]
        public void CannotPrintWithEmptyIterator()
        {
            
            this.listIterator = new ListIterator(new string[0]);

            
            var ex = Assert.Throws<InvalidOperationException>(() => this.listIterator.Print());
            Assert.AreEqual("Invalid Operation!", ex.Message, "Attempting to print over empty iterator throws exception with an incorrect message");
        }
    }
}
