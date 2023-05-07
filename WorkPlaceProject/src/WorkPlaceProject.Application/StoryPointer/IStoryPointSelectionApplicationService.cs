using WorkPlaceProject.Domain.StoryPointer;

namespace WorkPlaceProject.Application.StoryPointer
{
    public interface IStoryPointSelectionApplicationService
    {
        bool CreateStoryPointSelection(StoryPointSelectionAdto storyPointSelectionDdto);

        StoryPointSelection? GetStoryPointSelectionById(Guid Id);

        IEnumerable<StoryPointSelection> GetStoryPointSelectionBySessionId(Guid SessionId);
        
        bool DeleteStoryPointSelectionByUserId(Guid UserId);
    }
}
