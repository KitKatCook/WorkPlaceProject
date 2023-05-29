namespace WorkPlaceProject.Domain.StoryPointer.ValueTypes
{
    public class UserValueType
    {
        public UserValueType(int index, int value, string description, string username)
        {
            Index = index;
            Value = value;
            Description = description;
            Username = username;
        }

        public int Index { get; set; }

        public int Value { get; set; }

        public string Description { get; set; }
        public string Username { get; set; }
    }
}
