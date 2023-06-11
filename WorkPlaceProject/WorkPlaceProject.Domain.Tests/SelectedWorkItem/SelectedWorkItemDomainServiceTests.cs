using Moq;
using WorkPlaceProject.Domain.SelectedWorkItem;

namespace WorkPlaceProject.Domain.Tests.SelectedWorkItem
{
    public class SelectedWorkItemRepositoryTests
    {
        private readonly Mock<ISelectedWorkItemRepository> _selectionWorkItemRepository = new();
        private Domain.SelectedWorkItem.SelectedWorkItem _selectedWorkItem;

        private SelectedWorkItemDomainService _selectedWorkItemDomainService;

        [SetUp]
        public void Setup()
        {
            _selectionWorkItemRepository.Reset();

            _selectedWorkItemDomainService =
                new SelectedWorkItemDomainService(_selectionWorkItemRepository.Object);

        }

        [Test]
        public void CreateSelectedWorkItem_CreatesSelectedWorkItem_ReturnsTrue()
        {
            // Arrange
            int id = 1;
            Guid iterationId = Guid.NewGuid();
            Guid teamId = Guid.NewGuid();
            Guid sessionId = Guid.NewGuid();
            string description = "description";
            string acceptanceCriteria = "acceptanceCriteria";
            int? storyPoints = 1;

            SelectedWorkItemDdto selectedWorkItemDdto = new SelectedWorkItemDdto()
            {
                Id = id,
                IterationId = iterationId,
                TeamId = teamId,
                SessionId = sessionId,
                Description = description,
                AcceptanceCriteria = acceptanceCriteria,
                StoryPoints = storyPoints
            };

            _selectionWorkItemRepository.Setup(x => x.CreateSelectedWorkItem(It.Is<Domain.SelectedWorkItem.SelectedWorkItem>(x =>
                    x.Id == id
                    && x.IterationId == iterationId
                    && x.SessionId == sessionId
                    && x.Description == description
                    && x.AcceptanceCriteria == acceptanceCriteria
                    && x.StoryPoints == storyPoints)))
                .Returns(true);

            // Act
            bool result = _selectedWorkItemDomainService.CreateSelectedWorkItem(selectedWorkItemDdto);

            // Assert
            Assert.IsNotNull(result);
            Assert.True(result);
        }

        [Test]
        public void CreateSelectedWorkItem_CreatesSelectedWorkItem_ReturnsFalse()
        {
            // Arrange
            int id = 1;
            Guid iterationId = Guid.NewGuid();
            Guid teamId = Guid.NewGuid();
            Guid sessionId = Guid.NewGuid();
            string description = "description";
            string acceptanceCriteria = "acceptanceCriteria";
            int? storyPoints = 1;

            SelectedWorkItemDdto selectedWorkItemDdto = new SelectedWorkItemDdto()
            {
                Id = id,
                IterationId = iterationId,
                TeamId = teamId,
                SessionId = sessionId,
                Description = description,
                AcceptanceCriteria = acceptanceCriteria,
                StoryPoints = storyPoints
            };

            _selectionWorkItemRepository.Setup(x => x.CreateSelectedWorkItem(It.IsAny<Domain.SelectedWorkItem.SelectedWorkItem>()))
                .Returns(false);

            // Act
            bool result = _selectedWorkItemDomainService.CreateSelectedWorkItem(selectedWorkItemDdto);

            // Assert
            Assert.IsNotNull(result);
            Assert.False(result);
        }

        [Test]
        public void GetSelectedWorkItemBySessionId_ValidSessionId_ReturnsSelectedWorkItem()
        {
            // Arrange
            int id = 1;
            Guid iterationId = Guid.NewGuid();
            Guid teamId = Guid.NewGuid();
            Guid sessionId = Guid.NewGuid();
            string description = "description";
            string acceptanceCriteria = "acceptanceCriteria";
            int? storyPoints = 1;

            _selectedWorkItem = new Domain.SelectedWorkItem.SelectedWorkItem(id, iterationId, teamId, sessionId, description, acceptanceCriteria, storyPoints);

            _selectionWorkItemRepository.Setup(x => x.GetSelectedWorkItemBySessionId(sessionId)).Returns(_selectedWorkItem);

            // Act
            Domain.SelectedWorkItem.SelectedWorkItem? result = _selectedWorkItemDomainService.GetSelectedWorkItemBySessionId(sessionId);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(id));
            Assert.That(result.IterationId, Is.EqualTo(iterationId));
            Assert.That(result.TeamId, Is.EqualTo(teamId));
            Assert.That(result.SessionId, Is.EqualTo(sessionId));
            Assert.That(result.Description, Is.EqualTo(description));
            Assert.That(result.AcceptanceCriteria, Is.EqualTo(acceptanceCriteria));
            Assert.That(result.StoryPoints, Is.EqualTo(storyPoints));
        }

        [Test]
        public void GetSelectedWorkItemBySessionId_InvalidSessionId_ReturnsNull()
        {
            // Arrange
            Guid invalidSessionId = Guid.NewGuid();

            int id = 1;
            Guid iterationId = Guid.NewGuid();
            Guid teamId = Guid.NewGuid();
            Guid sessionId = Guid.NewGuid();
            string description = "description";
            string acceptanceCriteria = "acceptanceCriteria";
            int? storyPoints = 1;

            _selectedWorkItem = new Domain.SelectedWorkItem.SelectedWorkItem(id, iterationId, teamId, sessionId, description, acceptanceCriteria, storyPoints);

            // Act
            Domain.SelectedWorkItem.SelectedWorkItem? result = _selectedWorkItemDomainService.GetSelectedWorkItemBySessionId(invalidSessionId);

            // Assert
            Assert.IsNull(result);
        }
    }
}