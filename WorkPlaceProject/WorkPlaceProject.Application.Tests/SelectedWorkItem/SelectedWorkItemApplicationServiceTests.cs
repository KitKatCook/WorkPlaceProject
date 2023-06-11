using Moq;
using WorkPlaceProject.Application.SelectedWorkItem;
using WorkPlaceProject.Domain.SelectedWorkItem;

namespace WorkPlaceProject.Application.Tests.SelectedWorkItem
{
    public class SelectedWorkItemApplicationServiceTests
    {
        private readonly Mock<ISelectedWorkItemDomainService> _selectionWorkItemDomainService = new();
        private Domain.SelectedWorkItem.SelectedWorkItem _selectedWorkItem;

        private SelectedWorkItemApplicationService _selectedWorkItemApplicationService;

        [SetUp]
        public void Setup()
        {
            _selectionWorkItemDomainService.Reset();

            _selectedWorkItemApplicationService =
                new SelectedWorkItemApplicationService(_selectionWorkItemDomainService.Object);

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

            SelectedWorkItemAdto selectedWorkItemAdto = new SelectedWorkItemAdto()
            {
                Id = id,
                IterationId = iterationId,
                TeamId = teamId,
                SessionId = sessionId,
                Description = description,
                AcceptanceCriteria = acceptanceCriteria,
                StoryPoints = storyPoints
            };

            _selectionWorkItemDomainService.Setup(x => x.CreateSelectedWorkItem(It.Is<SelectedWorkItemDdto>(x => 
                    x.Id == id 
                    && x.IterationId == iterationId 
                    && x.SessionId == sessionId 
                    && x.Description == description 
                    && x.AcceptanceCriteria == acceptanceCriteria 
                    && x.StoryPoints == storyPoints)))
                .Returns(true);

            // Act
            bool result = _selectedWorkItemApplicationService.CreateSelectedWorkItem(selectedWorkItemAdto);

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

            SelectedWorkItemAdto selectedWorkItemAdto = new SelectedWorkItemAdto()
            {
                Id = id,
                IterationId = iterationId,
                TeamId = teamId,
                SessionId = sessionId,
                Description = description,
                AcceptanceCriteria = acceptanceCriteria,
                StoryPoints = storyPoints
            };

            _selectionWorkItemDomainService.Setup(x => x.CreateSelectedWorkItem(It.IsAny<SelectedWorkItemDdto>()))
                .Returns(false);

            // Act
            bool result = _selectedWorkItemApplicationService.CreateSelectedWorkItem(selectedWorkItemAdto);

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

            _selectionWorkItemDomainService.Setup(x => x.GetSelectedWorkItemBySessionId(sessionId)).Returns(_selectedWorkItem);

            // Act
            Domain.SelectedWorkItem.SelectedWorkItem? result = _selectedWorkItemApplicationService.GetSelectedWorkItemBySessionId(sessionId);

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
            Domain.SelectedWorkItem.SelectedWorkItem? result = _selectedWorkItemApplicationService.GetSelectedWorkItemBySessionId(invalidSessionId);

            // Assert
            Assert.IsNull(result);
        }
    }
}