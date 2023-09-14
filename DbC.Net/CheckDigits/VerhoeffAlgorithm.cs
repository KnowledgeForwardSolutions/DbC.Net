// Ignore Spelling: Verhoeff

namespace DbC.Net.CheckDigits;

/// <summary>
///   Check digit algorithm published by Jacobus Verhoeff in 1969. Detects all
///   single-digit errors and all transpositions of two adjacent digits. This
///   implementation assumes that an included check digit is the right-most 
///   character in the input string.
/// </summary>
/// <remarks>
///   See https://en.wikipedia.org/wiki/Verhoeff_algorithm
/// </remarks>
public class VerhoeffAlgorithm : ICheckDigitAlgorithm
{
   private const String _algorithmName = "Verhoeff";

   private static readonly Int32[,] _multipicationTable = new Int32[10, 10]
   {
      { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
      { 1, 2, 3, 4, 0, 6, 7, 8, 9, 5 },
      { 2, 3, 4, 0, 1, 7, 8, 9, 5, 6 },
      { 3, 4, 0, 1, 2, 8, 9, 5, 6, 7 },
      { 4, 0, 1, 2, 3, 9, 5, 6, 7, 8 },
      { 5, 9, 8, 7, 6, 0, 4, 3, 2, 1 },
      { 6, 5, 9, 8, 7, 1, 0, 4, 3, 2 },
      { 7, 6, 5, 9, 8, 2, 1, 0, 4, 3 },
      { 8, 7, 6, 5, 9, 3, 2, 1, 0, 4 },
      { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }
   };
   private static readonly Int32[,] _permutationTable = new Int32[8, 10]
   {
      { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
      { 1, 5, 7, 6, 2, 8, 3, 0, 9, 4 },
      { 5, 8, 0, 3, 7, 9, 6, 1, 4, 2 },
      { 8, 9, 1, 6, 0, 4, 3, 5, 2, 7 },
      { 9, 4, 5, 3, 1, 2, 6, 8, 7, 0 },
      { 4, 2, 8, 6, 5, 7, 3, 9, 0, 1 },
      { 2, 7, 9, 3, 8, 0, 6, 4, 1, 5 },
      { 7, 0, 4, 6, 9, 1, 3, 2, 5, 8 }
   };

   // Limit access to only via StandardCheckDigitAlgorithms.
   internal VerhoeffAlgorithm() { }

   /// <inheritdoc/>
   public String Name => _algorithmName;

   /// <inheritdoc/>
   /// <remarks>
   ///   Will return <see langword="false"/> for the following edge conditions:
   ///   <list type="bullet">
   ///      <item><paramref name="value"/> is <see langword="null"/></item>
   ///      <item><paramref name="value"/> is <see cref="String.Empty"/></item>
   ///      <item><paramref name="value"/> has a length of less than 2</item>
   ///      <item><paramref name="value"/> contains a character that is not a digit (0-9)</item>
   ///   </list>
   /// </remarks>
   public Boolean ValidateCheckDigit(String value)
   {
      if (String.IsNullOrEmpty(value) || value.Length < 2)
      {
         return false;
      }

      var c = 0;
      var i = 0;
      for (var index = value.Length - 1; index >= 0; index--)
      {
         var n = value![index].ToIntegerDigit();
         if (n < 0 || n > 9)
         {
            return false;
         }

         var p = _permutationTable[i % 8, n];
         c = _multipicationTable[c, p];

         i++;
      }
      return c == 0;
   }
}
