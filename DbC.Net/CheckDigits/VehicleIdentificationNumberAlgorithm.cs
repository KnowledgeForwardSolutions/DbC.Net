using System.Diagnostics.CodeAnalysis;

namespace DbC.Net.CheckDigits;

/// <summary>
///   Vehicle Identification Number (VIN) check digit algorithm. Assumes that
///   the input string is 17 characters in length and does not contain any 
///   invalid characters.
/// </summary>
/// <remarks>
///   See https://en.wikipedia.org/wiki/Vehicle_identification_number#Check-digit_calculation
/// </remarks>
public class VehicleIdentificationNumberAlgorithm : ICheckDigitAlgorithm
{
   private const String _algorithmName = "VIN";
   private static readonly Int32[] _weights = new[] { 8, 7, 6, 5, 4, 3, 2, 10, 0, 9, 8, 7, 6, 5, 4, 3, 2 };
   private const Int32 _expectedLength = 17;
   private const Int32 _checkDigitPosition = 8;

   // Limit access to only via StandardCheckDigitAlgorithms.
   internal VehicleIdentificationNumberAlgorithm() { }

   /// <inheritdoc/>
   public String Name => _algorithmName;

   /// <inheritdoc/>
   /// <remarks>
   ///   Will return <see langword="false"/> for the following edge conditions:
   ///   <list type="bullet">
   ///      <item><paramref name="value"/> is <see langword="null"/></item>
   ///      <item><paramref name="value"/> is <see cref="String.Empty"/></item>
   ///      <item><paramref name="value"/> is less than 17 characters in length</item>
   ///      <item><paramref name="value"/> is greater than 17 characters in length</item>
   ///   </list>
   /// </remarks>
   public Boolean ValidateCheckDigit(String value)
   {
      if (String.IsNullOrEmpty(value) || value.Length != _expectedLength)
      {
         return false;
      }
      var sum = 0;
      for(var index = 0; index < _weights.Length; index++)
      {
         if (index == _checkDigitPosition)
         {
            continue;
         }

         var currentValue = value[index].TransliterateVinChar();
         if (currentValue == -1)
         {
            return false;
         }
         sum += currentValue * _weights[index];
      }
      var mod = sum % 11;
      var checkDigit = mod == 10 ? CharConstants.UpperCaseX : mod.ToDigitChar();

      return value[_checkDigitPosition] == checkDigit;
   }
}
