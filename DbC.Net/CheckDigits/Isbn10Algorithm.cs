namespace DbC.Net.CheckDigits;

/// <summary>
///   ISBN-10 check digit algorithm. Assumes that the input string is 10
///   characters in length and does not contain any additional characters 
///   separating the group/publisher/title/check digit elements.
/// </summary>
/// <remarks>
///   See https://en.wikipedia.org/wiki/ISBN#ISBN-10_check_digits
/// </remarks>
public class Isbn10Algorithm : ICheckDigitAlgorithm
{
   private const String _algorithmName = "ISBN-10";
   private const Int32 _expectedLength = 10;

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
   ///      in any position other than an 'X' in the check digit position</item>
   ///   </list>
   /// </remarks>
   public Boolean ValidateCheckDigit(String value)
   {
      if (String.IsNullOrEmpty(value) || value.Length != _expectedLength)
      {
         return false;
      }

      var s = 0;
      var t = 0;
      for(var index = 0; index < 9; index++)
      {
         var currentDigit = value![index].ToIntegerDigit();
         if (currentDigit < 0 || currentDigit > 9)
         {
            return false;
         }
         t += currentDigit;
         s += t;
      }
      s += t;

      var mod = (11 - (s % 11)) % 11;
      var checkDigit = mod < 10 ? mod.ToDigitChar() : CharConstants.UpperCaseX;

      return value[^1] == checkDigit;
   }
}
