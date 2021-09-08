using System.Text.RegularExpressions;

namespace PizzeriaLib
{
    public static class CharExpansion
    {
        public static bool ValidCharFound(string str)
        {
            foreach (var c in str)
            {
                string bfr = c.ToString();
                return Regex.IsMatch(bfr, @"[0-9,]");
            }
            return false;
        }
    }
}
