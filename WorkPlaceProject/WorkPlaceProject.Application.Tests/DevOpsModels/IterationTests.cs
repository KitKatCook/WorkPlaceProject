using NUnit.Framework;
using WorkPlaceProject.Application.DevOpsModels;


namespace WorkPlaceProject.Application.Tests.DevOpsModels
{

    [TestFixture]
    public class IterationTests
    {
        [Test]
        public void Iteration_PropertiesAreCorrectlySet()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "IterationName";
            var path = "Project/Iteration";
            //var attribute = new Attribute { Key = "Key", Value = "Value" };
            var url = "https://example.com/iteration";

            // Act
            var iteration = new Iteration
            {
                Id = id,
                Name = name,
                Path = path,
                //Attribute = attribute,
                Url = url
            };

            // Assert
            Assert.That(iteration.Id, Is.EqualTo(id));
            Assert.That(iteration.Name, Is.EqualTo(name));
            Assert.That(iteration.Path, Is.EqualTo(path));
            //Assert.That(iteration.Attribute, Is.EqualTo(attribute));
            Assert.That(iteration.Url, Is.EqualTo(url));
        }
    }
}
