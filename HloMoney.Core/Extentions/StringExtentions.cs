namespace HloMoney.Core.Extentions
{
    internal static class StringExtentions
    {
        internal static string AddParam(this string str, string key, string value)
        {
            return str.Contains("?") ? $"{str}&{key}={value}" : $"{str}?{key}={value}";
        }
    }
}
