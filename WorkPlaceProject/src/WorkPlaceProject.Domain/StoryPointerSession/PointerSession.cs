namespace WorkPlaceProject.Domain.StoryPointerSession
{
    public class PointerSession
    {
        public PointerSession(Guid id, Guid sessionLeaderId, string sessionCode)
        {
            Id = id;
            SessionLeaderId = sessionLeaderId;
            SessionCode = sessionCode;
        }

        public Guid Id { get; protected set; }

        public Guid SessionLeaderId { get; protected set; }

        public string SessionCode { get; protected set; }
    }
}
