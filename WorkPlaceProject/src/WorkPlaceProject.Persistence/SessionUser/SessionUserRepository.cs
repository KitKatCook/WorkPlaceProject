using StackExchange.Redis;
using System.Text.Json;
using WorkPlaceProject.Common.Persistence;
using WorkPlaceProject.Domain.SessionUser;

namespace WorkPlaceProject.Persistence.SessionUser
{
    public class SessionUserRepository : ISessionUserRepository
    {
        private readonly IConnectionMultiplexer Redis;

        public SessionUserRepository(IConnectionMultiplexer redis)
        {
            Redis = redis;
        }

        public bool CreateSessionUser(WorkPlaceProject.Domain.SessionUser.SessionUser sessionUser)
        {
            IDatabase database = Redis.GetDatabase();

            return database.SetAdd(RedisStrings.SetUser, JsonSerializer.Serialize(sessionUser));
        }

        public WorkPlaceProject.Domain.SessionUser.SessionUser? GetSessionUserById(Guid Id)
        {
            IDatabase database = Redis.GetDatabase();

            List<RedisValue> sessions = database.SetMembers(RedisStrings.SetUser).ToList();

            if (sessions is not null
                && sessions.Count > 0)
            {
                var result = sessions.Select(x => JsonSerializer.Deserialize<WorkPlaceProject.Domain.SessionUser.SessionUser>(x)).FirstOrDefault(x => x.AzureId == Id);
                return result;
            }
            return null;
        }
    }
}
