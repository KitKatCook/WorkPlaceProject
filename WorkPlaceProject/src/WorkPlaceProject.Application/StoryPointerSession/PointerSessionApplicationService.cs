using WorkPlaceProject.Domain.StoryPointerSession;

namespace WorkPlaceProject.Application.StoryPointerSession
{
    public class PointerSessionApplicationService : IPointerSessionApplicationService
    {
        private readonly IPointerSessionDomainService _pointerSessionDomainService;

        public PointerSessionApplicationService(IPointerSessionDomainService pointerSessionDomainService)      
        {
            _pointerSessionDomainService = pointerSessionDomainService;
        }

        public bool CreatePointerSession(PointerSessionAdto pointerSessionAdto)
        {
            return _pointerSessionDomainService.CreatePointerSession(
                new PointerSessionDdto()
                {
                    Id = pointerSessionAdto.Id,
                    SessionLeaderId = pointerSessionAdto.SessionLeaderId,
                    SessionCode = pointerSessionAdto.SessionCode
                });
        }

        public PointerSession? GetPointerSessionById(Guid Id)
        {
            return _pointerSessionDomainService.GetPointerSessionById(Id);
        }

        public PointerSession? GetPointerSessionByCode(string code)
        {
            return _pointerSessionDomainService.GetPointerSessionByCode(code);
        }
    }
}
