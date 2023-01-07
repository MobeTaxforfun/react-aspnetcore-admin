using System.Security.Cryptography;

namespace RookieAdmin.Common.Extension.Security
{
    //一個簡簡單單的HMAC-夏256，不可逆加密，但可以用彩虹表破解 :D
    public static class HMACSha256
    {
        private static string HMACSHA256WORD = "#305yn50o&";

        public static string HMACSHA256(this string message)
        {
            return GenerateHmacSha256(message, HMACSHA256WORD);
        }
        private static string GenerateHmacSha256(string message, string key)
        {
            string result = "Error";
            try
            {
                //用微軟的System.Security.Cryptography，不相信微軟可以不要用...;
                var encoding = new System.Text.UTF8Encoding();
                byte[] keyByte = encoding.GetBytes(key);
                byte[] messageBytes = encoding.GetBytes(message);
                using (var hmacSHA256 = new HMACSHA256(keyByte))
                {
                    byte[] hashMessage = hmacSHA256.ComputeHash(messageBytes);
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
