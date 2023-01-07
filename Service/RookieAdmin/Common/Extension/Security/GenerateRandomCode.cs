using System.Text;

namespace RookieAdmin.Common.Extension.Security
{
    /// <summary>
    /// 取得隨機數字和英文(加鹽或驗證碼...等等使用)
    /// </summary>
    public static class GenerateRandomCode
    {
        private static readonly char[] Constant = new[]
       {
            '0','1','2','3','4',
            '5','6','7','8','9',
            'a','b','c','d','e',
            'f','g','h','i','j',
            'k','l','m','n','o',
            'p','q','r','s','t',
            'u','v','w','x','y',
            'z'
        };

        private static readonly char[] ConstantNumber = new[]
        {
            '0','1','2','3','4',
            '5','6','7','8','9'
        };

        public static readonly Random Random = new Random();

        /// <summary>
        /// 隨機產生字串
        /// </summary>
        /// <param name="length">長度</param>
        /// <param name="isNumberOnly">是否為數字</param>
        /// <returns></returns>
        public static string GetCode(int length, bool isNumberOnly = false)
        {
            char[] array;
            if (isNumberOnly)
            {
                array = ConstantNumber;
            }
            else
            {
                array = Constant;
            }
            var stringBuilder = new StringBuilder(length);
            for (var i = 0; i < length; i++)
            {
                stringBuilder.Append(array[Random.Next(array.Length)]);
            }
            return stringBuilder.ToString();
        }
    }
}
