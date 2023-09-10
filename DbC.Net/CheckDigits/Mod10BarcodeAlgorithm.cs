// Ignore Spelling: Barcode

namespace DbC.Net.CheckDigits;

/// <summary>
///   Modulus 10 barcode check digit algorithm. Used by UPC (Universal Product
///   Code) IAN/EAN (International Article Number/European Article Number), 
///   ISBN-13 (International Standard Book Number), ISMN (International Standard 
///   Music Number), GTIN (Global Trade Item Number), SSCC (Serial Shipping
///   Container Code) and more.
/// </summary>
/// <remarks>
///   Only validates the check digit contained in the input string. Combine with
///   other checks (such as length) to ensure that the value is in the correct 
///   format for the particular barcode type.
/// </remarks>
public class Mod10BarcodeAlgorithm : ICheckDigitAlgorithm
{
   private const String _algorithmName = "Mod10Barcode";

   /// <inheritdoc/>
   public String Name => _algorithmName;

   /// <inheritdoc/>
   /// <remarks>
   ///   Will return <see langword="false"/> for the following edge conditions:
   ///   <list type="bullet">
   ///      <item><paramref name="value"/> is <see langword="null"/></item>
   ///      <item><paramref name="value"/> is <see cref="String.Empty"/></item>
   ///      <item><paramref name="value"/> contains a character that is not a digit (0-9)
   ///   </list>
   /// </remarks>
   public Boolean ValidateCheckDigit(String value) 
   {
      if (String.IsNullOrEmpty(value))
      {
         return false;
      }

      var oddTotal = 0;
      var evenTotal = 0;
      var oddCharacter = true;
      for (var index = value.Length - 2; index >= 0; index--)
      {
         var currentDigit = value[index].ToIntegerDigit();
         if (currentDigit < 0 || currentDigit > 9)
         {
            return false;
         }
         _ = oddCharacter
            ? oddTotal += currentDigit
            : evenTotal += currentDigit;
         oddCharacter = !oddCharacter;
      }
      var sum = (oddTotal * 3) + evenTotal;
      var checkDigit = (10 - (sum % 10)) % 10;

      return value[^1] == checkDigit.ToDigitChar();
   }
}
