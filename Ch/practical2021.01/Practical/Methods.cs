using System;

namespace Practical
{
    public static class Methods 
    {
        public static bool IsGoodString(string text, bool IsBlank=false)
        {
            return IsBlank ? text == "" || text.Trim() != string.Empty: text.Trim() != string.Empty;
        }

        public static bool IsGoodInt(object number, int from=0, int before=Int32.MaxValue)
        {
            try
            {
                return Convert.ToInt32(number) >= from && Convert.ToInt32(number)<=before;
            }
            catch
            {
                return false;
            }
        }
    }
}