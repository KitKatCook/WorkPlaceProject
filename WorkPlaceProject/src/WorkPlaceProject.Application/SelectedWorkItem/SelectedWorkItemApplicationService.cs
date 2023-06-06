using WorkPlaceProject.Domain.SelectedWorkItem;

namespace WorkPlaceProject.Application.SelectedWorkItem
{
    public class SelectedWorkItemApplicationService : ISelectedWorkItemApplicationService
    {
        private readonly ISelectedWorkItemDomainService _selectedWorkItemDomainService;

        public SelectedWorkItemApplicationService(ISelectedWorkItemDomainService selectedWorkItemDomainService)
        {
            _selectedWorkItemDomainService = selectedWorkItemDomainService;
        }

        public bool CreateSelectedWorkItem(SelectedWorkItemAdto selectedWorkItemAdto)
        {
            return _selectedWorkItemDomainService.CreateSelectedWorkItem(
                new SelectedWorkItemDdto()
                {
                    Id = selectedWorkItemAdto.Id,
                    IterationId = selectedWorkItemAdto.IterationId,
                    TeamId = selectedWorkItemAdto.TeamId,
                    SessionId = selectedWorkItemAdto.SessionId,
                    Description = selectedWorkItemAdto.Description,
                    AcceptanceCriteria = selectedWorkItemAdto.AcceptanceCriteria,
                    StoryPoints = selectedWorkItemAdto.StoryPoints,
                });
        }

        public Domain.SelectedWorkItem.SelectedWorkItem? GetSelectedWorkItemBySessionId(Guid sessionId)
        {
            return _selectedWorkItemDomainService.GetSelectedWorkItemBySessionId(sessionId);
        }
    }
}
