
namespace WorkPlaceProject.Application.SessionUser
{
    public interface ISessionUserApplicationService
    {
        bool CreateSessionUser(SessionUserAdto sessionUserAdto);

        Domain.SessionUser.SessionUser? GetSessionUserById(Guid Id);
    }
}
