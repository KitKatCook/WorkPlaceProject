using Moq;
using NUnit.Framework;
using StackExchange.Redis;
using System.Text.Json;
using WorkPlaceProject.Common.Persistence;
using WorkPlaceProject.Domain.SelectedWorkItem;

namespace WorkPlaceProject.Persistence.SessionUser.Tests
{
    [TestFixture()]
    public class SelectedWorkItemRepositoryTests
    {
        private Mock<IConnectionMultiplexer> _redisMock;
        private Mock<IDatabase> _databaseMock;
        private SelectedWorkItemRepository _repository;

        [SetUp]
        public void Setup()
        {
            _redisMock = new Mock<IConnectionMultiplexer>();
            _databaseMock = new Mock<IDatabase>();
            _redisMock.Setup(r => r.GetDatabase(It.IsAny<int>(), It.IsAny<object>())).Returns(_databaseMock.Object);

            _repository = new SelectedWorkItemRepository(_redisMock.Object);
        }

        [Test]
        public void CreateSelectedWorkItem_ShouldDeleteExistingSelectionAndAddNewItem()
        {
            // Arrange
            int id = 1;
            Guid iterationId = Guid.NewGuid();
            Guid teamId = Guid.NewGuid();
            Guid sessionId = Guid.NewGuid();
            string description = "description";
            string acceptanceCriteria = "acceptanceCriteria";
            int? storyPoints = 1;

            SelectedWorkItem selectedWorkItem = new SelectedWorkItem(id, iterationId, teamId, sessionId, description, acceptanceCriteria, storyPoints);

            _databaseMock.Setup(d => d.SetRemove(It.IsAny<RedisKey>(), It.IsAny<RedisValue>(), It.IsAny<CommandFlags>())).Returns(true);
            _databaseMock.Setup(d => d.SetAdd(It.IsAny<RedisKey>(), It.IsAny<RedisValue>(), It.IsAny<CommandFlags>())).Returns(true);

            // Act
            bool result = _repository.CreateSelectedWorkItem(selectedWorkItem);

            // Assert
            _databaseMock.Verify(d => d.SetAdd(RedisStrings.SelectedWorkItem, It.IsAny<RedisValue>(), It.IsAny<CommandFlags>()), Times.Once());
            Assert.IsTrue(result);
        }

        [Test]
        public void GetSelectedWorkItemBySessionId_ShouldReturnSelectedWorkItem_WhenExists()
        {
            // Arrange
            int id = 1;
            Guid iterationId = Guid.NewGuid();
            Guid teamId = Guid.NewGuid();
            Guid sessionId = Guid.NewGuid();
            string description = "description";
            string acceptanceCriteria = "acceptanceCriteria";
            int? storyPoints = 1;

            SelectedWorkItem selectedWorkItem = new SelectedWorkItem(id, iterationId, teamId, sessionId, description, acceptanceCriteria, storyPoints);

            RedisValue[] sessions = new RedisValue[]
            {
                JsonSerializer.Serialize(selectedWorkItem)
            };

            _databaseMock.Setup(d => d.SetMembers(RedisStrings.SelectedWorkItem, It.IsAny<CommandFlags>())).Returns(sessions);

            // Act
            SelectedWorkItem? result = _repository.GetSelectedWorkItemBySessionId(sessionId);

            // Assert
            _databaseMock.Verify(d => d.SetMembers(RedisStrings.SelectedWorkItem, It.IsAny<CommandFlags>()), Times.Once());
            Assert.IsNotNull(result);
            Assert.AreEqual(sessionId, result.SessionId);
        }

        [Test]
        public void GetSelectedWorkItemBySessionId_ShouldReturnNull_WhenNotExists()
        {
            // Arrange
            Guid sessionId = Guid.NewGuid();
            RedisValue[] sessions = Enumerable.Empty<RedisValue>().ToArray();

            _databaseMock.Setup(d => d.SetMembers(RedisStrings.SelectedWorkItem, It.IsAny<CommandFlags>())).Returns(sessions);

            // Act
            SelectedWorkItem? result = _repository.GetSelectedWorkItemBySessionId(sessionId);

            // Assert
            _databaseMock.Verify(d => d.SetMembers(RedisStrings.SelectedWorkItem, It.IsAny<CommandFlags>()), Times.Once());
            Assert.IsNull(result);
        }

        [Test]
        public void DeleteStoryPointSelectionByUserId_ShouldRemoveExistingSelectionAndReturnTrue()
        {
            // Arrange
            int id = 1;
            Guid iterationId = Guid.NewGuid();
            Guid teamId = Guid.NewGuid();
            Guid sessionId = Guid.Parse("bb1067fe-ee76-463f-8ade-a0278dd0039f");
            string description = "description";
            string acceptanceCriteria = "acceptanceCriteria";
            int? storyPoints = 1;

            SelectedWorkItem selectedWorkItem = new SelectedWorkItem(id ,iterationId, teamId, sessionId, description, acceptanceCriteria, storyPoints);

            _databaseMock.Setup(d => d.SetMembers(It.IsAny<RedisKey>(), It.IsAny<CommandFlags>())).Returns(new RedisValue[] {"{\"Id\": 8,\"IterationId\": \"074c3b35-7a74-4d0f-97fb-126420d3ae15\",\"TeamId\": \"0d319426-d53b-4361-b151-8984229fe503\",\"SessionId\": \"bb1067fe-ee76-463f-8ade-a0278dd0039f\",\"Description\": \"\",\"AcceptanceCriteria\": \"\",\"StoryPoints\": null}"});
            _databaseMock.Setup(d => d.SetRemove(It.IsAny<RedisKey>(), It.IsAny<RedisValue>(), It.IsAny<CommandFlags>())).Returns(true);
            _repository = new SelectedWorkItemRepository(_redisMock.Object);

            // Act
            bool result = _repository.DeleteStoryPointSelectionByUserId(sessionId);

            // Assert
            _databaseMock.Verify(d => d.SetRemove(RedisStrings.SelectedWorkItem, It.IsAny<RedisValue>(), It.IsAny<CommandFlags>()), Times.Once());
            Assert.IsTrue(result);
        }

        [Test]
        public void DeleteStoryPointSelectionByUserId_ShouldReturnFalse_WhenSelectionNotExists()
        {
            // Arrange
            Guid sessionId = Guid.NewGuid();

            _databaseMock.Setup(d => d.SetMembers(It.IsAny<RedisKey>(), It.IsAny<CommandFlags>())).Returns(new RedisValue[] { "{\"Id\": 8,\"IterationId\": \"074c3b35-7a74-4d0f-97fb-126420d3ae15\",\"TeamId\": \"0d319426-d53b-4361-b151-8984229fe503\",\"SessionId\": \"bb1067fe-ee76-463f-8ade-a0278dd0039f\",\"Description\": \"\",\"AcceptanceCriteria\": \"\",\"StoryPoints\": null}" });
            _databaseMock.Setup(d => d.SetRemove(It.IsAny<RedisKey>(), It.IsAny<RedisValue>(), It.IsAny<CommandFlags>())).Returns(false);
            _repository = new SelectedWorkItemRepository(_redisMock.Object);

            // Act
            bool result = _repository.DeleteStoryPointSelectionByUserId(sessionId);

            // Assert
            _databaseMock.Verify(d => d.SetRemove(RedisStrings.SelectedWorkItem, It.IsAny<RedisValue>(), It.IsAny<CommandFlags>()), Times.Never);
            Assert.IsFalse(result);
        }
    }
}