using static RookieAdmin.Common.Permission.SystemCert;

namespace RookieAdmin.Common.Extension.Security
{
    public static class PwdSeason
    {
        public static string Salted(this string password, string salt)
        {
            return (password + salt).HMACSHA256();
        }
    }
}
