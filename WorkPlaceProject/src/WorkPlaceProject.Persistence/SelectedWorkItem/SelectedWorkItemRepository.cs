using StackExchange.Redis;
using System.Text.Json;
using WorkPlaceProject.Common.Persistence;
using WorkPlaceProject.Domain.SelectedWorkItem;

namespace WorkPlaceProject.Persistence.SessionUser
{
    public class SelectedWorkItemRepository : ISelectedWorkItemRepository
    {
        private readonly IConnectionMultiplexer Redis;

        public SelectedWorkItemRepository(IConnectionMultiplexer redis)
        {
            Redis = redis;
        }

        public bool CreateSelectedWorkItem(SelectedWorkItem selectedWorkItem)
        {
            IDatabase database = Redis.GetDatabase();

            _ = DeleteStoryPointSelectionByUserId(selectedWorkItem.SessionId);

            return database.SetAdd(RedisStrings.SelectedWorkItem, JsonSerializer.Serialize(selectedWorkItem));
        }

        public SelectedWorkItem? GetSelectedWorkItemBySessionId(Guid sessionId)
        {
            IDatabase database = Redis.GetDatabase();

            List<RedisValue> sessions = database.SetMembers(RedisStrings.SelectedWorkItem).ToList();

            if (sessions is not null
                && sessions.Count > 0)
            {
                var result = sessions.Select(x => JsonSerializer.Deserialize<SelectedWorkItem>(x)).FirstOrDefault(x => x.SessionId == sessionId);
                return result;
            }
            return null;
        }

        public bool DeleteStoryPointSelectionByUserId(Guid sessionId)
        {
            IDatabase database = Redis.GetDatabase();

            var existingSelection = GetSelectedWorkItemBySessionId(sessionId);

            if (existingSelection is not null)
            {
                return database.SetRemove(RedisStrings.SelectedWorkItem, JsonSerializer.Serialize(existingSelection));
            }
            return false;
        }
    }
}
