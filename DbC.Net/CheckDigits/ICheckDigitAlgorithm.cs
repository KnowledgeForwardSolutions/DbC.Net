namespace DbC.Net.CheckDigits;

/// <summary>
///   Defines the requirements for an object that implements a check digit
///   algorithm.
/// </summary>
/// <remarks>
///   A check digit is used to detect human transcription errors, such as single
///   mistyped digits or, depending on the algorithm, transposition errors
///   between two successive digits.
/// </remarks>
public interface ICheckDigitAlgorithm
{
   /// <summary>
   ///   The algorithm name.
   /// </summary>
   String Name { get; }

   /// <summary>
   ///   Determine if the check digit included in the <paramref name="value"/>
   ///   string is valid. If the check digit is not valid, (i.e. the check digit
   ///   included in the value does not match the check digit calculated by this
   ///   check digit algorithm) then the value contains a transcription error.
   /// </summary>
   /// <param name="value">
   ///   The value to test.
   /// </param>
   /// <returns>
   ///   <see langword="true"/> if the <paramref name="value"/>'s check digit
   ///   is valid; otherwise <see langword="false"/>.
   /// </returns>
   Boolean ValidateCheckDigit(String value);
}
