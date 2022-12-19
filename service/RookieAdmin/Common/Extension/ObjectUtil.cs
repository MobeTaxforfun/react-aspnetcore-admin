namespace RookieAdmin.Common.Extension
{
    public static class ObjectUtil
    {
        /// <summary>
        /// 利用 propName 反射物件中的參數
        /// </summary>
        /// <param name="src"></param>
        /// <param name="propName"></param>
        /// <returns></returns>
        public static object? GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName)?.GetValue(src, null);
        }
    }
}
