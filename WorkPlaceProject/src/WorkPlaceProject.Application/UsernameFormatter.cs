namespace WorkPlaceProject.Application
{
    public static class UsernameFormatter
    {
        public static string Format(string emailAddress)
        {
            emailAddress = emailAddress[..emailAddress.IndexOf("@")].Replace(".", " ");
            return string.Concat(
                        emailAddress[0].ToString().ToUpper(), 
                        emailAddress.AsSpan(1, emailAddress.IndexOf(" ")),
                        emailAddress[emailAddress.IndexOf(" ") + 1].ToString().ToUpper(), 
                        emailAddress.AsSpan(emailAddress.IndexOf(" ") + 2));
        }
    }
}
