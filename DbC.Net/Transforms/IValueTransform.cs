namespace DbC.Net.Transforms;

/// <summary>
///   Defines an object used to transform values for presentation.
/// </summary>
public interface IValueTransform
{
   /// <summary>
   ///   Transform the supplied <paramref name="value"/>.
   /// </summary>
   /// <param name="value">
   ///   The value to transform.
   /// </param>
   /// <returns>
   ///   The transformed value.
   /// </returns>
   Object TransformValue(Object value);
}
