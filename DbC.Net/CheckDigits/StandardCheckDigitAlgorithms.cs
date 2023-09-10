// Ignore Spelling: Luhn Ean Barcode

namespace DbC.Net.CheckDigits;

/// <summary>
///   Standard pre-implemented check digit algorithms.
/// </summary>
public static class StandardCheckDigitAlgorithms
{
   private static readonly Lazy<ICheckDigitAlgorithm> _isbn10Algorithm =
      new(() => new Isbn10Algorithm());

   private static readonly Lazy<ICheckDigitAlgorithm> _luhnAlgorithm =
      new(() => new LuhnAlgorithm());

   private static readonly Lazy<ICheckDigitAlgorithm> _mod10BarcodeAlgorithm =
     new(() => new Mod10BarcodeAlgorithm());

   /// <summary>
   ///   ISBN-10 check digit algorithm.
   /// </summary>
   public static ICheckDigitAlgorithm Isbn10Algorithm => _isbn10Algorithm.Value;

   /// <summary>
   ///   Luhn check digit algorithm.
   /// </summary>
   public static ICheckDigitAlgorithm LuhnAlgorithm => _luhnAlgorithm.Value;

   /// <summary>
   ///   EAN-13 check digit algorithm.
   /// </summary>
   public static ICheckDigitAlgorithm Mod10BarcodeAlgorithm => _mod10BarcodeAlgorithm.Value;
}
