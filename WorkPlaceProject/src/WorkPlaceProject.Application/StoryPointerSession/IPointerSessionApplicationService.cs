using WorkPlaceProject.Domain.StoryPointerSession;

namespace WorkPlaceProject.Application.StoryPointerSession
{
    public interface IPointerSessionApplicationService
    {
        bool CreatePointerSession(PointerSessionAdto pointerSessionDdto);

        PointerSession? GetPointerSessionById(Guid Id);

        PointerSession? GetPointerSessionByCode(string code);
    }
}
