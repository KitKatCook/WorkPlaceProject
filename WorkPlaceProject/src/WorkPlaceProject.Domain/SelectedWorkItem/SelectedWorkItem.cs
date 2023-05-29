namespace WorkPlaceProject.Domain.SelectedWorkItem
{
    public class SelectedWorkItem
    {
        public SelectedWorkItem(int id, Guid sessionId, string description, string acceptanceCriteria, int? storyPoints)
        {
            Id = id;
            SessionId = sessionId;
            Description = description;
            AcceptanceCriteria = acceptanceCriteria;
            StoryPoints = storyPoints;
        }

        public int Id { get; }
        public Guid SessionId { get; }
        public string Description { get; }
        public string AcceptanceCriteria { get; }
        public int? StoryPoints { get; }
    }
}
