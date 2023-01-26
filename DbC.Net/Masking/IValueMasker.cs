namespace DbC.Net.Masking;

/// <summary>
///   Defines an object used to mask sensitive values.
/// </summary>
public interface IValueMasker
{
   /// <summary>
   ///   Mask the supplied <paramref name="value"/>.
   /// </summary>
   /// <param name="value">
   ///   The value to mask.
   /// </param>
   /// <returns>
   ///   A <see cref="String"/> representation of the <paramref name="value"/>
   ///   after masking.
   /// </returns>
   String MaskValue(Object value);
}
