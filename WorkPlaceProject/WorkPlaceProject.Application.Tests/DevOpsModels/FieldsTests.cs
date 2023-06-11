
using WorkPlaceProject.Application.DevOpsModels;

namespace WorkPlaceProject.Application.Tests.DevOpsModels
{
    [TestFixture]
    public class FieldsTests
    {
        [Test]
        public void Fields_Properties_SetAndGetCorrectly()
        {
            // Arrange
            var fields = new Fields();

            // Act
            fields.AreaPath = "AreaPath";
            fields.TeamProject = "TeamProject";
            fields.IterationPath = "IterationPath";
            fields.WorkItemType = "WorkItemType";
            fields.State = "State";
            fields.Reason = "Reason";
            fields.CommentCount = 5;
            fields.Title = "Title";
            fields.BoardColumn = "BoardColumn";
            fields.StoryPoints = "StoryPoints";
            fields.Effort = "Effort";
            fields.Description = "Description";
            fields.AcceptanceCriteria = "AcceptanceCriteria";

            // Assert
            Assert.That(fields.AreaPath, Is.EqualTo("AreaPath"));
            Assert.That(fields.TeamProject, Is.EqualTo("TeamProject"));
            Assert.That(fields.IterationPath, Is.EqualTo("IterationPath"));
            Assert.That(fields.WorkItemType, Is.EqualTo("WorkItemType"));   
            Assert.That(fields.State, Is.EqualTo("State"));
            Assert.That(fields.Reason, Is.EqualTo("Reason"));
            Assert.That(fields.CommentCount, Is.EqualTo(5));
            Assert.That(fields.Title, Is.EqualTo("Title"));
            Assert.That(fields.BoardColumn, Is.EqualTo("BoardColumn"));
            Assert.That(fields.StoryPoints, Is.EqualTo("StoryPoints"));
            Assert.That(fields.Effort, Is.EqualTo("Effort"));
            Assert.That(fields.Description, Is.EqualTo("Description"));
            Assert.That(fields.AcceptanceCriteria, Is.EqualTo("AcceptanceCriteria"));
        }
    }
}