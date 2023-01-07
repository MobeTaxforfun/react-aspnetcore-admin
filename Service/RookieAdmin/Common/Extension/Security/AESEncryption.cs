using System.Security.Cryptography;
using System.Text;

namespace RookieAdmin.Common.Extension.Security
{
    public static class AESEncryption
    {
        private static string defaultkey = "H@ndS0m3Wu";
        private static string defaultIV = "SomeB@dH3r3";

        /// <summary>
        /// 自定 KEY AES 加密
        /// </summary>
        /// <param name="text"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string AesEncryptExtened(this string text, string key)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException("text");
            }

            return EncryptStringAes(text, key);
        }

        /// <summary>
        /// 自定 KEY AES 解密
        /// </summary>
        /// <param name="text"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string AesDecryptExtened(this string text, string key)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException("text");
            }

            return DecryptStringAes(text, key);
        }

        /// <summary>
        /// 使用預設 KEY AES 加密
        /// </summary>
        /// <param name="text"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string AesEncryptExtened(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException("text");
            }

            return EncryptStringAes(text, defaultkey);
        }

        /// <summary>
        /// 使用預設 KEY AES 解密
        /// </summary>
        /// <param name="text"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string AesDecryptExtened(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException("text");
            }

            return DecryptStringAes(text, defaultkey);
        }

        /// <summary>
        /// 基礎實現
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="Key"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        static string EncryptStringAes(string plainText, string Key)
        {
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");

            var keyIv = new AesKeyIV(Key);
            var aes = Aes.Create();
            aes.Key = keyIv.Key;
            aes.IV = keyIv.IV;

            var rawData = Encoding.UTF8.GetBytes(plainText);
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, aes.CreateEncryptor(aes.Key, aes.IV), CryptoStreamMode.Write))
                {
                    cs.Write(rawData, 0, rawData.Length);
                    cs.FlushFinalBlock();
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        /// <summary>
        /// 基礎實現
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="Key"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        static string DecryptStringAes(string cipherText, string Key)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");

            var keyIv = new AesKeyIV(Key);
            var aes = Aes.Create();
            aes.Key = keyIv.Key;
            aes.IV = keyIv.IV;
            var encData = Convert.FromBase64String(cipherText);
            byte[] buffer = new byte[8192];
            using (var ms = new MemoryStream(encData))
            {
                using (var cs = new CryptoStream(ms, aes.CreateDecryptor(aes.Key, aes.IV), CryptoStreamMode.Read))
                {
                    using (var sr = new StreamReader(cs))
                    {
                        using (var dec = new MemoryStream())
                        {
                            cs.CopyTo(dec);
                            return Encoding.UTF8.GetString(dec.ToArray());
                        }
                    }
                }
            }
        }

        private class AesKeyIV
        {
            public Byte[] Key = new Byte[16];
            public Byte[] IV = new Byte[16];
            public AesKeyIV(string strKey)
            {
                var sha = SHA256.Create();
                var hashKey = sha.ComputeHash(Encoding.ASCII.GetBytes(strKey));
                var hashIV = sha.ComputeHash(Encoding.ASCII.GetBytes(defaultIV));
                Array.Copy(hashKey, 0, Key, 0, 16);
                Array.Copy(hashIV, 16, IV, 0, 16);
            }
        }
    }
}
