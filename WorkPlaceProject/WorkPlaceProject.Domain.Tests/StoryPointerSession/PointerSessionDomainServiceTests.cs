using Moq;
using WorkPlaceProject.Domain.StoryPointerSession;

namespace WorkPlaceProject.Domain.Tests.StoryPointerSession
{
    public class PointerSessionRepositoryTests
    {
        private readonly Mock<IPointerSessionRepository> _pointerSessionRepository = new();
        private PointerSession _pointerSession;

        private PointerSessionDomainService _pointerSessionDomainService;

        [SetUp]
        public void Setup()
        {
            _pointerSessionRepository.Reset();

            _pointerSessionDomainService =
                new PointerSessionDomainService(_pointerSessionRepository.Object);

        }

        [Test]
        public void CreatePointerSession_CreatesPointerSession_ReturnsTrue()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Guid sessionLeaderId = Guid.NewGuid();
            string sessionCode = "sessionCode";

            PointerSessionDdto pointerSessionDdto = new PointerSessionDdto()
            {
                Id = id,
                SessionLeaderId = sessionLeaderId,
                SessionCode = sessionCode
            };

            _pointerSessionRepository.Setup(x => x.CreatePointerSession(It.Is<PointerSession>(x =>
                    x.Id == id
                    && x.SessionLeaderId == sessionLeaderId
                    && x.SessionCode == sessionCode
                    )))
                .Returns(true);

            // Act
            bool result = _pointerSessionDomainService.CreatePointerSession(pointerSessionDdto);

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

            PointerSessionDdto pointerSessionDdto = new PointerSessionDdto()
            {
                Id = id,
                SessionLeaderId = sessionLeaderId,
                SessionCode = sessionCode
            };

            _pointerSessionRepository.Setup(x => x.CreatePointerSession(It.Is<PointerSession>(x =>
                    x.Id == id
                    && x.SessionLeaderId == sessionLeaderId
                    && x.SessionCode == sessionCode
                    )))
                .Returns(false);

            // Act
            bool result = _pointerSessionDomainService.CreatePointerSession(pointerSessionDdto);

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

            _pointerSessionRepository.Setup(x => x.GetPointerSessionById(id)).Returns(_pointerSession);

            // Act
            PointerSession? result = _pointerSessionDomainService.GetPointerSessionById(id);

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

            _pointerSessionRepository.Setup(x => x.GetPointerSessionById(id)).Returns(_pointerSession);

            // Act
            PointerSession? result = _pointerSessionDomainService.GetPointerSessionById(invalidId);

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

            _pointerSessionRepository.Setup(x => x.GetPointerSessionByCode(sessionCode)).Returns(_pointerSession);

            // Act
            PointerSession? result = _pointerSessionDomainService.GetPointerSessionByCode(sessionCode);

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

            _pointerSessionRepository.Setup(x => x.GetPointerSessionByCode(sessionCode)).Returns(_pointerSession);

            // Act
            PointerSession? result = _pointerSessionDomainService.GetPointerSessionByCode("invalidString");

            // Assert
            Assert.IsNull(result);
        }
    }
}
