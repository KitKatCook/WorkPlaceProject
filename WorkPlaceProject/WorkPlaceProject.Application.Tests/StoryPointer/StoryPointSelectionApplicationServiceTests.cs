using Moq;
using WorkPlaceProject.Application.StoryPointer;
using WorkPlaceProject.Domain;
using WorkPlaceProject.Domain.StoryPointer;

namespace WorkPlaceProject.Application.Tests.StoryPointSelection
{
    public class StoryPointSelectionApplicationServiceTests
    {
        private readonly Mock<IStoryPointSelectionDomainService> _storyPointSelectionDomainService = new();
        private Domain.StoryPointer.StoryPointSelection _storyPointSelection;

        private StoryPointSelectionApplicationService _storyPointSelectionApplicationService;

        [SetUp]
        public void Setup()
        {
            _storyPointSelectionDomainService.Reset();

            _storyPointSelectionApplicationService =
                new StoryPointSelectionApplicationService(_storyPointSelectionDomainService.Object);

        }

        [Test]
        public void CreateStoryPointSelection_CreatesStoryPointSelection_ReturnsTrue()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Guid sessionId = Guid.NewGuid();
            Guid userId = Guid.NewGuid();
            string username = "username";
            int selectionValue = 1;

            StoryPointSelectionAdto storyPointSelectionAdto = new StoryPointSelectionAdto()
            {
                Id = id,
                SessionId = sessionId,
                UserId = userId,
                Username = username,
                SelectionValue = selectionValue
            };

            _storyPointSelectionDomainService.Setup(x => x.CreateStoryPointSelection(It.Is<StoryPointSelectionDdto>(x =>
                    x.Id == id
                    && x.SessionId == sessionId
                    && x.UserId == userId
                    && x.Username == username
                    && x.SelectionValue == selectionValue
                    )))
                .Returns(true);

            // Act
            bool result = _storyPointSelectionApplicationService.CreateStoryPointSelection(storyPointSelectionAdto);

            // Assert
            Assert.IsNotNull(result);
            Assert.True(result);
        }

        [Test]
        public void CreateStoryPointSelection_CreatesStoryPointSelection_ReturnsFalse()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Guid sessionId = Guid.NewGuid();
            Guid userId = Guid.NewGuid();
            string username = "username";
            int selectionValue = 1;

            StoryPointSelectionAdto storyPointSelectionAdto = new StoryPointSelectionAdto()
            {
                Id = id,
                SessionId = sessionId,
                UserId = userId,
                Username = username,
                SelectionValue = selectionValue
            };

            _storyPointSelectionDomainService.Setup(x => x.CreateStoryPointSelection(It.Is<StoryPointSelectionDdto>(x =>
                    x.Id == userId
                    && x.SessionId == sessionId
                    && x.UserId == userId
                    && x.Username == username
                    && x.SelectionValue == selectionValue
                    )))
                .Returns(false);

            // Act
            bool result = _storyPointSelectionApplicationService.CreateStoryPointSelection(storyPointSelectionAdto);

            // Assert
            Assert.IsNotNull(result);
            Assert.False(result);
        }

        [Test]
        public void GetStoryPointSelectionById_GetsStoryPointSelection_ReturnsStoryPointSelection()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Guid sessionId = Guid.NewGuid();
            Guid userId = Guid.NewGuid();
            string username = "username";
            string selectionValue = "1";

            _storyPointSelection = new Domain.StoryPointer.StoryPointSelection(id, sessionId, userId, username, selectionValue);

            _storyPointSelectionDomainService.Setup(x => x.GetStoryPointSelectionById(id)).Returns(_storyPointSelection);

            // Act
            Domain.StoryPointer.StoryPointSelection? result = _storyPointSelectionApplicationService.GetStoryPointSelectionById(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(id));
            Assert.That(result.SessionId, Is.EqualTo(sessionId));
            Assert.That(result.UserId, Is.EqualTo(userId));
            Assert.That(result.Username, Is.EqualTo(username));
            Assert.That(result.SelectionValue, Is.EqualTo(selectionValue));
        }

        [Test]
        public void GetStoryPointSelectionById_NoStoryPointSelection_ReturnsNull()
        {
            // Arrange
            Guid invalidId = Guid.NewGuid();

            Guid id = Guid.NewGuid();
            Guid sessionId = Guid.NewGuid();
            Guid userId = Guid.NewGuid();
            string username = "username";
            string selectionValue = "1";

            _storyPointSelection = new Domain.StoryPointer.StoryPointSelection(id, sessionId, userId, username, selectionValue);

            _storyPointSelectionDomainService.Setup(x => x.GetStoryPointSelectionById(id)).Returns(_storyPointSelection);

            // Act
            Domain.StoryPointer.StoryPointSelection? result = _storyPointSelectionApplicationService.GetStoryPointSelectionById(invalidId);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetStoryPointSelectionBySessionId_GetsStoryPointSelection_ReturnsStoryPointSelections()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Guid sessionId = Guid.NewGuid();
            Guid userId = Guid.NewGuid();
            string username = "username";
            string selectionValue = "1";

            _storyPointSelection = new Domain.StoryPointer.StoryPointSelection(id, sessionId, userId, username, selectionValue);

            IEnumerable<Domain.StoryPointer.StoryPointSelection> storyPointSelections = new List<Domain.StoryPointer.StoryPointSelection>() 
            {
                _storyPointSelection            
            };

            _storyPointSelectionDomainService.Setup(x => x.GetStoryPointSelectionBySessionId(sessionId)).Returns(storyPointSelections);

            // Act
            IEnumerable<Domain.StoryPointer.StoryPointSelection> result = _storyPointSelectionApplicationService.GetStoryPointSelectionBySessionId(sessionId);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().Id, Is.EqualTo(id));
            Assert.That(result.First().SessionId, Is.EqualTo(sessionId));
            Assert.That(result.First().UserId, Is.EqualTo(userId));
            Assert.That(result.First().Username, Is.EqualTo(username));
            Assert.That(result.First().SelectionValue, Is.EqualTo(selectionValue));
        }

        [Test]
        public void GetStoryPointSelectionBySessionId_NoStoryPointSelection_ReturnsEmptyCollection()
        {
            // Arrange
            Guid invalidId = Guid.NewGuid();

            Guid id = Guid.NewGuid();
            Guid sessionId = Guid.NewGuid();
            Guid userId = Guid.NewGuid();
            string username = "username";
            string selectionValue = "1";

            _storyPointSelection = new Domain.StoryPointer.StoryPointSelection(id, sessionId, userId, username, selectionValue);

            IEnumerable<Domain.StoryPointer.StoryPointSelection> storyPointSelections = new List<Domain.StoryPointer.StoryPointSelection>();

            _storyPointSelectionDomainService.Setup(x => x.GetStoryPointSelectionBySessionId(id)).Returns(storyPointSelections);

            // Act
            IEnumerable<Domain.StoryPointer.StoryPointSelection> result = _storyPointSelectionApplicationService.GetStoryPointSelectionBySessionId(invalidId);

            // Assert
            Assert.That(result.Count(), Is.EqualTo(0));
        }

        [Test]
        public void DeleteStoryPointSelectionByUserId_CreatesStoryPointSelection_ReturnsTrue()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Guid sessionId = Guid.NewGuid();
            Guid userId = Guid.NewGuid();
            string username = "username";
            int selectionValue = 1;

            StoryPointSelectionAdto storyPointSelectionAdto = new StoryPointSelectionAdto()
            {
                Id = id,
                SessionId = sessionId,
                UserId = userId,
                Username = username,
                SelectionValue = selectionValue
            };

            _storyPointSelectionDomainService.Setup(x => x.DeleteStoryPointSelectionByUserId(userId)).Returns(true);

            // Act
            bool result = _storyPointSelectionApplicationService.DeleteStoryPointSelectionByUserId(userId);

            // Assert
            Assert.IsNotNull(result);
            Assert.True(result);
        }

        [Test]
        public void DeleteStoryPointSelectionByUserId_CreatesStoryPointSelection_ReturnsFalse()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Guid sessionId = Guid.NewGuid();
            Guid userId = Guid.NewGuid();
            string username = "username";
            int selectionValue = 1;

            StoryPointSelectionAdto storyPointSelectionAdto = new StoryPointSelectionAdto()
            {
                Id = id,
                SessionId = sessionId,
                UserId = userId,
                Username = username,
                SelectionValue = selectionValue
            };

            _storyPointSelectionDomainService.Setup(x => x.DeleteStoryPointSelectionByUserId(userId)).Returns(false);

            // Act
            bool result = _storyPointSelectionApplicationService.DeleteStoryPointSelectionByUserId(userId);

            // Assert
            Assert.IsNotNull(result);
            Assert.False(result);
        }
    }
}