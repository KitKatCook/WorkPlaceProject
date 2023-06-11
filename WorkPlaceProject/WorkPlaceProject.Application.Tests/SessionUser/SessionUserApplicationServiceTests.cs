using Moq;
using WorkPlaceProject.Application.SessionUser;
using WorkPlaceProject.Domain.SessionUser;

namespace WorkPlaceProject.Application.Tests.SessionUser
{
    public class SessionUserApplicationServiceTests
    {
        private readonly Mock<ISessionUserDomainService> _sessionUserDomainService = new();
        private Domain.SessionUser.SessionUser _sessionUser;

        private SessionUserApplicationService _sessionUserApplicationService;

        [SetUp]
        public void Setup()
        {
            _sessionUserDomainService.Reset();

            _sessionUserApplicationService =
                new SessionUserApplicationService(_sessionUserDomainService.Object);

        }

        [Test]
        public void CreateSessionUser_CreatesSessionUser_ReturnsTrue()
        {
            // Arrange
            Guid userId = Guid.NewGuid();
            Guid azureId = Guid.NewGuid();
            Guid sessionId = Guid.NewGuid();
            bool isSessionLeader = true;

            SessionUserAdto sessionUserAdto = new SessionUserAdto()
            {
                Id = userId,
                AzureId = azureId,
                SessionId = sessionId,
                IsSessionLeader = isSessionLeader
            };

            _sessionUserDomainService.Setup(x => x.CreateSessionUser(It.Is<SessionUserDdto>(x =>
                    x.Id == userId
                    && x.AzureId == azureId
                    && x.SessionId == sessionId
                    && x.IsSessionLeader == isSessionLeader)))
                .Returns(true);

            // Act
            bool result = _sessionUserApplicationService.CreateSessionUser(sessionUserAdto);

            // Assert
            Assert.IsNotNull(result);
            Assert.True(result);
        }

        [Test]
        public void CreateSessionUser_CreatesSessionUser_ReturnsFalse()
        {
            // Arrange
            Guid userId = Guid.NewGuid();
            Guid azureId = Guid.NewGuid();
            Guid sessionId = Guid.NewGuid();
            bool isSessionLeader = true;

            SessionUserAdto sessionUserAdto = new SessionUserAdto()
            {
                Id = userId,
                AzureId = azureId,
                SessionId = sessionId,
                IsSessionLeader = isSessionLeader
            };

            _sessionUserDomainService.Setup(x => x.CreateSessionUser(It.IsAny<SessionUserDdto>()))
                .Returns(false);

            // Act
            bool result = _sessionUserApplicationService.CreateSessionUser(sessionUserAdto);

            // Assert
            Assert.IsNotNull(result);
            Assert.False(result);
        }

        [Test]
        public void GetSessionUserById_GetsSessionUser_ReturnsSessionUser()
        {
            // Arrange
            Guid userId = Guid.NewGuid();
            Guid azureId = Guid.NewGuid();
            Guid sessionId = Guid.NewGuid();
            bool isSessionLeader = true;

            _sessionUser = new Domain.SessionUser.SessionUser(userId, azureId, sessionId, isSessionLeader);

            _sessionUserDomainService.Setup(x => x.GetSessionUserById(userId)).Returns(_sessionUser);

            // Act
            Domain.SessionUser.SessionUser? result = _sessionUserApplicationService.GetSessionUserById(userId);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(userId));
            Assert.That(result.AzureId, Is.EqualTo(azureId));
            Assert.That(result.SessionId, Is.EqualTo(sessionId));
            Assert.That(result.IsSessionLeader, Is.EqualTo(isSessionLeader));
        }

        [Test]
        public void GetSessionUserById_NoSessionUser_ReturnsNull()
        {
            // Arrange
            Guid invalidUserId = Guid.NewGuid();

            Guid userId = Guid.NewGuid();
            Guid azureId = Guid.NewGuid();
            Guid sessionId = Guid.NewGuid();
            bool isSessionLeader = true;

            _sessionUser = new Domain.SessionUser.SessionUser(userId, azureId,  sessionId, isSessionLeader);

            // Act
            Domain.SessionUser.SessionUser? result = _sessionUserApplicationService.GetSessionUserById(invalidUserId);

            // Assert
            Assert.IsNull(result);
        }
    }
}