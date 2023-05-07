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
                    Username = storyPointSelectionAdto.Username,
                    SelectionValue = storyPointSelectionAdto.SelectionValue
                });
        }

        public StoryPointSelection? GetStoryPointSelectionById(Guid Id)
        {
            return _storyPointSelectionDomainService.GetStoryPointSelectionById(Id);
        }
        
        public IEnumerable<StoryPointSelection> GetStoryPointSelectionBySessionId(Guid SessionId)
        {
            return _storyPointSelectionDomainService.GetStoryPointSelectionBySessionId(SessionId);
        }

        public bool DeleteStoryPointSelectionByUserId(Guid UserId)
        {
            return _storyPointSelectionDomainService.DeleteStoryPointSelectionByUserId(UserId);
        }
    }
}
