namespace WorkPlaceProject.Domain.StoryPointer
{
    public interface IStoryPointSelectionDomainService
    {
        bool CreateStoryPointSelection(StoryPointSelectionDdto storyPointSelectionDdto);

        StoryPointSelection? GetStoryPointSelectionById(Guid Id); 
    }
}
