using NUnit.Framework;
using Moq;
using StackExchange.Redis;
using WorkPlaceProject.Common.Persistence;
using WorkPlaceProject.Domain.StoryPointerSession;
using System.Text.Json;

namespace WorkPlaceProject.Persistence.StoryPointerSession.Tests
{
    [TestFixture()]
    public class PointerSessionRepositoryTests
    {
        private Mock<IConnectionMultiplexer> _redisMock;
        private Mock<IDatabase> _databaseMock;
        private PointerSessionRepository _pointerSessionRepository;

        [SetUp]
        public void Setup()
        {
            _redisMock = new Mock<IConnectionMultiplexer>();
            _databaseMock = new Mock<IDatabase>();
            _redisMock.Setup(r => r.GetDatabase(It.IsAny<int>(), It.IsAny<object>())).Returns(_databaseMock.Object);

            _pointerSessionRepository = new PointerSessionRepository(_redisMock.Object);
        }

        [Test]
        public void CreatePointerSession_NewSession_ReturnsTrue()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Guid sessionLeaderId = Guid.NewGuid();
            string sessionCode = "sessionCode";

            PointerSession pointerSession = new PointerSession(id, sessionLeaderId, sessionCode);


            _databaseMock.Setup(d => d.SetAdd(RedisStrings.SetSession, It.IsAny<RedisValue>(), It.IsAny<CommandFlags>())).Returns(true);

            // Act
            bool result = _pointerSessionRepository.CreatePointerSession(pointerSession);

            // Assert
            Assert.IsTrue(result);
            _databaseMock.Verify(d => d.SetAdd(RedisStrings.SetSession, It.IsAny<RedisValue>(), It.IsAny<CommandFlags>()), Times.Once);
        }

        [Test]
        public void GetPointerSessionById_SessionExists_ReturnsPointerSession()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Guid sessionLeaderId = Guid.NewGuid();
            string sessionCode = "sessionCode";

            PointerSession pointerSession = new PointerSession(id, sessionLeaderId, sessionCode);

            var sessions = new List<RedisValue> { JsonSerializer.Serialize(pointerSession) };
            _databaseMock.Setup(d => d.SetMembers(RedisStrings.SetSession, It.IsAny<CommandFlags>())).Returns(sessions.ToArray());

            // Act
            var result = _pointerSessionRepository.GetPointerSessionById(id);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(pointerSession.Id, result?.Id);
            _databaseMock.Verify(d => d.SetMembers(RedisStrings.SetSession, It.IsAny<CommandFlags>()), Times.Once);
        }

        [Test]
        public void GetPointerSessionById_SessionDoesNotExist_ReturnsNull()
        {
            // Arrange
            var sessionId = Guid.NewGuid();

            _databaseMock.Setup(d => d.SetMembers(RedisStrings.SetSession, It.IsAny<CommandFlags>())).Returns(Array.Empty<RedisValue>());

            // Act
            var result = _pointerSessionRepository.GetPointerSessionById(sessionId);

            // Assert
            Assert.Null(result);
            _databaseMock.Verify(d => d.SetMembers(RedisStrings.SetSession, It.IsAny<CommandFlags>()), Times.Once);
        }

        [Test]
        public void GetPointerSessionByCode_SessionExists_ReturnsPointerSession()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Guid sessionLeaderId = Guid.NewGuid();
            string sessionCode = "sessionCode";

            PointerSession pointerSession = new PointerSession(id, sessionLeaderId, sessionCode);

            var sessions = new List<RedisValue> { JsonSerializer.Serialize(pointerSession) };
            _databaseMock.Setup(d => d.SetMembers(RedisStrings.SetSession, It.IsAny<CommandFlags>())).Returns(sessions.ToArray());

            // Act
            var result = _pointerSessionRepository.GetPointerSessionByCode(sessionCode);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(pointerSession.SessionCode, result?.SessionCode);
            _databaseMock.Verify(d => d.SetMembers(RedisStrings.SetSession, It.IsAny<CommandFlags>()), Times.Once);
        }

        [Test]
        public void GetPointerSessionByCode_SessionDoesNotExist_ReturnsNull()
        {
            // Arrange
            var sessionCode = "ABC123";

            _databaseMock.Setup(d => d.SetMembers(RedisStrings.SetSession, It.IsAny<CommandFlags>())).Returns(Array.Empty<RedisValue>());

            // Act
            var result = _pointerSessionRepository.GetPointerSessionByCode(sessionCode);

            // Assert
            Assert.Null(result);
            _databaseMock.Verify(d => d.SetMembers(RedisStrings.SetSession, It.IsAny<CommandFlags>()), Times.Once);
        }
    }
}