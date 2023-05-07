using WorkPlaceProject.Domain;
using WorkPlaceProject.Domain.StoryPointer;

namespace WorkPlaceProject.Application.StoryPointer
{
    public class StoryPointSelectionApplicationService : IStoryPointSelectionApplicationService
    {
        private readonly IStoryPointSelectionDomainService _storyPointSelectionDomainService;

        public StoryPointSelectionApplicationService(IStoryPointSelectionDomainService storyPointSelectionDomainService)      
        {
            _storyPointSelectionDomainService = storyPointSelectionDomainService;
        }

        public bool CreateStoryPointSelection(StoryPointSelectionAdto storyPointSelectionAdto)
        {
            return _storyPointSelectionDomainService.CreateStoryPointSelection(
                new StoryPointSelectionDdto()
                {
                    Id = storyPointSelectionAdto.Id,
                    SessionId = storyPointSelectionAdto.SessionId,
                    UserId = storyPointSelectionAdto.UserId,
                    SelectionValue = storyPointSelectionAdto.SelectionValue
                });
        }

        public StoryPointSelection? GetStoryPointSelectionById(Guid Id)
        {
            return _storyPointSelectionDomainService.GetStoryPointSelectionById(Id);
        }
    }
}
