namespace DbC.Net.Masking;

/// <summary>
///   Masks a sensitive value by replacing each character with a mask character.
/// </summary>
public class CharacterMasker : IValueMasker
{
   private Char _maskCharacter;

   /// <summary>
   ///   The character to display instead of the actual character in a sensitive 
   ///   value.
   /// </summary>
   /// <exception cref="ArgumentOutOfRangeException">
   ///   Value is character null ('\0').
   /// </exception>
   public required Char MaskCharacter
   {
      get => _maskCharacter;
      init
      {
         if (value == '\0')
         {
            throw new ArgumentOutOfRangeException(nameof(value), Messages.MaskCharacterIsNull);
         }

         _maskCharacter = value;
      }
   }
   
   /// <inheritdoc/>
   public String MaskValue(Object value) 
      => new(MaskCharacter, (value?.ToString() ?? String.Empty).Length);
}
