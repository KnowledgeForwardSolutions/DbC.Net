namespace DbC.Net.Transforms;

/// <summary>
///   Value transformer that always returns the same constant value. Can be used
///   to mask a sensitive value with a notification that the original value is
///   hidden from view. May also be used as the base for other value transform 
///   decorators.
/// </summary>
public sealed class ConstantTransform : IValueTransform
{
   /// <summary>
   ///   Initialize a new <see cref="ConstantTransform"/> with the supplied
   ///   <paramref name="constantValue"/>.
   /// </summary>
   /// <param name="constantValue">
   ///   The value that is always returned by this transform.
   /// </param>
   /// <exception cref="ArgumentNullException">
   ///   <paramref name="constantValue"/> is <see langword="null"/>.
   /// </exception>
   public ConstantTransform(Object constantValue) 
      => ConstantValue = constantValue ?? throw new ArgumentNullException(nameof(constantValue), Messages.ConstantValueIsNull);

    /// <summary>
    ///   The value that is always returned by this transform.
    /// </summary>
    public Object ConstantValue { get; }

   /// <inheritdoc/>
   public Object TransformValue(Object value) => ConstantValue;
}
