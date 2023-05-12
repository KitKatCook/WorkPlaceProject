namespace WorkPlaceProject.Domain.SessionUser;

public interface ISessionUserRepository
{
    bool CreateSessionUser(SessionUser sessionUser);

    SessionUser? GetSessionUserById(Guid Id);

}
