using Moq;
using NUnit.Framework.Internal.Execution;

namespace WorkPlaceProject.Web
{
    public class ApiClientTests
    {
        //private Mock<IAzureDevOpsService> azureDevOpsServiceMock;
        //private WorkItemService workItemService;

        //[SetUp]
        //public void SetUp()
        //{
        //    azureDevOpsServiceMock = new Mock<IAzureDevOpsService>();
        //    workItemService = new WorkItemService(azureDevOpsServiceMock.Object);
        //}

        //[Test]
        //public async Task PatchWorkItemStoryPoints_ReturnsWorkItem()
        //{
        //    // Arrange
        //    int storyPoints = 5;
        //    int workItemId = 123;

        //    azureDevOpsServiceMock.Setup(x => x.Patch<WorkItem>(It.IsAny<string>(), It.IsAny<StringContent>()))
        //        .ReturnsAsync(new WorkItem());

        //    // Act
        //    var result = await workItemService.PatchWorkItemStoryPoints(storyPoints, workItemId);

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.IsInstanceOf<WorkItem>(result);
        //}
    }
}