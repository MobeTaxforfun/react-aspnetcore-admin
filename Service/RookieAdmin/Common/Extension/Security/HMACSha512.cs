using System.Security.Cryptography;

namespace RookieAdmin.Common.Extension.Security
{
    public static class HMACSha512
    {
        private static string HMACSHA512WORD = "Despath#305yn50o&";
        public static string HMACSHA512(this string message)
        {
            return GenerateHmacSha512(message, HMACSHA512WORD);
        }

        private static string GenerateHmacSha512(string message, string key)
        {
            string result = "Error";
            try
            {
                //用微軟的System.Security.Cryptography，不相信微軟可以不要用...;
                var encoding = new System.Text.UTF8Encoding();
                byte[] keyByte = encoding.GetBytes(key);
                byte[] messageBytes = encoding.GetBytes(message);
                using (var hmacSHA512 = new HMACSHA512(keyByte))
                {
                    byte[] hashMessage = hmacSHA512.ComputeHash(messageBytes);
                    result = BitConverter.ToString(hashMessage).Replace("-", "").ToLower();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return result;
        }
    }
}
