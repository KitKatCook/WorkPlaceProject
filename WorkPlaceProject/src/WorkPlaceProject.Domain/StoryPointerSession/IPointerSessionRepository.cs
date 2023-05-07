namespace WorkPlaceProject.Domain.StoryPointerSession
{
    public interface IPointerSessionRepository
    {
        bool CreatePointerSession(PointerSession pointerSession);

        PointerSession? GetPointerSessionById(Guid Id);

        PointerSession? GetPointerSessionByCode(string code);
    }
}
