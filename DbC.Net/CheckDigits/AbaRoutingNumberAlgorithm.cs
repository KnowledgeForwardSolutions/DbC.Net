// Ignore Spelling: Aba

namespace DbC.Net.CheckDigits;

/// <summary>
///   ABA (American Bankers Association) routing number check digit algorithm.
///   Assumes that the input string is 9 characters in length and does not 
///   contain any non-digit characters.
/// </summary>
/// <remarks>
///   See https://en.wikipedia.org/wiki/ABA_routing_transit_number#Check_digit
/// </remarks>
public class AbaRoutingNumberAlgorithm : ICheckDigitAlgorithm
{
   private const String _algorithmName = "ABA";
   private const Int32 _expectedLength = 9;

   // Limit access to only via StandardCheckDigitAlgorithms.
   internal AbaRoutingNumberAlgorithm() { }

   /// <inheritdoc/>
   public String Name => _algorithmName;

   /// <inheritdoc/>
   /// <remarks>
   ///   Will return <see langword="false"/> for the following edge conditions:
   ///   <list type="bullet">
   ///      <item><paramref name="value"/> is <see langword="null"/></item>
   ///      <item><paramref name="value"/> is <see cref="String.Empty"/></item>
   ///      <item><paramref name="value"/> is less than 9 characters in length</item>
   ///      <item><paramref name="value"/> is greater than 9 characters in length</item>
   ///      <item><paramref name="value"/> contains a character that is not a digit (0-9)</item>
   ///   </list>
   /// </remarks>
   public Boolean ValidateCheckDigit(String value)
   {
      if (String.IsNullOrEmpty(value) || value.Length != _expectedLength)
      {
         return false;
      }

      var threes = 0;
      var sevens = 0;
      var ones = 0;

      for(var index = 0; index < value.Length; index++)
      {
         var currentDigit = value[index].ToIntegerDigit();
         if (currentDigit < 0 || currentDigit > 9)
         {
            return false;
         }
         var bucket = index % 3;
         _ = bucket == 0
            ? threes += currentDigit
            : bucket == 1
               ? sevens += currentDigit
               : ones += currentDigit;
      }
      var sum = (threes * 3) + (sevens * 7) + ones;

      return sum % 10 == 0;
   }
}
