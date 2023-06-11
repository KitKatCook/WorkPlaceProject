using Moq;
using WorkPlaceProject.Domain.StoryPointer;

namespace WorkPlaceProject.Domain.Tests.StoryPointer
{
    public class StoryPointSelectionRepositoryTests
    {
        private readonly Mock<IStoryPointSelectionRepository> _storyPointSelectionRepository = new();
        private StoryPointSelection _storyPointSelection;

        private StoryPointSelectionDomainService _storyPointSelectionDomainService;

        [SetUp]
        public void Setup()
        {
            _storyPointSelectionRepository.Reset();

            _storyPointSelectionDomainService =
                new StoryPointSelectionDomainService(_storyPointSelectionRepository.Object);

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

            StoryPointSelectionDdto storyPointSelectionDdto = new StoryPointSelectionDdto()
            {
                Id = id,
                SessionId = sessionId,
                UserId = userId,
                Username = username,
                SelectionValue = selectionValue
            };

            _storyPointSelectionRepository.Setup(x => x.CreateStoryPointSelection(It.Is<StoryPointSelection>(x =>
                    x.Id == id
                    && x.SessionId == sessionId
                    && x.UserId == userId
                    && x.Username == username
                    && x.SelectionValue == "1"
                    )))
                .Returns(true);

            // Act
            bool result = _storyPointSelectionDomainService.CreateStoryPointSelection(storyPointSelectionDdto);

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

            StoryPointSelectionDdto storyPointSelectionDdto = new StoryPointSelectionDdto()
            {
                Id = id,
                SessionId = sessionId,
                UserId = userId,
                Username = username,
                SelectionValue = selectionValue
            };

            _storyPointSelectionRepository.Setup(x => x.CreateStoryPointSelection(It.Is<StoryPointSelection>(x =>
                    x.Id == userId
                    && x.SessionId == sessionId
                    && x.UserId == userId
                    && x.Username == username
                    && x.SelectionValue == "1"
                    )))
                .Returns(false);

            // Act
            bool result = _storyPointSelectionDomainService.CreateStoryPointSelection(storyPointSelectionDdto);

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

            _storyPointSelection = new StoryPointSelection(id, sessionId, userId, username, selectionValue);

            _storyPointSelectionRepository.Setup(x => x.GetStoryPointSelectionById(id)).Returns(_storyPointSelection);

            // Act
            StoryPointSelection? result = _storyPointSelectionDomainService.GetStoryPointSelectionById(id);

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

            _storyPointSelection = new StoryPointSelection(id, sessionId, userId, username, selectionValue);

            _storyPointSelectionRepository.Setup(x => x.GetStoryPointSelectionById(id)).Returns(_storyPointSelection);

            // Act
            StoryPointSelection? result = _storyPointSelectionDomainService.GetStoryPointSelectionById(invalidId);

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

            _storyPointSelection = new StoryPointSelection(id, sessionId, userId, username, selectionValue);

            IEnumerable<StoryPointSelection> storyPointSelections = new List<StoryPointSelection>()
            {
                _storyPointSelection
            };

            _storyPointSelectionRepository.Setup(x => x.GetStoryPointSelectionBySessionId(sessionId)).Returns(storyPointSelections);

            // Act
            IEnumerable<Domain.StoryPointer.StoryPointSelection> result = _storyPointSelectionDomainService.GetStoryPointSelectionBySessionId(sessionId);

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

            IEnumerable<StoryPointSelection> storyPointSelections = new List<StoryPointSelection>();

            _storyPointSelectionRepository.Setup(x => x.GetStoryPointSelectionBySessionId(id)).Returns(storyPointSelections);

            // Act
            IEnumerable<Domain.StoryPointer.StoryPointSelection> result = _storyPointSelectionDomainService.GetStoryPointSelectionBySessionId(invalidId);

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

            StoryPointSelectionDdto storyPointSelectionDdto = new StoryPointSelectionDdto()
            {
                Id = id,
                SessionId = sessionId,
                UserId = userId,
                Username = username,
                SelectionValue = selectionValue
            };

            _storyPointSelectionRepository.Setup(x => x.DeleteStoryPointSelectionByUserId(userId)).Returns(true);

            // Act
            bool result = _storyPointSelectionDomainService.DeleteStoryPointSelectionByUserId(userId);

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

            StoryPointSelectionDdto storyPointSelectionDdto = new StoryPointSelectionDdto()
            {
                Id = id,
                SessionId = sessionId,
                UserId = userId,
                Username = username,
                SelectionValue = selectionValue
            };

            _storyPointSelectionRepository.Setup(x => x.DeleteStoryPointSelectionByUserId(userId)).Returns(false);

            // Act
            bool result = _storyPointSelectionDomainService.DeleteStoryPointSelectionByUserId(userId);

            // Assert
            Assert.IsNotNull(result);
            Assert.False(result);
        }
    }
}