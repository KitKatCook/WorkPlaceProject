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
            var url = "https://example.com/iteration";

            // Act
            var iteration = new Iteration
            {
                Id = id,
                Name = name,
                Path = path,
                Url = url
            };

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(iteration.Id, Is.EqualTo(id));
                Assert.That(iteration.Name, Is.EqualTo(name));
                Assert.That(iteration.Path, Is.EqualTo(path));
                Assert.That(iteration.Url, Is.EqualTo(url));
            });
        }
    }
}
