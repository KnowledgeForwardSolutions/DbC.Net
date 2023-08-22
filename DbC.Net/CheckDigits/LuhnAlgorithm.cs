// Ignore Spelling: Luhn

namespace DbC.Net.CheckDigits;

/// <summary>
///   Luhn check digit algorithm (i.e. modulus 10 algorithm).
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
   public String GetCheckDigit(ReadOnlySpan<Char> value)
   {
      if (value.Length == 0)
      {
         throw new ArgumentException(Messages.LuhnAlgorithmValueIsEmpty, nameof(value));
      }

      var sum = 0;
      for (var i = 0; i < value.Length; i++)
      {
         var digit = value[^(i + 1)] - _charZero;
         if (digit < 0 || digit > 9)
         {
            throw new ArgumentException(Messages.LuhnAlgorithmValueContainsNonDigit, nameof(value));
         }

         if (i % 2 == 1)
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
      }

      var checkDigit = 10 - (sum % 10);
      return _digits[checkDigit];
   }
}
