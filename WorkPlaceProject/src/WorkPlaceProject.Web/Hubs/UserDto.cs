namespace WorkPlaceProject.Web.Hubs
{
    public class UserDto
    {
        public UserDto(string group, string username)
        {
            Username = username;
            Group = group;  
        }

        public string Username { get; set; }
        public string Group { get; set; }
    }
}
