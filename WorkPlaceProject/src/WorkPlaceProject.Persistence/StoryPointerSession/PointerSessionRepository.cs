using StackExchange.Redis;
using System.Text.Json;
using WorkPlaceProject.Common.Persistence;
using WorkPlaceProject.Domain.StoryPointerSession;

namespace WorkPlaceProject.Persistence.StoryPointerSession
{
    public class PointerSessionRepository : IPointerSessionRepository
    {
        private readonly IConnectionMultiplexer Redis;

        public PointerSessionRepository(IConnectionMultiplexer redis) 
        {
            Redis = redis;
        }

        public bool CreatePointerSession(PointerSession pointerSession)
        {
            IDatabase database = Redis.GetDatabase();

            //return database.StringSet(pointerSession.Id.ToString(), JsonSerializer.Serialize(pointerSession));

            return database.SetAdd(RedisStrings.SetSession, JsonSerializer.Serialize(pointerSession));
        }

        public PointerSession? GetPointerSessionById(Guid Id)
        {
            IDatabase database = Redis.GetDatabase();

            List<RedisValue> sessions = database.SetMembers(RedisStrings.SetSession).ToList();

            if (sessions is not null
                && sessions.Count > 0)
            {
                var result = sessions.Select(x => JsonSerializer.Deserialize<PointerSession>(x)).FirstOrDefault(x => x.Id == Id);
                return result;
            }
            return null;
        }

        public PointerSession? GetPointerSessionByCode(string code)
        {
            IDatabase database = Redis.GetDatabase();

            List<RedisValue> sessions = database.SetMembers(RedisStrings.SetSession).ToList();

            if (sessions is not null
                && sessions.Count > 0)
            {
                var result = sessions.Select(x => JsonSerializer.Deserialize<PointerSession>(x)).FirstOrDefault(x => x.SessionCode == code);
                return result;
            }

            return null;
        }
    }
}
