namespace DbC.Net.CheckDigits;

/// <summary>
///   Defines the requirements for an object that implements a check digit
///   algorithm.
/// </summary>
public interface ICheckDigitAlgorithm
{
   /// <summary>
   ///   The algorithm name.
   /// </summary>
   String Name { get; }

   /// <summary>
   ///   Calculate the check digit for the supplied <paramref name="value"/>.
   /// </summary>
   /// <param name="value">
   ///   The value for which the check digit should be calculated.
   /// </param>
   /// <returns>
   ///   A string containing the calculated check digit(s).
   /// </returns>
   String GetCheckDigit(ReadOnlySpan<Char> value);
}
