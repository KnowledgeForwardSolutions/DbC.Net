namespace DbC.Net;

/// <summary>
///   Extension methods that implement String EndsWith requirement.
/// </summary>
public static class EndsWithExtensions
{
   private const String _requirementName = RequirementNames.EndsWith;

   /// <summary>
   ///   String EndsWith postcondition. Confirm that the <see cref="String"/>
   ///   <paramref name="value"/> ends with the  <paramref name="target"/> 
   ///   substring and throw an exception if it does not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="target">
   ///   The target substring that <paramref name="value"/> should end with.
   /// </param>
   /// <param name="comparisonType">
   ///   Optional.  <see cref="StringComparison"/> enumeration value that 
   ///   specifies how the <paramref name="value"/> and <paramref name="target"/> 
   ///   strings are compared. Defaults to <see cref="StringComparison.Ordinal"/>.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {Value} must end with the substring "{Target}"".
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
   public static String EnsuresEndsWith(
      this String value,
      String target,
      StringComparison comparisonType = StringComparison.Ordinal,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!,
      [CallerArgumentExpression(nameof(target))] String targetExpression = null!)
   {
      CheckEndsWith(
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
   ///   String EndsWith precondition. Confirm that the <see cref="String"/>
   ///   <paramref name="value"/> ends with the  <paramref name="target"/> 
   ///   substring and throw an exception if it does not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="target">
   ///   The target substring that <paramref name="value"/> should end with.
   /// </param>
   /// <param name="comparisonType">
   ///   Optional.  <see cref="StringComparison"/> enumeration value that 
   ///   specifies how the <paramref name="value"/> and <paramref name="target"/> 
   ///   strings are compared. Defaults to <see cref="StringComparison.Ordinal"/>.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {Value} must end with the substring "{Target}"".
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
   public static String RequiresEndsWith(
      this String value,
      String target,
      StringComparison comparisonType = StringComparison.Ordinal,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!,
      [CallerArgumentExpression(nameof(target))] String targetExpression = null!)
   {
      CheckEndsWith(
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

   private static void CheckEndsWith(
      String value,
      String target,
      StringComparison comparisonType,
      RequirementType requirementType,
      String? messageTemplate,
      IExceptionFactory? exceptionFactory,
      String valueExpression,
      String targetExpression)
   {
      if (value is null || !value.EndsWith(target, comparisonType))
      {
         messageTemplate ??= MessageTemplates.EndsWithTemplate;
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
