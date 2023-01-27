namespace DbC.Net.Transforms;

/// <summary>
///   Decorator object that transforms a value by converting to a string and 
///   replacing all characters with a mask character.
/// </summary>
/// <remarks>
///   Example transforms with mask character '*':
///   
///   "password" => "********"
///   99 => "**"
///   null => ""
/// </remarks>
public sealed class CharacterMaskDecorator : IValueTransform
{
   private readonly IValueTransform _baseTransform;
   private readonly Char _maskCharacter;

   /// <summary>
   ///   Decorate a <paramref name="baseTransform"/> with a new 
   ///   <see cref="CharacterMaskDecorator"/>.
   /// </summary>
   /// <param name="baseTransform">
   ///   The <see cref="IValueTransform"/> to decorate.
   /// </param>
   /// <param name="maskCharacter">
   ///   The character to display instead of the original character.
   /// </param>
   /// <exception cref="ArgumentNullException">
   ///   <paramref name="baseTransform"/> is <see langword="null"/>.
   /// </exception>
   /// <exception cref="ArgumentOutOfRangeException">
   ///   V<paramref name="maskCharacter"/> is character null ('\0').
   /// </exception>
   public CharacterMaskDecorator(
      IValueTransform baseTransform, 
      Char maskCharacter)
   {
      _baseTransform = baseTransform 
         ?? throw new ArgumentNullException(nameof(baseTransform), Messages.BaseTransformIsNull);
      if (maskCharacter == '\0')
      {
         throw new ArgumentOutOfRangeException(nameof(maskCharacter), Messages.MaskCharacterIsNull);
      }

      _maskCharacter = maskCharacter;
   }

   /// <inheritdoc/>
   public Object TransformValue(Object value)
      => new String(_maskCharacter, (_baseTransform.TransformValue(value)?.ToString() ?? String.Empty).Length);
}
