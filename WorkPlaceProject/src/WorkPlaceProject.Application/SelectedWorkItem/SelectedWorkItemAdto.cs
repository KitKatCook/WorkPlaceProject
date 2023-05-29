namespace WorkPlaceProject.Application.SelectedWorkItem
{
    public class SelectedWorkItemAdto
    {
        public int Id { get; set; }
        public Guid SessionId { get; set; }
        public string Description { get; set; }
        public string AcceptanceCriteria { get; set; }
        public int? StoryPoints { get; set; }
    }
}
