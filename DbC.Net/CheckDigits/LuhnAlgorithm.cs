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

   // Pre-calculated values to use when summing odd position characters.
   private static readonly Int32[] _oddValues = new Int32[] { 0, 2, 4, 6, 8, 1, 3, 5, 7, 9 };

   /// <inheritdoc/>
   public String Name => _algorithmName;

   /// <inheritdoc/>
   /// <exception cref="ArgumentException">
   ///   <paramref name="value"/> contains a non-digit (0-9) character.
   /// </exception>
   public Boolean ValidateCheckDigit(String value)
   {
      if (String.IsNullOrEmpty(value))
      {
         return false;
      }

      var sum = 0;
      var oddCharacter = true;
      for (var index = value.Length - 2; index >= 0; index--)
      {
         var currentDigit = value![index] - '0';
         if (currentDigit < 0 || currentDigit > 9)
         {
            throw new ArgumentException(Messages.LuhnAlgorithmValueContainsNonDigit, nameof(value));
         }
         sum += oddCharacter ? _oddValues[currentDigit] : currentDigit;
         oddCharacter = !oddCharacter;
      }
      var checkDigit = (10 - (sum % 10)) % 10;
      var checkDigitCharacter = (Char)('0' + checkDigit);

      return value[^1] == checkDigitCharacter;
   }
}
