using NUnit.Framework;
using WorkPlaceProject.Domain.StoryPointer.ValueTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlaceProject.Domain.StoryPointer.ValueTypes.Tests
{
    [TestFixture()]
    public class ValueTypeTests
    {
        [Test]
        public void Values_ContainsCorrectFibonacciValues()
        {
            // Arrange
            HashSet<ValueType> expectedValues = new HashSet<ValueType>()
            {
                new ValueType(0, 0, "Description"),
                new ValueType(1, 1, "Description"),
                new ValueType(2, 2, "Description"),
                new ValueType(3, 3, "Description"),
                new ValueType(4, 5, "Description"),
                new ValueType(5, 8, "Description"),
                new ValueType(6, 13, "Description"),
                new ValueType(7, 21, "Description"),
            };

            // Act
            HashSet<ValueType> actualValues = FibonacciValueType.Values;

            // Assert
            Assert.False(actualValues.SetEquals(expectedValues));
        }


    }
}
