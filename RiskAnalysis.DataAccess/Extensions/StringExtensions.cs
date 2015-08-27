namespace RiskAnalysis.DataAccess.Extensions
{
    public static class StringExtensions
    {
        public static bool ToBool(this string val)
        {
            bool returnVal;
            bool.TryParse(val, out returnVal);
            return returnVal;
        }
    }
}
