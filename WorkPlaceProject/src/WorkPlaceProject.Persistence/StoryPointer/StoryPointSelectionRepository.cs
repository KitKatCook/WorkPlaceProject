using StackExchange.Redis;
using System.Text.Json;
using WorkPlaceProject.Common.Persistence;
using WorkPlaceProject.Domain.StoryPointer;

namespace WorkPlaceProject.Persistence.StoryPointer
{
    public class StoryPointSelectionRepository : IStoryPointSelectionRepository
    {
        private readonly IConnectionMultiplexer Redis;

        public StoryPointSelectionRepository(IConnectionMultiplexer redis) 
        {
            Redis = redis;
        }

        public bool CreateStoryPointSelection(StoryPointSelection storyPointSelection)
        {
            IDatabase database = Redis.GetDatabase();

            //database.StringSet(storyPointSelection.Id.ToString(), JsonSerializer.Serialize(storyPointSelection));

            var existingSelection = GetStoryPointSelectionByUserId(storyPointSelection.UserId);

            if (existingSelection is not null)
            {
                database.SetRemove(RedisStrings.StoryPointSelection, JsonSerializer.Serialize(existingSelection));
            }

            return database.SetAdd(RedisStrings.StoryPointSelection, JsonSerializer.Serialize(storyPointSelection));
        }

        public StoryPointSelection? GetStoryPointSelectionById(Guid Id)
        {
            IDatabase database = Redis.GetDatabase();

            List<RedisValue> sessions = database.SetMembers(RedisStrings.StoryPointSelection).ToList();

            if (sessions is not null
                && sessions.Count > 0)
            {
                var result = sessions.Select(x => JsonSerializer.Deserialize<StoryPointSelection>(x)).FirstOrDefault(x => x.Id == Id);
                return result;
            }
            return null;
        }

        public StoryPointSelection? GetStoryPointSelectionByUserId(Guid UserId)
        {
            IDatabase database = Redis.GetDatabase();

            List<RedisValue> sessions = database.SetMembers(RedisStrings.StoryPointSelection).ToList();

            if (sessions is not null
                && sessions.Count > 0)
            {
                var result = sessions.Select(x => JsonSerializer.Deserialize<StoryPointSelection>(x)).FirstOrDefault(x => x.UserId == UserId);
                return result;
            }
            return null;
        }

        public IEnumerable<StoryPointSelection> GetStoryPointSelectionBySessionId(Guid SessionId)
        {
            IDatabase database = Redis.GetDatabase();

            List<RedisValue> sessions = database.SetMembers(RedisStrings.StoryPointSelection).ToList();

            if (sessions is not null
                && sessions.Count > 0)
            {
                var result = sessions.Select(x => JsonSerializer.Deserialize<StoryPointSelection>(x)).Where(x => x.SessionId == SessionId);
                return result;
            }
            return null;
        }

        public bool DeleteStoryPointSelectionByUserId(Guid UserId)
        {
            IDatabase database = Redis.GetDatabase();

            var existingSelection = GetStoryPointSelectionByUserId(UserId);

            if (existingSelection is not null)
            {
                return database.SetRemove(RedisStrings.StoryPointSelection, JsonSerializer.Serialize(existingSelection));
            }
            return false;
        }
    }
}
