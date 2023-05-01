namespace WorkPlaceProject.Web.Hubs
{
    public class ConnectionMap
    {
        private readonly Dictionary<string, UserDto> _ConnectionUserMap = new();

        public int Count => _ConnectionUserMap.Count;

            public void Add(string key, string group, string username)
        {
            if (_ConnectionUserMap.ContainsKey(key))
            {
                _ConnectionUserMap[key].Group = group;
                _ConnectionUserMap[key].Username = username;
            }
            else
            {
                _ConnectionUserMap.Add(key, new UserDto(group, username));
            }
        }

        public UserDto? Get(string key)
        {
            if (_ConnectionUserMap.ContainsKey(key))
            {
                return _ConnectionUserMap[key];
            }

            return null;
        }

        public void Remove(string key)
        {
            if (_ConnectionUserMap.ContainsKey(key))
            {
                _ConnectionUserMap.Remove(key);
            }
        }
    }
}