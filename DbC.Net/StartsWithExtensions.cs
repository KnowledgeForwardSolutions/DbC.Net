namespace DbC.Net;

/// <summary>
///   Extension methods that implement String StartsWith requirement.
/// </summary>
public static class StartsWithExtensions
{
   private const String _requirementName = RequirementNames.StartsWith;

   /// <summary>
   ///   String StartsWith postcondition. Confirm that the <see cref="String"/>
   ///   <paramref name="value"/> starts with the  <paramref name="target"/> 
   ///   substring and throw an exception if it does not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="target">
   ///   The target substring that <paramref name="value"/> should start with.
   /// </param>
   /// <param name="comparisonType">
   ///   Optional.  <see cref="StringComparison"/> enumeration value that 
   ///   specifies how the <paramref name="value"/> and <paramref name="target"/> 
   ///   strings are compared. Defaults to <see cref="StringComparison.Ordinal"/>.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {Value} must start with the substring "{Target}"".
   /// </param>
   /// <param name="exceptionFactory">
   ///   Optional. The <see cref="IExceptionFactory"/> used to create the
   ///   exception that is thrown if the <paramref name="value"/> is 
   ///   <see langword="null"/>. Defaults to 
   ///   <see cref="StandardExceptionFactories.PostconditionFailedExceptionFactory"/>.
   /// </param>
   /// <param name="valueExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="value"/>. 
   /// </param>
   /// <param name="targetExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="target"/>. 
   /// </param>
   /// <returns>
   ///   The tested <paramref name="value"/> is returned unaltered to support 
   ///   chaining requirements.
   /// </returns>
   /// <exception cref="ArgumentNullException">
   ///   <paramref name="target"/> is <see langword="null"/>.
   /// </exception>
   public static String EnsuresStartsWith(
      this String value,
      String target,
      StringComparison comparisonType = StringComparison.Ordinal,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression("value")] String valueExpression = null!,
      [CallerArgumentExpression("target")] String targetExpression = null!)
   {
      CheckStartsWith(
         value,
         target ?? throw new ArgumentNullException(nameof(target), Messages.TargetSubstringIsNull),
         comparisonType,
         RequirementType.Postcondition,
         messageTemplate,
         exceptionFactory,
         valueExpression,
         targetExpression);

      return value;
   }

   /// <summary>
   ///   String StartsWith precondition. Confirm that the <see cref="String"/>
   ///   <paramref name="value"/> starts with the  <paramref name="target"/> 
   ///   substring and throw an exception if it does not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="target">
   ///   The target substring that <paramref name="value"/> should start with.
   /// </param>
   /// <param name="comparisonType">
   ///   Optional.  <see cref="StringComparison"/> enumeration value that 
   ///   specifies how the <paramref name="value"/> and <paramref name="target"/> 
   ///   strings are compared. Defaults to <see cref="StringComparison.Ordinal"/>.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {Value} must start with the substring "{Target}"".
   /// </param>
   /// <param name="exceptionFactory">
   ///   Optional. The <see cref="IExceptionFactory"/> used to create the
   ///   exception that is thrown if the <paramref name="value"/> is 
   ///   <see langword="null"/>. Defaults to 
   ///   <see cref="StandardExceptionFactories.ArgumentExceptionFactory"/>.
   /// </param>
   /// <param name="valueExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="value"/>. 
   /// </param>
   /// <param name="targetExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="target"/>. 
   /// </param>
   /// <returns>
   ///   The tested <paramref name="value"/> is returned unaltered to support 
   ///   chaining requirements.
   /// </returns>
   /// <exception cref="ArgumentNullException">
   ///   <paramref name="target"/> is <see langword="null"/>.
   /// </exception>
   public static String RequiresStartsWith(
      this String value,
      String target,
      StringComparison comparisonType = StringComparison.Ordinal,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression("value")] String valueExpression = null!,
      [CallerArgumentExpression("target")] String targetExpression = null!)
   {
      CheckStartsWith(
         value,
         target ?? throw new ArgumentNullException(nameof(target), Messages.TargetSubstringIsNull),
         comparisonType,
         RequirementType.Precondition,
         messageTemplate,
         exceptionFactory,
         valueExpression,
         targetExpression);

      return value;
   }

   private static void CheckStartsWith(
      String value,
      String target,
      StringComparison comparisonType,
      RequirementType requirementType,
      String? messageTemplate,
      IExceptionFactory? exceptionFactory,
      String valueExpression,
      String targetExpression)
   {
      if (value is null || !value.StartsWith(target, comparisonType))
      {
         messageTemplate ??= MessageTemplates.StartsWithTemplate;
         exceptionFactory ??= StandardExceptionFactories.ResolveArgumentExceptionFactory(requirementType);
         var data = ExceptionDataBuilder.Create()
            .WithRequirement(requirementType, _requirementName)
            .WithValue(value!, valueExpression)
            .WithTarget(target, targetExpression)
            .WithItem(DataNames.StringComparison, comparisonType)
            .Build();

         throw exceptionFactory.CreateException(data, messageTemplate);
      }
   }
}
