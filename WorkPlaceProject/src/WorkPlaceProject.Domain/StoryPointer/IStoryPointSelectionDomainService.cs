namespace WorkPlaceProject.Domain.StoryPointer
{
    public interface IStoryPointSelectionDomainService
    {
        bool CreateStoryPointSelection(StoryPointSelectionDdto storyPointSelectionDdto);

        StoryPointSelection? GetStoryPointSelectionById(Guid Id);

        IEnumerable<StoryPointSelection> GetStoryPointSelectionBySessionId(Guid SessionId);

        bool DeleteStoryPointSelectionByUserId(Guid UserId);
    }
}
