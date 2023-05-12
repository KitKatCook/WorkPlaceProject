namespace WorkPlaceProject.Domain.SessionUser
{
    public interface ISessionUserDomainService
    {
        bool CreateSessionUser(SessionUserDdto sessionUserDdto);

        SessionUser? GetSessionUserById(Guid Id);

    }
}
