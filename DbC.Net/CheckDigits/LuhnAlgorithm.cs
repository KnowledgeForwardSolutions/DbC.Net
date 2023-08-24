// Ignore Spelling: Luhn

namespace DbC.Net.CheckDigits;

/// <summary>
///   Luhn algorithm, commonly used for check digits for credit cards as well as
///   NPI (National Provider Identifier) numbers and IMEI (International Mobile 
///   Equipment Identity) numbers. Assumes that an included check digit is the
///   right-most character in the input string.
/// </summary>
/// <remarks>
///   See https://en.wikipedia.org/wiki/Luhn_algorithm
/// </remarks>
public class LuhnAlgorithm : ICheckDigitAlgorithm
{
   private const String _algorithmName = "Luhn";
   private const Char _charZero = '0';

   // Pre-calculated values to use when summing odd position characters.
   private static readonly Int32[] _oddValues = new Int32[] { 0, 2, 4, 6, 8, 1, 3, 5, 7, 9 };

   // Resulting check digit values. Note only indices 1-10 are used.
   private static readonly String[] _checkDigits = new String[] { "", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

   /// <inheritdoc/>
   public String Name => _algorithmName;

   /// <inheritdoc/>
   /// <remarks>
   ///   A <paramref name="value"/> that is <see langword="null"/> or is empty
   ///   (excluding a possible included check digit) will return "0".
   /// </remarks>
   /// <exception cref="ArgumentException">
   ///   <paramref name="value"/> contains a non-digit (0-9) character.
   /// </exception>
   public String GetCheckDigit(String value, Boolean includesCheckDigit = true)
   {
      var sum = 0;
      var oddCharacter = true;
      var index = (value?.Length ?? 0) - (includesCheckDigit ? 2 : 1); // Start at right-most character, excluding possible check digit
      while (index >= 0)
      {
         var currentDigit = value![index] - _charZero;
         if (currentDigit < 0 || currentDigit > 9)
         {
            throw new ArgumentException(Messages.LuhnAlgorithmValueContainsNonDigit, nameof(value));
         }
         sum += oddCharacter ? _oddValues[currentDigit] : currentDigit;
         index--;
         oddCharacter = !oddCharacter;
      }

      var mod10Value = 10 - (sum % 10);
      return _checkDigits[mod10Value];
   }

   public Boolean ValidateCheckDigit(String value) => throw new NotImplementedException();
}
