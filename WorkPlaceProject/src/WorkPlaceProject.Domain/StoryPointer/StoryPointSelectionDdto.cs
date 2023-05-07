namespace WorkPlaceProject.Domain
{
    public class StoryPointSelectionDdto
    {
        public Guid Id { get; set; }
        public Guid SessionId { get; set; }
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string SelectionValue { get; set; }
    }
}
