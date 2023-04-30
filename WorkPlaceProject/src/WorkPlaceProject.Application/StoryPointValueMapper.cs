
namespace WorkPlaceProject.Application
{
    public class StoryPointValueMapper
    {
        public Dictionary<string, string> Values { get; protected set; } = new Dictionary<string, string>();

        public void AddValue(string key, string value)
        {
            if (Values.ContainsKey(key))
            {
                Values[key] = value;
            }
            else
            {
                Values.Add(key, value);
            }
        }

        public string GetValue(string key)
        {
            if (Values.ContainsKey(key))
            {
                return Values[key];
            }

            return "";
        }

        public void DeleteValue(string key)
        {
            if (Values.ContainsKey(key))
            {
                Values.Remove(key);
            }
        }
    }
}
