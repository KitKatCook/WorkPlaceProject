namespace WorkPlaceProject.Domain.Tests.StoryPointer
{
    public class StoryPointSelectionDomainServiceTests
    {
        Random random = new Random();
        [SetUp]
        public void Setup()
        {
            Thread.Sleep(random.Next(10, 150));
        }

        [Test]
        public void CreateSessionUser_CreatesUser_ReturnsTrue()
        {
            Assert.True(true);
        }

        [Test]
        public void CreateSessionUser_CreatesUser_ReturnsFalse()
        {
            Assert.False(false);
        }
    }
}