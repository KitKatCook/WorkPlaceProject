namespace WorkPlaceProject.Domain.StoryPointer
{
    public class StoryPointSelectionDomainService : IStoryPointSelectionDomainService
    {
        private readonly IStoryPointSelectionRepository storyPointSelectionRepository;

        public StoryPointSelectionDomainService(IStoryPointSelectionRepository storyPointSelectionRepository)      
        {
            this.storyPointSelectionRepository = storyPointSelectionRepository;
        }

        public bool CreateStoryPointSelection(StoryPointSelectionDdto storyPointSelectionDdto)
        {
            return storyPointSelectionRepository.CreateStoryPointSelection(
                new StoryPointSelection(
                    storyPointSelectionDdto.Id,
                    storyPointSelectionDdto.SessionId,
                    storyPointSelectionDdto.UserId,
                    storyPointSelectionDdto.SelectionValue
                ));
        }

        public StoryPointSelection? GetStoryPointSelectionById(Guid Id)
        {
            return storyPointSelectionRepository.GetStoryPointSelectionById(Id);
        }
    }
}
