namespace WorkPlaceProject.Domain.StoryPointerSession
{
    public class PointerSessionDdto
    {
        public Guid Id { get; set; }
        public Guid SessionLeaderId { get; set; }
        public string SessionCode { get; set; }
    }
}
