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

   /// <inheritdoc/>
   public String Name => _algorithmName;

   /// <inheritdoc/>
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
            return false;
         }
         sum += oddCharacter
            ? currentDigit > 4 ? currentDigit * 2 - 9 : currentDigit * 2
            : currentDigit;
         oddCharacter = !oddCharacter;
      }
      var checkDigit = '0' + (10 - (sum % 10)) % 10;

      return value[^1] == checkDigit;
   }
}
