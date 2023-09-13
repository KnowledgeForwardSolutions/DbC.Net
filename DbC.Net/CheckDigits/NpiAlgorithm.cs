// Ignore Spelling: Npi

namespace DbC.Net.CheckDigits;

/// <summary>
///   Check digit algorithm for National Provider Identifier (NPI) numbers. The
///   NPI algorithm uses the Luhn algorithm but first prefixes the number with 
///   the string "80840" before calculating the check digit.
/// </summary>
/// <remarks>
///   See https://en.wikipedia.org/wiki/National_Provider_Identifier
/// </remarks>
public class NpiAlgorithm : ICheckDigitAlgorithm
{
   private const String _algorithmName = "NPI";

   // Limit access to only via StandardCheckDigitAlgorithms.
   internal NpiAlgorithm() { }

   /// <inheritdoc/>
   public String Name => _algorithmName;

   /// <inheritdoc/>
   /// <remarks>
   ///   Will return <see langword="false"/> for the following edge conditions:
   ///   <list type="bullet">
   ///      <item><paramref name="value"/> is <see langword="null"/></item>
   ///      <item><paramref name="value"/> is <see cref="String.Empty"/></item>
   ///      <item><paramref name="value"/> is less than 10 characters in length</item>
   ///      <item><paramref name="value"/> is greater than 10 characters in length</item>
   ///      <item><paramref name="value"/> contains a character that is not a digit (0-9)
   ///   </list>
   /// </remarks>
   public Boolean ValidateCheckDigit(String value)
   {
      if (String.IsNullOrEmpty(value))
      {
         return false;
      }

      var sum = 24;     // Pre-calculated total for "80840" prefix. 
      var oddCharacter = true;
      for (var index = value.Length - 2; index >= 0; index--)
      {
         var currentDigit = value![index].ToIntegerDigit();
         if (currentDigit < 0 || currentDigit > 9)
         {
            return false;
         }
         sum += oddCharacter
            ? currentDigit > 4 ? currentDigit * 2 - 9 : currentDigit * 2
            : currentDigit;
         oddCharacter = !oddCharacter;
      }
      var checkDigit = (10 - (sum % 10)) % 10;

      return value[^1] == checkDigit.ToDigitChar();
   }
}
