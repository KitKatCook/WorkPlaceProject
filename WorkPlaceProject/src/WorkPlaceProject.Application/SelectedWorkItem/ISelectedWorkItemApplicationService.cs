namespace WorkPlaceProject.Application.SelectedWorkItem
{
    public interface ISelectedWorkItemApplicationService
    {
        bool CreateSelectedWorkItem(SelectedWorkItemAdto SelectedWorkItemAdto);

        WorkPlaceProject.Domain.SelectedWorkItem.SelectedWorkItem? GetSelectedWorkItemBySessionId(Guid sessionId);
    }
}
