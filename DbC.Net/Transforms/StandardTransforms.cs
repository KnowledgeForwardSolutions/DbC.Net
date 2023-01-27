namespace DbC.Net.Transforms;

/// <summary>
///   Standard pre-defined value transforms.
/// </summary>
public static class StandardTransforms
{
   private static readonly Lazy<NullTransform> _nullTransform =
      new(() => new NullTransform());

   private static readonly Lazy<CharacterMaskDecorator> _asteriskMaskTransform =
      new(() => new CharacterMaskDecorator(NullTransform, '*'));

   private static readonly Lazy<DigitMaskDecorator> _digitAsteriskMaskTransform =
      new(() => new DigitMaskDecorator(NullTransform, '*'));

   /// <summary>
   ///   Transform that converts a value to a string and then replaces all 
   ///   characters in the string with an asterisk character ('*').
   /// </summary>
   public static IValueTransform AsteriskMaskTransform => _asteriskMaskTransform.Value;

   /// <summary>
   ///   Transform that converts a value to a string and then replaces all 
   ///   decimal digit characters (0-9) in the string with an asterisk character 
   ///   ('*').
   /// </summary>
   public static IValueTransform DigitAsteriskMaskTransform => _digitAsteriskMaskTransform.Value;

   /// <summary>
   ///   Transform that returns the original value unaltered.
   /// </summary>
   public static IValueTransform NullTransform => _nullTransform.Value;
}
