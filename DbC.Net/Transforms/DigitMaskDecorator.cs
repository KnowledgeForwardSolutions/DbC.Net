using System.Text.RegularExpressions;

namespace DbC.Net.Transforms;

/// <summary>
///   Decorator object that transforms a value by converting to a string and 
///   replacing all decimal digit characters (0-9) with a mask character.
/// </summary>
/// <remarks>
///   Example transforms with mask character '*':
/// 
///   "123-456-7890" => "***-***-****"
///   "1234 Ave. A" => "**** Ave. A"
///   99.9 => "**.*"
///   "password => "password"
///   null => ""
/// </remarks>
public sealed class DigitMaskDecorator : IValueTransform
{
   private readonly IValueTransform _baseTransform;

   public const Char DefaultMaskCharacter = '*';

   /// <summary>
   ///   Decorate a <paramref name="baseTransform"/> with a new 
   ///   <see cref="DigitMaskDecorator"/>.
   /// </summary>
   /// <param name="baseTransform">
   ///   The <see cref="IValueTransform"/> to decorate.
   /// </param>
   /// <param name="maskCharacter">
   ///   Optional. The character to display instead of digit characters.
   ///   Defaults to an asterisk ('*').
   /// </param>
   /// <exception cref="ArgumentNullException">
   ///   <paramref name="baseTransform"/> is <see langword="null"/>.
   /// </exception>
   /// <exception cref="ArgumentOutOfRangeException">
   ///   <paramref name="maskCharacter"/> is character null ('\0').
   /// </exception>
   public DigitMaskDecorator(
      IValueTransform baseTransform,
      Char maskCharacter = DefaultMaskCharacter)
   {
      _baseTransform = baseTransform
         ?? throw new ArgumentNullException(nameof(baseTransform), Messages.BaseTransformIsNull);
      if (maskCharacter == '\0')
      {
         throw new ArgumentOutOfRangeException(nameof(maskCharacter), Messages.MaskCharacterIsNull);
      }

      MaskCharacter = maskCharacter;
   }

   /// <summary>
   ///   The character to display instead of digit characters.
   /// </summary>
   public Char MaskCharacter { get; }

   /// <inheritdoc/>
   public Object TransformValue(Object value)
   {
      var str = _baseTransform.TransformValue(value)?.ToString() ?? String.Empty;
      
      return Regex.Replace(str, "[0-9]", MaskCharacter.ToString());
   }
}

