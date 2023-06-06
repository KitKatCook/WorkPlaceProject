namespace WorkPlaceProject.Domain.SelectedWorkItem
{
    public class SelectedWorkItem
    {
        public SelectedWorkItem(int id, Guid iterationId, Guid teamId, Guid sessionId, string description, string acceptanceCriteria, int? storyPoints)
        {
            Id = id;
            IterationId = iterationId;
            TeamId = teamId;
            SessionId = sessionId;
            Description = description;
            AcceptanceCriteria = acceptanceCriteria;
            StoryPoints = storyPoints;

        }

        public int Id { get; }
        public Guid IterationId { get; }
        public Guid TeamId { get; }
        public Guid SessionId { get; }
        public string Description { get; }
        public string AcceptanceCriteria { get; }
        public int? StoryPoints { get; }
    }
}
