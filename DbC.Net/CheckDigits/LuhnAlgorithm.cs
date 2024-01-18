// Ignore Spelling: Luhn

namespace DbC.Net.CheckDigits;

/// <summary>
///   Luhn algorithm, commonly used for check digits for credit cards as well as
///   NPI (National Provider Identifier) numbers and IMEI (International Mobile 
///   Equipment Identity) numbers. The Luhn algorithm can detect all single
///   digit errors most but not all two digit transposition errors. This
///   implementation assumes that an included check digit is the right-most 
///   character in the input string.
/// </summary>
/// <remarks>
///   See https://en.wikipedia.org/wiki/Luhn_algorithm
/// </remarks>
public class LuhnAlgorithm : ICheckDigitAlgorithm
{
   private const String _algorithmName = "Luhn";

   private static readonly Int32[] _doubledValues = new Int32[] { 0, 2, 4, 6, 8, 1, 3, 5, 7, 9 };

   // Limit access to only via StandardCheckDigitAlgorithms.
   internal LuhnAlgorithm() { }

   /// <inheritdoc/>
   public String Name => _algorithmName;

   /// <inheritdoc/>
   /// <remarks>
   ///   Will return <see langword="false"/> for the following edge conditions:
   ///   <list type="bullet">
   ///      <item><paramref name="value"/> is <see langword="null"/></item>
   ///      <item><paramref name="value"/> is <see cref="String.Empty"/></item>
   ///      <item><paramref name="value"/> has length < 2</item>
   ///      <item><paramref name="value"/> contains a character that is not a digit (0-9)</item>
   ///   </list>
   /// </remarks>
   public Boolean ValidateCheckDigit(String value)
   {
      if (String.IsNullOrEmpty(value) || value.Length < 2)
      {
         return false;
      }

      var sum = 0;
      var shouldApplyDouble = true;
      for (var index = value.Length - 2; index >= 0; index--)
      {
         var currentDigit = value![index].ToIntegerDigit();
         if (currentDigit < 0 || currentDigit > 9)
         {
            return false;
         }
         sum += shouldApplyDouble ? _doubledValues[currentDigit] : currentDigit;
         shouldApplyDouble = !shouldApplyDouble;
      }
      var checkDigit = (10 - (sum % 10)) % 10;

      return value[^1] == checkDigit.ToDigitChar();
   }
}
