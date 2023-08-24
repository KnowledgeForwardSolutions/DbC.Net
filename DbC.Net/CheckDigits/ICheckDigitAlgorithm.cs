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
   /// <param name="includesCheckDigit">
   ///   Optional. <see langword="true"/> if the value includes an existing 
   ///   check digit that should be ignored while calculating the check digit; 
   ///   otherwise <see langword="false"/>. Defaults to <see langword="true"/>.
   /// </param>
   /// <returns>
   ///   A string containing the calculated check digit(s).
   /// </returns>
   String GetCheckDigit(String value, Boolean includesCheckDigit = true);

   /// <summary>
   ///   Validate that the check digit calculated for <paramref name="value"/>
   ///   matches the check digit included in the <paramref name="value"/>.
   /// </summary>
   /// <param name="value">
   ///   The value to validate.
   /// </param>
   /// <returns>
   ///   <see langword="true"/> if <paramref name="value"/> has a valid check 
   ///   digit; otherwise <see langword="false"/>.
   /// </returns>
   Boolean ValidateCheckDigit(String value);
}
