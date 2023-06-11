using NUnit.Framework;
using Moq;
using StackExchange.Redis;
using WorkPlaceProject.Common.Persistence;
using System.Text.Json;

namespace WorkPlaceProject.Persistence.SessionUser.Tests
{
    [TestFixture()]
    public class SessionUserRepositoryTests
    {
        private Mock<IConnectionMultiplexer> _redisMock;
        private Mock<IDatabase> _databaseMock;
        private SessionUserRepository _sessionUserRepository;

        [SetUp]
        public void Setup()
        {
            _redisMock = new Mock<IConnectionMultiplexer>();
            _databaseMock = new Mock<IDatabase>();
            _redisMock.Setup(r => r.GetDatabase(It.IsAny<int>(), It.IsAny<object>())).Returns(_databaseMock.Object);

            _sessionUserRepository = new SessionUserRepository(_redisMock.Object);
        }

        [Test]
        public void CreateSessionUser_ShouldReturnTrue_WhenSessionUserIsCreated()
        {
            // Arrange
            Guid userId = Guid.NewGuid();
            Guid azureId = Guid.NewGuid();
            Guid sessionId = Guid.NewGuid();
            bool isSessionLeader = true;

            Domain.SessionUser.SessionUser sessionUser = new Domain.SessionUser.SessionUser(userId, azureId, sessionId, isSessionLeader);

            _databaseMock.Setup(d => d.SetAdd(RedisStrings.SetUser, It.IsAny<RedisValue>(), It.IsAny<CommandFlags>())).Returns(true);

            // Act
            var result = _sessionUserRepository.CreateSessionUser(sessionUser);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void GetSessionUserById_ShouldReturnSessionUser_WhenUserExists()
        {
            // Arrange
            Guid userId = Guid.NewGuid();
            Guid azureId = Guid.NewGuid();
            Guid sessionId = Guid.NewGuid();
            bool isSessionLeader = true;

            Domain.SessionUser.SessionUser sessionUser = new Domain.SessionUser.SessionUser(userId, azureId, sessionId, isSessionLeader);

            _databaseMock.Setup(d => d.SetMembers(RedisStrings.SetUser, It.IsAny<CommandFlags>())).Returns(new RedisValue[] { JsonSerializer.Serialize(sessionUser) });

            // Act
            var result = _sessionUserRepository.GetSessionUserById(azureId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(userId, result.Id);
            Assert.AreEqual(azureId, result.AzureId);
            Assert.AreEqual(sessionId, result.SessionId);
            Assert.AreEqual(isSessionLeader, result.IsSessionLeader);
        }

        [Test]
        public void GetSessionUserById_ShouldReturnNull_WhenUserDoesNotExist()
        {
            // Arrange
            var userId = Guid.NewGuid();

            _databaseMock.Setup(d => d.SetMembers(RedisStrings.SetUser, It.IsAny<CommandFlags>())).Returns(new RedisValue[] { });

            // Act
            var result = _sessionUserRepository.GetSessionUserById(userId);

            // Assert
            Assert.IsNull(result);
        }
    }
}