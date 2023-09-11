// Ignore Spelling: Luhn Barcode Aba

namespace DbC.Net.CheckDigits;

/// <summary>
///   Standard pre-implemented check digit algorithms.
/// </summary>
public static class StandardCheckDigitAlgorithms
{
   private static readonly Lazy<ICheckDigitAlgorithm> _abaRoutingNumberAlgorithm =
      new(() => new AbaRoutingNumberAlgorithm());

   private static readonly Lazy<ICheckDigitAlgorithm> _isbn10Algorithm =
      new(() => new Isbn10Algorithm());

   private static readonly Lazy<ICheckDigitAlgorithm> _luhnAlgorithm =
      new(() => new LuhnAlgorithm());

   private static readonly Lazy<ICheckDigitAlgorithm> _mod10BarcodeAlgorithm =
     new(() => new Mod10BarcodeAlgorithm());

   private static readonly Lazy<ICheckDigitAlgorithm> _vehicleIdentificationNumberAlgorithm =
     new(() => new VehicleIdentificationNumberAlgorithm());

   /// <summary>
   ///   ABA (American Bankers Association) routing number check digit algorithm.
   /// </summary>
   public static ICheckDigitAlgorithm AbaRoutingNumberAlgorithm => _abaRoutingNumberAlgorithm.Value;

   /// <summary>
   ///   ISBN-10 (International Standard Book Number) check digit algorithm.
   /// </summary>
   public static ICheckDigitAlgorithm Isbn10Algorithm => _isbn10Algorithm.Value;

   /// <summary>
   ///   Luhn check digit algorithm.
   /// </summary>
   public static ICheckDigitAlgorithm LuhnAlgorithm => _luhnAlgorithm.Value;

   /// <summary>
   ///   Modulus 10 barcode check digit algorithm.
   /// </summary>
   public static ICheckDigitAlgorithm Mod10BarcodeAlgorithm => _mod10BarcodeAlgorithm.Value;

   /// <summary>
   ///   Vehicle Identification Number (VIN) check digit algorithm.
   /// </summary>
   public static ICheckDigitAlgorithm VehicleIdentificationNumberAlgorithm => _vehicleIdentificationNumberAlgorithm.Value;
}
