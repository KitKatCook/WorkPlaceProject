namespace WorkPlaceProject.Domain.SelectedWorkItem
{
    public interface ISelectedWorkItemDomainService
    {
        bool CreateSelectedWorkItem(SelectedWorkItemDdto selectedWorkItemDdto);

        SelectedWorkItem? GetSelectedWorkItemBySessionId(Guid sessionId);

    }
}
