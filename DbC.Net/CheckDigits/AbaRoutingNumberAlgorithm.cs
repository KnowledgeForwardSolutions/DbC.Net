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

   public String Name => _algorithmName;

   public Boolean ValidateCheckDigit(String value)
   {
      if (String.IsNullOrEmpty(value) || value.Length != 9)
      {
         return false;
      }

      var threes = 0;
      var sevens = 0;
      var ones = 0;

      for(var index = 0; index < value.Length; index++)
      {
         var currentDigit = value[index].GetIntegerDigit();
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

//#pragma warning disable CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).
//         _ = (index % 3) switch
//         {
//            0 => threes += currentDigit,
//            1 => sevens += currentDigit,
//            2 => ones += currentDigit,
//         };
//#pragma warning restore CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).
      }
      var sum = (threes * 3) + (sevens * 7) + ones;

      return sum % 10 == 0;
   }
}
