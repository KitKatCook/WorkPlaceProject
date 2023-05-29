namespace WorkPlaceProject.Domain.SelectedWorkItem;

public interface ISelectedWorkItemRepository
{
    bool CreateSelectedWorkItem(Domain.SelectedWorkItem.SelectedWorkItem selectedWorkItem);
    Domain.SelectedWorkItem.SelectedWorkItem? GetSelectedWorkItemBySessionId(Guid sessionId);

}
