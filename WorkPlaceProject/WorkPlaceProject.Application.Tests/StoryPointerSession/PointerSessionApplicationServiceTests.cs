using Moq;
using WorkPlaceProject.Application.StoryPointerSession;
using WorkPlaceProject.Domain.StoryPointerSession;

namespace WorkPlaceProject.Application.Tests.StoryPointerSession
{
    public class PointerSessionApplicationServiceTests
    { 
        private readonly Mock<IPointerSessionDomainService> _pointerSessionDomainService = new();
        private PointerSession _pointerSession;

        private PointerSessionApplicationService _pointerSessionApplicationService;

        [SetUp]
        public void Setup()
        {
            _pointerSessionDomainService.Reset();

            _pointerSessionApplicationService =
                new PointerSessionApplicationService(_pointerSessionDomainService.Object);

        }

        [Test]
        public void CreatePointerSession_CreatesPointerSession_ReturnsTrue()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Guid sessionLeaderId = Guid.NewGuid();
            string sessionCode = "sessionCode";

            PointerSessionAdto pointerSessionAdto = new PointerSessionAdto()
            {
                Id = id,
                SessionLeaderId = sessionLeaderId,
                SessionCode = sessionCode
            };

            _pointerSessionDomainService.Setup(x => x.CreatePointerSession(It.Is<PointerSessionDdto>(x =>
                    x.Id == id
                    && x.SessionLeaderId == sessionLeaderId
                    && x.SessionCode == sessionCode
                    )))
                .Returns(true);

            // Act
            bool result = _pointerSessionApplicationService.CreatePointerSession(pointerSessionAdto);

            // Assert
            Assert.IsNotNull(result);
            Assert.True(result);
        }

        [Test]
        public void CreatePointerSession_CreatesPointerSession_ReturnsFalse()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Guid sessionLeaderId = Guid.NewGuid();
            string sessionCode = "sessionCode";

            PointerSessionAdto pointerSessionAdto = new PointerSessionAdto()
            {
                Id = id,
                SessionLeaderId = sessionLeaderId,
                SessionCode = sessionCode
            };

            _pointerSessionDomainService.Setup(x => x.CreatePointerSession(It.Is<PointerSessionDdto>(x =>
                    x.Id == id
                    && x.SessionLeaderId == sessionLeaderId
                    && x.SessionCode == sessionCode
                    )))
                .Returns(false);

            // Act
            bool result = _pointerSessionApplicationService.CreatePointerSession(pointerSessionAdto);

            // Assert
            Assert.IsNotNull(result);
            Assert.False(result);
        }

        [Test]
        public void GetPointerSessionById_GetsPointerSession_ReturnsPointerSession()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Guid sessionLeaderId = Guid.NewGuid();
            string sessionCode = "sessionCode";

            _pointerSession = new PointerSession(id, sessionLeaderId, sessionCode);

            _pointerSessionDomainService.Setup(x => x.GetPointerSessionById(id)).Returns(_pointerSession);

            // Act
            PointerSession? result = _pointerSessionApplicationService.GetPointerSessionById(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(id));
            Assert.That(result.SessionLeaderId, Is.EqualTo(sessionLeaderId));
            Assert.That(result.SessionCode, Is.EqualTo(sessionCode));
        }

        [Test]
        public void GetPointerSessionById_NoPointerSession_ReturnsNull()
        {
            // Arrange
            Guid invalidId = Guid.NewGuid();

            Guid id = Guid.NewGuid();
            Guid sessionLeaderId = Guid.NewGuid();
            string sessionCode = "sessionCode";

            _pointerSession = new PointerSession(id, sessionLeaderId, sessionCode);

            _pointerSessionDomainService.Setup(x => x.GetPointerSessionById(id)).Returns(_pointerSession);

            // Act
            PointerSession? result = _pointerSessionApplicationService.GetPointerSessionById(invalidId);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetPointerSessionByCode_GetsPointerSession_ReturnsPointerSession()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Guid sessionLeaderId = Guid.NewGuid();
            string sessionCode = "sessionCode";

            _pointerSession = new PointerSession(id, sessionLeaderId, sessionCode);

            _pointerSessionDomainService.Setup(x => x.GetPointerSessionByCode(sessionCode)).Returns(_pointerSession);

            // Act
            PointerSession? result = _pointerSessionApplicationService.GetPointerSessionByCode(sessionCode);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(id));
            Assert.That(result.SessionLeaderId, Is.EqualTo(sessionLeaderId));
            Assert.That(result.SessionCode, Is.EqualTo(sessionCode));
        }

        [Test]
        public void GetPointerSessionByCode_NoPointerSession_ReturnsNull()
        {
            // Arrange
            // Arrange
            Guid invalidId = Guid.NewGuid();

            Guid id = Guid.NewGuid();
            Guid sessionLeaderId = Guid.NewGuid();
            string sessionCode = "sessionCode";

            _pointerSession = new PointerSession(id, sessionLeaderId, sessionCode);

            _pointerSessionDomainService.Setup(x => x.GetPointerSessionByCode(sessionCode)).Returns(_pointerSession);

            // Act
            PointerSession? result = _pointerSessionApplicationService.GetPointerSessionByCode("invalidString");

            // Assert
            Assert.IsNull(result);
        }
    }
}
