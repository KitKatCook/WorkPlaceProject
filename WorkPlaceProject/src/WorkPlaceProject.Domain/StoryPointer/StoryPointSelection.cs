namespace WorkPlaceProject.Domain.StoryPointer
{
    public class StoryPointSelection
    {
        public StoryPointSelection(Guid id, Guid sessionId, Guid userId, string username, string selectionValue)
        {
            Id = id;
            SessionId = sessionId;
            UserId = userId;
            Username = username;
            SelectionValue = selectionValue;
        }

        public Guid Id { get; protected set; }

        public Guid SessionId { get; protected set; }

        public Guid UserId { get; protected set; }
        public string Username { get; protected set; }

        public string SelectionValue { get; protected set; }
    }
}
