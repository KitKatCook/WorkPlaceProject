using WorkPlaceProject.Domain.SessionUser;

namespace WorkPlaceProject.Application.SessionUser
{
    public class SessionUserApplicationService : ISessionUserApplicationService
    {
        private readonly ISessionUserDomainService _sessionUserDomainService;

        public SessionUserApplicationService(ISessionUserDomainService sessionUserDomainService)
        {
            _sessionUserDomainService = sessionUserDomainService;
        }

        public bool CreateSessionUser(SessionUserAdto sessionUserAdto)
        {
            return _sessionUserDomainService.CreateSessionUser(
                new SessionUserDdto()
                {
                    Id = sessionUserAdto.Id,
                    AzureId = sessionUserAdto.AzureId,
                    SessionId = sessionUserAdto.SessionId,
                    IsSessionLeader = sessionUserAdto.IsSessionLeader
                });
        }

        public Domain.SessionUser.SessionUser? GetSessionUserById(Guid Id)
        {
            return _sessionUserDomainService.GetSessionUserById(Id);
        }
    }
}
