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
   private static readonly String[] _digits = new String[]{ "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

   /// <inheritdoc/>
   public String Name => _algorithmName;

   /// <inheritdoc/>
   /// <exception cref="ArgumentNullException">
   ///   <paramref name="value"/> is <see langword="null"/>.
   /// </exception>
   /// <exception cref="ArgumentException">
   ///   <paramref name="value"/> contains a non-digit (0-9) character.
   ///   - or -
   ///   <paramref name="value"/> is too short to calculate a valid check digit.
   /// </exception>
   public String GetCheckDigit(String value, Boolean includesCheckDigit = true)
   {
      _ = value ?? throw new ArgumentNullException(nameof(value), Messages.CheckDigitAlgorithmValueIsNull);
      var sum = 0;
      var evenCharacter = false;
      var index = value.Length - (includesCheckDigit ? 2 : 1); // Start at right-most character, excluding possible check digit
      while (index >= 0)
      {
         var digit = value[index] - _charZero;
         if (digit < 0 || digit > 9)
         {
            throw new ArgumentException(Messages.LuhnAlgorithmValueContainsNonDigit, nameof(value));
         }

         if (evenCharacter)
         {
            sum += digit;
         }
         else if (digit <= 4)
         {
            sum += digit * 2;
         }
         else
         {
            sum += digit * 2 - 9;
         }
         index--;
         evenCharacter = !evenCharacter;
      }

      if (sum == 0)
      {
         throw new ArgumentException(Messages.CheckDigitAlgorithmInvalidValueLength, nameof(value));
      }

      var checkDigit = 10 - (sum % 10);
      return _digits[checkDigit];
   }
}
