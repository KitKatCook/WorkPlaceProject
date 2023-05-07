namespace WorkPlaceProject.Domain.StoryPointerSession
{
    public interface IPointerSessionDomainService 
    {
        bool CreatePointerSession(PointerSessionDdto pointerSessionDdto);

        PointerSession? GetPointerSessionById(Guid Id);

        PointerSession? GetPointerSessionByCode(string code);
    }
}
