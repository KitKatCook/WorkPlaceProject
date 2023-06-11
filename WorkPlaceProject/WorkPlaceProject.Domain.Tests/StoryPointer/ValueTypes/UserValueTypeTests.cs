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
    public class UserValueTypeTests
    {
        [Test]
        public void Constructor_InitializesPropertiesWithCorrectValues()
        {
            // Arrange
            int expectedIndex = 1;
            int expectedValue = 10;
            string expectedDescription = "Test Description";
            string expectedUsername = "TestUser";

            // Act
            UserValueType userValueType = new UserValueType(expectedIndex, expectedValue, expectedDescription, expectedUsername);

            // Assert
            Assert.AreEqual(expectedIndex, userValueType.Index);
            Assert.AreEqual(expectedValue, userValueType.Value);
            Assert.AreEqual(expectedDescription, userValueType.Description);
            Assert.AreEqual(expectedUsername, userValueType.Username);
        }

        [Test]
        public void Properties_CanBeModified()
        {
            // Arrange
            UserValueType userValueType = new UserValueType(1, 10, "Description", "User");

            int expectedIndex = 2;
            int expectedValue = 20;
            string expectedDescription = "New Description";
            string expectedUsername = "NewUser";

            // Act
            userValueType.Index = expectedIndex;
            userValueType.Value = expectedValue;
            userValueType.Description = expectedDescription;
            userValueType.Username = expectedUsername;

            // Assert
            Assert.AreEqual(expectedIndex, userValueType.Index);
            Assert.AreEqual(expectedValue, userValueType.Value);
            Assert.AreEqual(expectedDescription, userValueType.Description);
            Assert.AreEqual(expectedUsername, userValueType.Username);
        }
    }
}