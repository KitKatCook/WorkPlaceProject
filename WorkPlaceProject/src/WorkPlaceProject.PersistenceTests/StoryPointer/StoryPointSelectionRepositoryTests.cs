using NUnit.Framework;
using Moq;
using StackExchange.Redis;
using WorkPlaceProject.Common.Persistence;
using System.Text.Json;
using WorkPlaceProject.Domain.StoryPointer;

namespace WorkPlaceProject.Persistence.StoryPointer.Tests
{
    [TestFixture()]
    public class StoryPointSelectionRepositoryTests
    {
        private Mock<IConnectionMultiplexer> _redisMock;
        private Mock<IDatabase> _databaseMock;
        private StoryPointSelectionRepository _storyPointSelectionRepository;

        [SetUp]
        public void Setup()
        {
            _redisMock = new Mock<IConnectionMultiplexer>();
            _databaseMock = new Mock<IDatabase>();
            _redisMock.Setup(r => r.GetDatabase(It.IsAny<int>(), It.IsAny<object>())).Returns(_databaseMock.Object);

            _storyPointSelectionRepository = new StoryPointSelectionRepository(_redisMock.Object);
        }

        [Test]
        public void CreateStoryPointSelection_NewSelection_ReturnsTrue()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Guid sessionId = Guid.NewGuid();
            Guid userId = Guid.NewGuid();
            string username = "username";
            string selectionValue = "1";

            var storyPointSelection = new StoryPointSelection(id, sessionId, userId, username, selectionValue);

            _databaseMock.Setup(d => d.SetMembers(RedisStrings.StoryPointSelection, It.IsAny<CommandFlags>())).Returns(Array.Empty<RedisValue>());

            _databaseMock.Setup(d => d.SetAdd(RedisStrings.StoryPointSelection, It.IsAny<RedisValue>(), It.IsAny<CommandFlags>())).Returns(true);

            // Act
            bool result = _storyPointSelectionRepository.CreateStoryPointSelection(storyPointSelection);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CreateStoryPointSelection_ExistingSelection_ReturnsTrue()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Guid sessionId = Guid.NewGuid();
            Guid userId = Guid.NewGuid();
            string username = "username";
            string selectionValue = "1";

            var storyPointSelection = new StoryPointSelection(id, sessionId, Guid.NewGuid(), username, selectionValue);

            var existingSelection = new StoryPointSelection(id, sessionId, userId, username, selectionValue);

            RedisValue[] existingSelections = new RedisValue[] { JsonSerializer.Serialize(existingSelection) };

            _databaseMock.Setup(d => d.SetMembers(RedisStrings.StoryPointSelection, It.IsAny<CommandFlags>())).Returns(existingSelections);

            _databaseMock.Setup(d => d.SetAdd(RedisStrings.StoryPointSelection, It.IsAny<RedisValue>(), It.IsAny<CommandFlags>())).Returns(true);
            _databaseMock.Setup(d => d.SetRemove(RedisStrings.StoryPointSelection, It.IsAny<RedisValue>(), It.IsAny<CommandFlags>())).Returns(true);

            // Act
            bool result = _storyPointSelectionRepository.CreateStoryPointSelection(storyPointSelection);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void GetStoryPointSelectionById_SelectionExists_ReturnsStoryPointSelection()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Guid sessionId = Guid.NewGuid();
            Guid userId = Guid.NewGuid();
            string username = "username";
            string selectionValue = "1";

            var storyPointSelection = new StoryPointSelection(id, sessionId, userId, username, selectionValue);


            var storyPointSelections = new List<RedisValue> { JsonSerializer.Serialize(storyPointSelection) };
            _databaseMock.Setup(d => d.SetMembers(RedisStrings.StoryPointSelection, It.IsAny<CommandFlags>())).Returns(storyPointSelections.ToArray());

            // Act
            var result = _storyPointSelectionRepository.GetStoryPointSelectionById(id);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(storyPointSelection.Id, result?.Id);
        }

        [Test]
        public void GetStoryPointSelectionById_SelectionDoesNotExist_ReturnsNull()
        {
            // Arrange
            var selectionId = Guid.NewGuid();

            _databaseMock.Setup(d => d.SetMembers(RedisStrings.StoryPointSelection, It.IsAny<CommandFlags>())).Returns(Array.Empty<RedisValue>());

            // Act
            var result = _storyPointSelectionRepository.GetStoryPointSelectionById(selectionId);

            // Assert
            Assert.Null(result);
            _databaseMock.Verify(d => d.SetMembers(RedisStrings.StoryPointSelection, It.IsAny<CommandFlags>()), Times.Once);
        }

        [Test]
        public void GetStoryPointSelectionByUserId_SelectionExists_ReturnsStoryPointSelection()
        {
            // Arrange

            Guid id = Guid.NewGuid();
            Guid sessionId = Guid.NewGuid();
            Guid userId = Guid.NewGuid();
            string username = "username";
            string selectionValue = "1";

            var storyPointSelection = new StoryPointSelection(id, sessionId, userId, username, selectionValue);

            var storyPointSelections = new List<RedisValue> { JsonSerializer.Serialize(storyPointSelection) };
            _databaseMock.Setup(d => d.SetMembers(RedisStrings.StoryPointSelection, It.IsAny<CommandFlags>())).Returns(storyPointSelections.ToArray());

            // Act
            var result = _storyPointSelectionRepository.GetStoryPointSelectionByUserId(userId);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(storyPointSelection.UserId, result?.UserId);
            _databaseMock.Verify(d => d.SetMembers(RedisStrings.StoryPointSelection, It.IsAny<CommandFlags>()), Times.Once);
        }

        [Test]
        public void GetStoryPointSelectionByUserId_SelectionDoesNotExist_ReturnsNull()
        {
            // Arrange
            var userId = Guid.NewGuid();

            _databaseMock.Setup(d => d.SetMembers(RedisStrings.StoryPointSelection, It.IsAny<CommandFlags>())).Returns(Array.Empty<RedisValue>());

            // Act
            var result = _storyPointSelectionRepository.GetStoryPointSelectionByUserId(userId);

            // Assert
            Assert.Null(result);
            _databaseMock.Verify(d => d.SetMembers(RedisStrings.StoryPointSelection, It.IsAny<CommandFlags>()), Times.Once);
        }

        [Test]
        public void GetStoryPointSelectionBySessionId_SelectionExists_ReturnsStoryPointSelections()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Guid sessionId = Guid.NewGuid();
            Guid userId = Guid.NewGuid();
            string username = "username";
            string selectionValue = "1";

            var storyPointSelection1 = new StoryPointSelection(id, sessionId, userId, username, selectionValue);
            var storyPointSelection2 = new StoryPointSelection(id, sessionId, userId, username, selectionValue);

            var storyPointSelections = new List<RedisValue> { JsonSerializer.Serialize(storyPointSelection1), JsonSerializer.Serialize(storyPointSelection2) };
            _databaseMock.Setup(d => d.SetMembers(RedisStrings.StoryPointSelection, It.IsAny<CommandFlags>())).Returns(storyPointSelections.ToArray());

            // Act
            var result = _storyPointSelectionRepository.GetStoryPointSelectionBySessionId(sessionId);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(2, result?.Count());
            _databaseMock.Verify(d => d.SetMembers(RedisStrings.StoryPointSelection, It.IsAny<CommandFlags>()), Times.Once);
        }

        [Test]
        public void GetStoryPointSelectionBySessionId_SelectionDoesNotExist_ReturnsNull()
        {
            // Arrange
            var sessionId = Guid.NewGuid();

            _databaseMock.Setup(d => d.SetMembers(RedisStrings.StoryPointSelection, It.IsAny<CommandFlags>())).Returns(Array.Empty<RedisValue>());

            // Act
            var result = _storyPointSelectionRepository.GetStoryPointSelectionBySessionId(sessionId);

            // Assert
            Assert.Null(result);
            _databaseMock.Verify(d => d.SetMembers(RedisStrings.StoryPointSelection, It.IsAny<CommandFlags>()), Times.Once);
        }

        [Test]
        public void DeleteStoryPointSelectionByUserId_SelectionExists_ReturnsTrue()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Guid sessionId = Guid.NewGuid();
            Guid userId = Guid.NewGuid();
            string username = "username";
            string selectionValue = "1";

            var storyPointSelection = new StoryPointSelection(id, sessionId, userId, username, selectionValue);

            var storyPointSelections = new List<RedisValue> { JsonSerializer.Serialize(storyPointSelection) };
            _databaseMock.Setup(d => d.SetMembers(RedisStrings.StoryPointSelection, It.IsAny<CommandFlags>())).Returns(storyPointSelections.ToArray());
            _databaseMock.Setup(d => d.SetRemove(RedisStrings.StoryPointSelection, It.IsAny<RedisValue>(), It.IsAny<CommandFlags>())).Returns(true);

            // Act
            bool result = _storyPointSelectionRepository.DeleteStoryPointSelectionByUserId(userId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void DeleteStoryPointSelectionByUserId_SelectionDoesNotExist_ReturnsFalse()
        {
            // Arrange
            var userId = Guid.NewGuid();

            _databaseMock.Setup(d => d.SetMembers(RedisStrings.StoryPointSelection, It.IsAny<CommandFlags>())).Returns(Array.Empty<RedisValue>());
            _databaseMock.Setup(d => d.SetRemove(RedisStrings.StoryPointSelection, It.IsAny<RedisValue>(), It.IsAny<CommandFlags>())).Returns(true);

            // Act
            bool result = _storyPointSelectionRepository.DeleteStoryPointSelectionByUserId(userId);

            // Assert
            Assert.IsFalse(result);
            _databaseMock.Verify(d => d.SetMembers(RedisStrings.StoryPointSelection, It.IsAny<CommandFlags>()), Times.Once);
            _databaseMock.Verify(d => d.SetRemove(RedisStrings.StoryPointSelection, It.IsAny<RedisValue[]>(), It.IsAny<CommandFlags>()), Times.Never);
        }
    }
}