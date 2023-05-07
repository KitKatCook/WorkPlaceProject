namespace WorkPlaceProject.Domain.StoryPointer
{
    public interface IStoryPointSelectionRepository
    {
        bool CreateStoryPointSelection(StoryPointSelection storyPointSelection);

        StoryPointSelection? GetStoryPointSelectionById(Guid Id);

        IEnumerable<StoryPointSelection> GetStoryPointSelectionBySessionId(Guid SessionId);
        bool DeleteStoryPointSelectionByUserId(Guid UserId);

    }
}
