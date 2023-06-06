using WorkPlaceProject.Common.Persistence;

namespace WorkPlaceProject.Common.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void StoryPointSelectionIsEqualToStoryPointSelection()
        {
            Assert.That(RedisStrings.StoryPointSelection, Is.EqualTo("StoryPointSelection"));
        }

        [Test]
        public void SetSessionIsEqualToSetSession()
        {
            Assert.That(RedisStrings.SetSession, Is.EqualTo("Session"));
        }

        [Test]
        public void SetMessageIsEqualToSetMessage()
        {
            Assert.That(RedisStrings.SetMessage, Is.EqualTo("Message"));
        }

        [Test]
        public void SetUserIsEqualToSetUser()
        {
            Assert.That(RedisStrings.SetUser, Is.EqualTo("User"));
        }

        [Test]
        public void SelectedWorkItemIsEqualToSelectedWorkItem()
        {
            Assert.That(RedisStrings.SelectedWorkItem, Is.EqualTo("SelectedWorkItem"));
        }
    }
}