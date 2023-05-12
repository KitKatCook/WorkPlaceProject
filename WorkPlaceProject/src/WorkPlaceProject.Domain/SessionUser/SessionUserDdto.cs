namespace WorkPlaceProject.Domain.SessionUser
{
    public class SessionUserDdto
    {
        public Guid Id { get; set; }
        public Guid AzureId { get; set; }
        public Guid SessionId { get; set; }
        public bool IsSessionLeader { get; set; }
    }
}
