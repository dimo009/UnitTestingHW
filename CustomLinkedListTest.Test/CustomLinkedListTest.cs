using CustomLinkedList;
using NUnit.Framework;
using System;

namespace CustomLinkedListTest.Test
{
    [TestFixture]
    public class CustomLinkedListTest
    {
        private DynamicList<int> sut;

        [SetUp]
        public void TestInit()
        {
            this.sut = new DynamicList<int>();
        }

        [Test]
        public void CannotCallElementWithNegativeIndex()
        {
            // Arrange
            var incorrectIndex = -1;

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var test = this.sut[incorrectIndex];
            }
            , "Provided index is less than zero");
        }

        [Test]
        public void CannotCallElementWithIndexWhichIsBiggerThanTheRange()
        {
            //Arrange
            var incorrectIndex = this.sut.Count + 1;

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var test = this.sut[incorrectIndex];
            }
            , "Provided index is greater than the range of the collection");
        }

        [Test]
        public void AddShouldIncreaseCollectionCount()
        {
            //Arrange
            var collectionCount = this.sut.Count;
            this.sut.Add(1);

            //Assert
            Assert.That(collectionCount + 1, Is.EqualTo(this.sut.Count));
        }

        [Test]
        [TestCase(2,0)]
        [TestCase(5,1)]
        [TestCase(10,2)]
        public void SaveAddedElementsInTheList(int numberToBeAdded, int indexToVerify)
        {
            //Arrange
            this.sut.Add(numberToBeAdded);

            //Assert

            Assert.That(numberToBeAdded, Is.EqualTo(this.sut[indexToVerify]));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(1)]
        [TestCase(-5)]
        [TestCase(5)]
        public void RemoveAtIndexOusideTheBoundariesOfTheCollectionIsImpossible(int indexToRemove)
        {
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => this.sut.RemoveAt(indexToRemove));
        }

        [Test]
        [TestCase(3, 0)]
        [TestCase(10, 0)]
        [TestCase(10, 0)]
        [TestCase(12, 0)]
        public void RemoveAtShouldRemoveTheElementAtTheGivenIndex(int numberToBeAdded, int indexToVerify)
        {
            // Arrange
            this.sut.Add(numberToBeAdded);

            // Act
            this.sut.RemoveAt(indexToVerify);

            // Assert
            Assert.That(numberToBeAdded, Is.EqualTo(this.sut[indexToVerify]));
        }

        [Test]
        
        public void RemoveShouldDeleteParticularElement()
        {
            // Arrange
            this.sut.Add(1);
            this.sut.Add(2);
            this.sut.Add(3);
            this.sut.Add(4);


            // Act
            this.sut.Remove(3);

            // Assert
            Assert.AreEqual(2, this.sut.IndexOf(4), "Removed element is still in the collection");
        }

        [Test]
        public void ContainsReturnsTrueIfGivenElementIsInTheCollection()
        {
            //Arrange
            this.sut.Add(1);
            this.sut.Add(2);
            this.sut.Add(3);
            this.sut.Add(4);

            //Assert

            Assert.IsTrue(this.sut.Contains(3), "Contains method returns false for existing element");

        }

        [Test]
        public void ContainsReturnsFalseIfGivenElementIsInTheCollection()
        {
            //Arrange
            this.sut.Add(1);
            this.sut.Add(2);
            this.sut.Add(3);
            this.sut.Add(4);

            //Assert

            Assert.IsFalse(this.sut.Contains(100), "Contains method returns true for not existing element");

        }
    }
}
