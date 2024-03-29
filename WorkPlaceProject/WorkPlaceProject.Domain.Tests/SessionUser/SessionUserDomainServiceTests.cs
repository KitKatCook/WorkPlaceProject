﻿using Moq;
using WorkPlaceProject.Domain.SessionUser;

namespace WorkPlaceProject.Persistence.Tests.SessionUser
{
    public class SessionUserPersistenceServiceTests
    {
        private readonly Mock<ISessionUserRepository> _sessionUserRepository = new();
        private Domain.SessionUser.SessionUser _sessionUser;

        private SessionUserDomainService _sessionUserDomainService;

        [SetUp]
        public void Setup()
        {
            _sessionUserRepository.Reset();

            _sessionUserDomainService =
                new SessionUserDomainService(_sessionUserRepository.Object);

        }

        [Test]
        public void CreateSessionUser_CreatesSessionUser_ReturnsTrue()
        {
            // Arrange
            Guid userId = Guid.NewGuid();
            Guid azureId = Guid.NewGuid();
            Guid sessionId = Guid.NewGuid();
            bool isSessionLeader = true;

            SessionUserDdto sessionUserDdto = new SessionUserDdto()
            {
                Id = userId,
                AzureId = azureId,
                SessionId = sessionId,
                IsSessionLeader = isSessionLeader
            };

            _sessionUserRepository.Setup(x => x.CreateSessionUser(It.Is<Domain.SessionUser.SessionUser>(x =>
                    x.Id == userId
                    && x.AzureId == azureId
                    && x.SessionId == sessionId
                    && x.IsSessionLeader == isSessionLeader)))
                .Returns(true);

            // Act
            bool result = _sessionUserDomainService.CreateSessionUser(sessionUserDdto);

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

            SessionUserDdto sessionUserDdto = new SessionUserDdto()
            {
                Id = userId,
                AzureId = azureId,
                SessionId = sessionId,
                IsSessionLeader = isSessionLeader
            };

            _sessionUserRepository.Setup(x => x.CreateSessionUser(It.IsAny<Domain.SessionUser.SessionUser>()))
                .Returns(false);

            // Act
            bool result = _sessionUserDomainService.CreateSessionUser(sessionUserDdto);

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

            _sessionUserRepository.Setup(x => x.GetSessionUserById(userId)).Returns(_sessionUser);

            // Act
            Domain.SessionUser.SessionUser? result = _sessionUserDomainService.GetSessionUserById(userId);

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

            _sessionUser = new Domain.SessionUser.SessionUser(userId, azureId, sessionId, isSessionLeader);

            _sessionUserRepository.Setup(x => x.GetSessionUserById(userId)).Returns(_sessionUser);

            // Act
            Domain.SessionUser.SessionUser? result = _sessionUserDomainService.GetSessionUserById(invalidUserId);

            // Assert
            Assert.IsNull(result);
        }
    }
}