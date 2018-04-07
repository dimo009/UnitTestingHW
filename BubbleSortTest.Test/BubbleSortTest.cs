using BubbleSort;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BubbleSortTest.Test
{
    [TestFixture]
    public class BubbleSortTest
    {
        [Test]
        [TestCase(9, 2, 3, 4, 5, 6, 7, 8, 1)]
        
        public void IsBubbleSortingProperly(params int[] numbersToSort)
        {
            
            var bubble = new Bubble();
            var sortedNumbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            
            bubble.Sort(numbersToSort);

            
            CollectionAssert.AreEqual(sortedNumbers, numbersToSort);

            
        }
    }
}
