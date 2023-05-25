namespace WorkPlaceProject.Domain.SessionUser
{
    public class SessionUser : SUser
    {
        public SessionUser(Guid id, Guid azureId, Guid sessionId, bool isSessionLeader) 
            : base(id, azureId, sessionId, isSessionLeader)
        {

        }


        public static SessionUser Create(Guid id, Guid azureId, Guid sessionId)
        {
            return new SessionUser(id, azureId, sessionId, false);
        }
    }
}
