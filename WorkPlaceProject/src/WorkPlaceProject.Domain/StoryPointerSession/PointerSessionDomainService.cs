namespace WorkPlaceProject.Domain.StoryPointerSession
{
    public class PointerSessionDomainService : IPointerSessionDomainService
    {
        private readonly IPointerSessionRepository pointerSessionRepository;

        public PointerSessionDomainService(IPointerSessionRepository pointerSessionRepository)      
        {
            this.pointerSessionRepository = pointerSessionRepository;
        }

        public bool CreatePointerSession(PointerSessionDdto pointerSessionDdto)
        {
            return pointerSessionRepository.CreatePointerSession(
                new PointerSession(
                    pointerSessionDdto.Id,
                    pointerSessionDdto.SessionLeaderId,
                    pointerSessionDdto.SessionCode
                ));
        }

        public PointerSession? GetPointerSessionById(Guid Id)
        {
            return pointerSessionRepository.GetPointerSessionById(Id);
        }

        public PointerSession? GetPointerSessionByCode(string code)
        {
            return pointerSessionRepository.GetPointerSessionByCode(code);
        }
    }
}
