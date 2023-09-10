namespace DbC.Net.CheckDigits;

public static class CheckDigitUtility
{
   public static Int32 GetIntegerDigit(this Char ch) => ch - '0';

   public static Char ToDigitChar(this Int32 num) => (Char)('0' + num);
}
