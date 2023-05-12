using WorkPlaceProject.Domain.StoryPointerSession;

namespace WorkPlaceProject.Domain.SessionUser
{
    public class SessionUserDomainService : ISessionUserDomainService
    {
        private readonly ISessionUserRepository _sessionUserRepository;

        public SessionUserDomainService(ISessionUserRepository sessionUserRepository)
        {
            _sessionUserRepository = sessionUserRepository;
        }

        public bool CreateSessionUser(SessionUserDdto sessionUserDdto)
        {
            return _sessionUserRepository.CreateSessionUser(
                new SessionUser(
                    sessionUserDdto.Id,
                    sessionUserDdto.AzureId,
                    sessionUserDdto.SessionId,
                    sessionUserDdto.IsSessionLeader
                ));
        }

        public SessionUser? GetSessionUserById(Guid Id)
        {
            return _sessionUserRepository.GetSessionUserById(Id);
        }

    }
}
