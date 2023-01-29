namespace DbC.Net.Transforms;

/// <summary>
///   Standard pre-defined value transforms.
/// </summary>
public static class StandardTransforms
{
   public const String PhiTransformValue = "PHI Sensitive Value";

   private static readonly Lazy<IValueTransform> _asteriskMaskTransform =
      new(() => new CharacterMaskDecorator(NullTransform));

   private static readonly Lazy<IValueTransform> _digitAsteriskMaskTransform =
      new(() => new DigitMaskDecorator(NullTransform));

   private static readonly Lazy<IValueTransform> _fixedLengthTransform =
      new(() => new FixedLengthDecorator(NullTransform));

   private static readonly Lazy<IValueTransform> _nullTransform =
      new(() => new NullTransform());

   private static readonly Lazy<IValueTransform> _phiSensitiveTransform =
      new(() => new ConstantTransform(PhiTransformValue));

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
   ///   Transform that converts a value to an string eight characters in length, 
   ///   by truncating values longer than eight characters padding shorter values 
   ///   with space characters (' ').
   /// </summary>
   public static IValueTransform FixedLengthTransform => _fixedLengthTransform.Value;

   /// <summary>
   ///   Transform that returns the original value unaltered.
   /// </summary>
   public static IValueTransform NullTransform => _nullTransform.Value;

   /// <summary>
   ///   Transform that always returns the constant string "PHI Sensitive Value".
   /// </summary>
   /// <remarks>
   ///   Used to mask PHI (Protected Health Information) from accidental exposure.
   /// </remarks>
   public static IValueTransform PhiSensitiveTransform => _phiSensitiveTransform.Value;
}
