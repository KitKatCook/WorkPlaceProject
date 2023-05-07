using StackExchange.Redis;
using System.Text.Json;
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

            database.StringSet(storyPointSelection.Id.ToString(), JsonSerializer.Serialize(storyPointSelection));

            return true;
        }

        public StoryPointSelection? GetStoryPointSelectionById(Guid Id)
        {
            IDatabase database = Redis.GetDatabase();

            string jsonResult = database.StringGet(Id.ToString());

            if (jsonResult is not null)
            {
                return JsonSerializer.Deserialize<StoryPointSelection>(jsonResult);
            }

            return null;
        }
    }
}
