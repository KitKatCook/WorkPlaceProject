namespace WorkPlaceProject.Domain.SessionUser
{
    public class SessionUser
    {
        public SessionUser(Guid id, Guid azureId, Guid sessionId, bool isSessionLeader)
        {
            Id = id;
            AzureId = azureId;
            SessionId = sessionId;
            IsSessionLeader = isSessionLeader;
        }

        public Guid Id { get; protected set; }
        public Guid AzureId { get; protected set; }
        public Guid SessionId { get; protected set; }
        public bool IsSessionLeader { get; protected set; }
    }
}
