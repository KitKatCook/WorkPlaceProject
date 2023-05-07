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
                    storyPointSelectionDdto.Username,
                    storyPointSelectionDdto.SelectionValue
                ));
        }

        public StoryPointSelection? GetStoryPointSelectionById(Guid Id)
        {
            return storyPointSelectionRepository.GetStoryPointSelectionById(Id);
        }

        public IEnumerable<StoryPointSelection> GetStoryPointSelectionBySessionId(Guid SessionId)
        {
            return storyPointSelectionRepository.GetStoryPointSelectionBySessionId(SessionId);
        }

        public bool DeleteStoryPointSelectionByUserId(Guid UserId)
        {
            return storyPointSelectionRepository.DeleteStoryPointSelectionByUserId(UserId);
        }
    }
}
