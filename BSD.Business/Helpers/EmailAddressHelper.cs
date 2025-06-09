using System.Text.RegularExpressions;

namespace BSD.Business.Helpers
{
    public static class EmailAddressHelper
    {
        static readonly Regex emailRegex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
        public static bool IsEmailAddress(string email)
        {
            return emailRegex.IsMatch(email);
        }
    }
}
