namespace WorkPlaceProject.Application
{
    public static class SessionCodeGenerator
    {
        private static int CodeLength { get; } = 8;

        public static string Generate()
        {
            Random random = new();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, CodeLength)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static bool Validate(string code)
        {
            if (code is not null
                && code.Length == CodeLength)
            {
                return true;
            }

            return false;
        }
    }
}
