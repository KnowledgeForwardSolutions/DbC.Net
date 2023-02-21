namespace DbC.Net;

/// <summary>
///   Extension methods that implement NotEqual requirement for types that
///   implement <see cref="IEquatable{T}"/> or that use 
///   <see cref="IEqualityComparer{T}"/>
/// </summary>
public static class NotEqualExtensions
{
   /// <summary>
   ///   Value NotEqual postcondition. Confirm that <paramref name="value"/> is 
   ///   not equal to <paramref name="target"/> and throw an exception if it is.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="target">
   ///   The target that <paramref name="value"/> should not equal.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {Value} must not be equal to {Target}".
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
   public static T EnsuresNotEqual<T>(
      this T value,
      T target,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression("value")] String valueExpression = null!,
      [CallerArgumentExpression("target")] String targetExpression = null!) where T : IEquatable<T>
   {
      CheckNotEqual(
         value,
         target,
         RequirementType.Postcondition,
         messageTemplate,
         exceptionFactory,
         valueExpression,
         targetExpression);

      return value;
   }

   /// <summary>
   ///   Value NotEqual postcondition. Confirm that <paramref name="value"/> is 
   ///   not equal to <paramref name="target"/> and throw an exception if it is.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="target">
   ///   The target that <paramref name="value"/> should not equal.
   /// </param>
   /// <param name="comparer">
   ///   An <see cref="IEqualityComparer{T}"/> used to check for equality 
   ///   between <paramref name="value"/> and <paramref name="target"/>.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {Value} must not be equal to {Target}".
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
   ///   <paramref name="comparer"/> is <see langword="null"/>.
   /// </exception>
   public static T EnsuresNotEqual<T>(
      this T value,
      T target,
      IEqualityComparer<T> comparer,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression("value")] String valueExpression = null!,
      [CallerArgumentExpression("target")] String targetExpression = null!)
   {
      CheckNotEqual(
         value,
         target,
         comparer ?? throw new ArgumentNullException(nameof(comparer), Messages.ComparerIsNull),
         RequirementType.Postcondition,
         messageTemplate,
         exceptionFactory,
         valueExpression,
         targetExpression);

      return value;
   }

   /// <summary>
   ///   Value NotEqual postcondition. Confirm that the <see cref="String"/>
   ///   <paramref name="value"/> is not equal to the <see cref="String"/> 
   ///   <paramref name="target"/> and throw an exception if it is.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="target">
   ///   The target that <paramref name="value"/> should not equal.
   /// </param>
   /// <param name="comparisonType">
   ///   <see cref="StringComparison"/> enumeration value that specified how the
   ///   <paramref name="value"/> and <paramref name="target"/> strings are 
   ///   compared.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {Value} must not be equal to {Target}".
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
   public static String EnsuresNotEqual(
      this String value,
      String target,
      StringComparison comparisonType,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression("value")] String valueExpression = null!,
      [CallerArgumentExpression("target")] String targetExpression = null!)
   {
      CheckNotEqual(
         value,
         target,
         comparisonType,
         RequirementType.Postcondition,
         messageTemplate,
         exceptionFactory,
         valueExpression,
         targetExpression);

      return value;
   }

   /// <summary>
   ///   Value NotEqual precondition. Confirm that <paramref name="value"/> is 
   ///   not equal to <paramref name="target"/> and throw an exception if it is.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="target">
   ///   The target that <paramref name="value"/> should not equal.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {Value} must not be equal to {Target}".
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
   public static T RequiresNotEqual<T>(
      this T value,
      T target,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression("value")] String valueExpression = null!,
      [CallerArgumentExpression("target")] String targetExpression = null!) where T : IEquatable<T>
   {
      CheckNotEqual(
         value,
         target,
         RequirementType.Precondition,
         messageTemplate,
         exceptionFactory,
         valueExpression,
         targetExpression);

      return value;
   }

   /// <summary>
   ///   Value NotEqual precondition. Confirm that <paramref name="value"/> is 
   ///   not equal to <paramref name="target"/> and throw an exception if it is.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="target">
   ///   The target that <paramref name="value"/> should not equal.
   /// </param>
   /// <param name="comparer">
   ///   An <see cref="IEqualityComparer{T}"/> used to check for equality 
   ///   between <paramref name="value"/> and <paramref name="target"/>.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {Value} must not be equal to {Target}".
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
   ///   <paramref name="comparer"/> is <see langword="null"/>.
   /// </exception>
   public static T RequiresNotEqual<T>(
      this T value,
      T target,
      IEqualityComparer<T> comparer,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression("value")] String valueExpression = null!,
      [CallerArgumentExpression("target")] String targetExpression = null!)
   {
      CheckNotEqual(
         value,
         target,
         comparer ?? throw new ArgumentNullException(nameof(comparer), Messages.ComparerIsNull),
         RequirementType.Precondition,
         messageTemplate,
         exceptionFactory,
         valueExpression,
         targetExpression);

      return value;
   }

   /// <summary>
   ///   Value NotEqual precondition. Confirm that the <see cref="String"/>
   ///   <paramref name="value"/> is not equal to the <see cref="String"/> 
   ///   <paramref name="target"/> and throw an exception if it is.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="target">
   ///   The target that <paramref name="value"/> should not equal.
   /// </param>
   /// <param name="comparisonType">
   ///   <see cref="StringComparison"/> enumeration value that specified how the
   ///   <paramref name="value"/> and <paramref name="target"/> strings are 
   ///   compared.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {Value} must not be equal to {Target}".
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
   public static String RequiresNotEqual(
      this String value,
      String target,
      StringComparison comparisonType,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression("value")] String valueExpression = null!,
      [CallerArgumentExpression("target")] String targetExpression = null!)
   {
      CheckNotEqual(
         value,
         target,
         comparisonType,
         RequirementType.Precondition,
         messageTemplate,
         exceptionFactory,
         valueExpression,
         targetExpression);

      return value;
   }

   private static void CheckNotEqual<T>(
      T value,
      T target,
      RequirementType requirementType,
      String? messageTemplate,
      IExceptionFactory? exceptionFactory,
      String valueExpression,
      String targetExpression) where T : IEquatable<T>
   {
      if (ReferenceEquals(value, target) || (value is not null && value.Equals(target)))
      {
         messageTemplate ??= MessageTemplates.NotEqualTemplate;
         exceptionFactory ??= requirementType == RequirementType.Precondition
            ? StandardExceptionFactories.ArgumentExceptionFactory
            : StandardExceptionFactories.PostconditionFailedExceptionFactory;
         var data = GetDataDictionary(
            requirementType,
            value!,
            valueExpression,
            target!,
            targetExpression);

         throw exceptionFactory.CreateException(data, messageTemplate);
      }
   }

   private static void CheckNotEqual<T>(
      T value,
      T target,
      IEqualityComparer<T> comparer,
      RequirementType requirementType,
      String? messageTemplate,
      IExceptionFactory? exceptionFactory,
      String valueExpression,
      String targetExpression)
   {
      if (comparer.Equals(value, target))
      {
         messageTemplate ??= MessageTemplates.NotEqualTemplate;
         exceptionFactory ??= requirementType == RequirementType.Precondition
            ? StandardExceptionFactories.ArgumentExceptionFactory
            : StandardExceptionFactories.PostconditionFailedExceptionFactory;
         var data = GetDataDictionary(
            requirementType,
            value,
            valueExpression,
            target,
            targetExpression);

         throw exceptionFactory.CreateException(data, messageTemplate);
      }
   }

   private static void CheckNotEqual(
      String value,
      String target,
      StringComparison comparisonType,
      RequirementType requirementType,
      String? messageTemplate,
      IExceptionFactory? exceptionFactory,
      String valueExpression,
      String targetExpression)
   {
      if (ReferenceEquals(value, target) || (value is not null && value.Equals(target, comparisonType)))
      {
         messageTemplate ??= MessageTemplates.NotEqualTemplate;
         exceptionFactory ??= requirementType == RequirementType.Precondition
            ? StandardExceptionFactories.ArgumentExceptionFactory
            : StandardExceptionFactories.PostconditionFailedExceptionFactory;
         var data = GetDataDictionary(
            requirementType,
            value,
            valueExpression,
            target,
            targetExpression);
         data[DataNames.StringComparison] = comparisonType;

         throw exceptionFactory.CreateException(data, messageTemplate);
      }
   }

   private static Dictionary<String, Object> GetDataDictionary<T>(
      RequirementType requirementType,
      T value,
      String valueExpression,
      T target,
      String targetExpression)
      => new()
      {
         {  DataNames.RequirementType, requirementType },
         {  DataNames.RequirementName, RequirementNames.NotEqual },
         {  DataNames.Value, value! },
         {  DataNames.ValueExpression, valueExpression },
         {  DataNames.Target, target! },
         {  DataNames.TargetExpression, targetExpression }
      };
}
