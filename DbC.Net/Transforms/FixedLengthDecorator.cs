namespace DbC.Net.Transforms;

/// <summary>
///   Decorator object that transforms a value by converting to a string and 
///   truncating the string to a fixed length, padding the string if necessary
///   to reach the specified length.
/// </summary>
/// <remarks>
///   Example transforms with fixed length 8 and pad character ' ':
///   
///   "password" => "password"
///   "Really long value" => "Really l"
///   99 => "99      "
///   null => "        "
/// </remarks>
public sealed class FixedLengthDecorator : IValueTransform
{
   private readonly IValueTransform _baseTransform;

   public const Int32 DefaultLength = 8;
   public const Char DefaultPadCharacter = ' ';

   /// <summary>
   ///   Decorate a <paramref name="baseTransform"/> with a new 
   ///   <see cref="FixedLengthDecorator"/>.
   /// </summary>
   /// <param name="baseTransform">
   ///   The <see cref="IValueTransform"/> to decorate.
   /// </param>
   /// <param name="length">
   ///   Optional. The final fixed length of the value. Defaults to 8.
   /// </param>
   /// <param name="padCharacter">
   ///   Optional. The character used to pad the result out to the final length.
   ///   Defaults to ASCII space character (' ').
   /// </param>
   /// <exception cref="ArgumentNullException">
   ///   <paramref name="baseTransform"/> is <see langword="null"/>.
   /// </exception>
   /// <exception cref="ArgumentOutOfRangeException">
   ///   <paramref name="length"/> is less than one.
   ///   - or -
   ///   <paramref name="padCharacter"/> is character null ('\0').
   /// </exception>
   public FixedLengthDecorator(
      IValueTransform baseTransform,
      Int32 length = DefaultLength,
      Char padCharacter = DefaultPadCharacter)
   {
      _baseTransform = baseTransform
         ?? throw new ArgumentNullException(nameof(baseTransform), Messages.BaseTransformIsNull);

      if (length < 1)
      {
         throw new ArgumentOutOfRangeException(nameof(length), Messages.LengthIsLessThanOne);
      }
      Length = length;

      if (padCharacter == '\0')
      {
         throw new ArgumentOutOfRangeException(nameof(padCharacter), Messages.PadCharacterIsNull);
      }
      PadCharacter = padCharacter;
   }

   /// <summary>
   ///   The final fixed length of the value.
   /// </summary>
   public Int32 Length { get; }

   /// <summary>
   ///   The character used to pad the result out to the final length.
   /// </summary>
   public Char PadCharacter { get; }

   /// <inheritdoc/>
   public Object TransformValue(Object value)
      => ((_baseTransform.TransformValue(value)?.ToString() ?? String.Empty) + new String(PadCharacter, Length))[..Length];
}
