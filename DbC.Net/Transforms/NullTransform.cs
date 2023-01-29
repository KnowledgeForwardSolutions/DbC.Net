namespace DbC.Net.Transforms;

/// <summary>
///   Value transformer that does nothing but return the original value
///   value unaltered. Used as the base for other value transform decorators.
/// </summary>
public sealed class NullTransform : IValueTransform
{
   /// <inheritdoc/>
   public Object TransformValue(Object value) => value;
}
