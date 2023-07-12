namespace DbC.Net.Utility;

public static class StringUtilities
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
   ///   a alphanumeric; otherwise <see langword="false"/>.
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
}
