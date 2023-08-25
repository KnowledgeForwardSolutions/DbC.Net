// Ignore Spelling: Luhn

namespace DbC.Net.CheckDigits;

/// <summary>
///   Standard pre-implemented check digit algorithms.
/// </summary>
public static class StandardCheckDigitAlgorithms
{
   private static readonly Lazy<ICheckDigitAlgorithm> _luhnAlgorithm =
      new(() => new LuhnAlgorithm());

   /// <summary>
   ///   Luhn check digit algorithm.
   /// </summary>
   public static ICheckDigitAlgorithm LuhnAlgorithm => _luhnAlgorithm.Value;
}
