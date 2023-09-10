namespace DbC.Net.Utility;

public static class ExtensionMethods
{
   /// <summary>
   ///   Check if the supplied <paramref name="str"/> contains only alphanumeric
   ///   characters as defined by the <see cref="Char.IsLetterOrDigit(Char)"/>
   ///   method. A value that is <see langword="null"/> or 
   ///   <see cref="String.Empty"/> will return <see langword="true"/>.
   /// </summary>
   /// <param name="str">
   ///   The <see cref="String"/> to check.
   /// </param>
   /// <returns>
   ///   <see langword="true"/> if every character of <paramref name="str"/> is
   ///   alphanumeric; otherwise <see langword="false"/>.
   /// </returns>
   public static Boolean IsAlphaNumericOnly(this String str)
   {
      str ??= String.Empty;

      // Benchmarks showed that in this case foreach on the string is as 
      // performant or better than indexed for loop or using a span.
      foreach (var ch in str)
      {
         if (!Char.IsLetterOrDigit(ch))
         {
            return false;
         }
      }

      return true;
   }

   /// <summary>
   ///   Check if the supplied <paramref name="str"/> contains only radix-10
   ///   digit characters ('0' - '9'). A value that is <see langword="null"/> or 
   ///   <see cref="String.Empty"/> will return <see langword="true"/>.
   /// </summary>
   /// <param name="str">
   ///   The <see cref="String"/> to check.
   /// </param>
   /// <returns>
   ///   <see langword="true"/> if every character of <paramref name="str"/> is
   ///   a radix-10 digit character; otherwise <see langword="false"/>.
   /// </returns>
   public static Boolean IsDigitsOnly(this String str)
   {
      str ??= String.Empty;

      foreach (var ch in str)
      {
         if (!Char.IsDigit(ch))
         {
            return false;
         }
      }

      return true;
   }

   /// <summary>
   ///   Get the equivalent ASCII digit character for an integer between 0-9;
   /// </summary>
   /// <param name="num">
   ///   The <see cref="Int32"/> to convert.
   /// </param>
   /// <returns>
   ///   The equivalent ASCII digit character ('0'-'9').
   /// </returns>
   /// <remarks>
   ///   If <paramref name="num"/> is not between 0-9 then this method will
   ///   return an unexpected value
   /// </remarks>
   public static Char ToDigitChar(this Int32 num) => (Char)(CharConstants.DigitZero + num);

   /// <summary>
   ///   Get the integer equivalent of an ASCII digit character.
   /// </summary>
   /// <param name="ch">
   ///   The <see cref="Char"/> to convert.
   /// </param>
   /// <returns>
   ///   The integer equivalent of the ASCII character.
   /// </returns>
   /// <remarks>
   ///   If <paramref name="ch"/> is not an ASCII digit char (0-9) then this 
   ///   method will return a value that is not between 0-9.
   /// </remarks>
   public static Int32 ToIntegerDigit(this Char ch) => ch - CharConstants.DigitZero;
}
