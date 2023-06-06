using NUnit.Framework;
using WorkPlaceProject.Application.DevOpsModels;

namespace WorkPlaceProject.Application.Tests.DevOpsModels
{
    [TestFixture]
    public class DevOpsTeamTests
    {
        [Test]
        public void DevOpsTeam_PropertiesAreCorrectlySet()
        {
            // Arrange
            var id = Guid.NewGuid();
            var projectId = Guid.NewGuid();
            var name = "TeamName";
            var url = "https://example.com";
            var description = "Team Description";
            var identityUrl = "https://example.com/identity";
            var projectName = "ProjectName";

            // Act
            var devOpsTeam = new DevOpsTeam
            {
                Id = id,
                ProjectId = projectId,
                Name = name,
                Url = url,
                Description = description,
                IdentityUrl = identityUrl,
                ProjectName = projectName
            };

            // Assert
            Assert.That(devOpsTeam.Id, Is.EqualTo(id));
            Assert.That(devOpsTeam.ProjectId, Is.EqualTo(projectId));
            Assert.That(devOpsTeam.Name, Is.EqualTo(name));
            Assert.That(devOpsTeam.Url, Is.EqualTo(url));
            Assert.That(devOpsTeam.Description, Is.EqualTo(description));
            Assert.That(devOpsTeam.IdentityUrl, Is.EqualTo(identityUrl));
            Assert.That(devOpsTeam.ProjectName, Is.EqualTo(projectName));
        }
    }
}
