namespace WorkPlaceProject.Domain.SelectedWorkItem
{
    public class SelectedWorkItemDomainService : ISelectedWorkItemDomainService
    {
        private readonly ISelectedWorkItemRepository _selectedWorkItemRepository;

        public SelectedWorkItemDomainService(ISelectedWorkItemRepository selectedWorkItemRepository)
        {
            _selectedWorkItemRepository = selectedWorkItemRepository;
        }

        public bool CreateSelectedWorkItem(SelectedWorkItemDdto selectedWorkItemDdto)
        {
            return _selectedWorkItemRepository.CreateSelectedWorkItem(
                new SelectedWorkItem(
                    selectedWorkItemDdto.Id,
                    selectedWorkItemDdto.IterationId,
                    selectedWorkItemDdto.TeamId,
                    selectedWorkItemDdto.SessionId,
                    selectedWorkItemDdto.Description,
                    selectedWorkItemDdto.AcceptanceCriteria,
                    selectedWorkItemDdto.StoryPoints
                ));
        }

        public SelectedWorkItem? GetSelectedWorkItemBySessionId(Guid sessionId)
        {
            return _selectedWorkItemRepository.GetSelectedWorkItemBySessionId(sessionId);
        }

    }
}
