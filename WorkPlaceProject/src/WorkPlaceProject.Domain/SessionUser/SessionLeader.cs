namespace WorkPlaceProject.Domain.SessionUser
{
    public class SessionLeader : SUser
    {
        public SessionLeader(Guid id, Guid azureId, Guid sessionId, bool isSessionLeader) 
            : base(id, azureId, sessionId, isSessionLeader)
        {

        }

        public static SessionLeader Create(Guid id, Guid azureId, Guid sessionId)
        {
            return new SessionLeader(id, azureId, sessionId, false);
        }
    }
}
