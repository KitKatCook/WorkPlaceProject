using NUnit.Framework;
using WorkPlaceProject.Web.Ioc.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPlaceProject.Application.DevOpsModels;

namespace WorkPlaceProject.Web.Ioc.Http.Tests
{
    [TestFixture()]
    public class ApiClientTests
    {
        private ApiClient apiClient;

        [SetUp]
        public void SetUp()
        {
            apiClient = new ApiClient();
        }

        [Test]
        public async Task ApiClient_GetTeams_ReturnsListOfDevOpsTeams()
        {
            // Act
            IEnumerable<DevOpsTeam> teams = await apiClient.GetTeams();

            // Assert
            Assert.IsNotNull(teams);
            Assert.IsInstanceOf<IEnumerable<DevOpsTeam>>(teams);
        }

        [Test]
        public async Task ApiClient_GetIterations_ReturnsListOfIterations()
        {
            // Arrange
            Guid teamId = Guid.NewGuid();

            // Act
            IEnumerable<Iteration> iterations = await apiClient.GetIterations(teamId);

            // Assert
            Assert.IsNotNull(iterations);
            Assert.IsInstanceOf<IEnumerable<Iteration>>(iterations);
        }

        [Test]
        public async Task ApiClient_GetWorkItems_ReturnsListOfWorkItems()
        {
            // Arrange
            Guid teamId = Guid.NewGuid();
            Guid iterationId = Guid.NewGuid();

            // Act
            IEnumerable<WorkItem> workItems = await apiClient.GetWorkItems(teamId, iterationId);

            // Assert
            Assert.IsNotNull(workItems);
            Assert.IsInstanceOf<IEnumerable<WorkItem>>(workItems);
        }

        [Test]
        public async Task ApiClient_GetWorkItem_ReturnsWorkItem()
        {
            // Arrange
            int workItemId = 12345;

            // Act
            WorkItem? workItem = await apiClient.GetWorkItem(workItemId);

            // Assert
            Assert.IsNotNull(workItem);
            Assert.IsInstanceOf<WorkItem>(workItem);
        }

        [Test]
        public async Task ApiClient_PatchWorkItemStoryPoints_ReturnsUpdatedWorkItem()
        {
            // Arrange
            int storyPoints = 5;
            int workItemId = 12345;

            // Act
            WorkItem? updatedWorkItem = await apiClient.PatchWorkItemStoryPoints(storyPoints, workItemId);

            // Assert
            Assert.IsNotNull(updatedWorkItem);
            Assert.IsInstanceOf<WorkItem>(updatedWorkItem);
        }
    }
}