namespace DbC.Net;

/// <summary>
///   Extension methods that implement GreaterThan requirement for types that
///   implement <see cref="IComparable{T}"/> or that use 
///   <see cref="IComparer{T}"/>.
/// </summary>
public static class GreaterThanExtensions
{
   /// <summary>
   ///   Value GreaterThan postcondition. Confirm that <paramref name="value"/>
   ///   is greater than <paramref name="target"/> and throw an exception if it 
   ///   is not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="target">
   ///   The target that <paramref name="value"/> should be greater than.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must be greater than {Target}".
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
   public static T EnsuresGreaterThan<T>(
      this T value,
      T target,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!,
      [CallerArgumentExpression(nameof(target))] String targetExpression = null!) where T : IComparable<T>
   {
      CheckGreaterThan(
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
   ///   Value GreaterThan postcondition. Confirm that <paramref name="value"/>
   ///   is greater than <paramref name="target"/> and throw an exception if it 
   ///   is not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="target">
   ///   The target that <paramref name="value"/> should be greater than.
   /// </param>
   /// <param name="comparer">
   ///   An <see cref="IComparer{T}"/> used to compare <paramref name="value"/> 
   ///   and <paramref name="target"/>.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must be greater than {Target}".
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
   public static T EnsuresGreaterThan<T>(
      this T value,
      T target,
      IComparer<T> comparer,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!,
      [CallerArgumentExpression(nameof(target))] String targetExpression = null!)
   {
      CheckGreaterThan(
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
   ///   Value GreaterThan postcondition. Confirm that the <see cref="String"/>
   ///   <paramref name="value"/> is greater than the <see cref="String"/> 
   ///   <paramref name="target"/> and throw an exception if it is not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="target">
   ///   The target that <paramref name="value"/> should be greater than.
   /// </param>
   /// <param name="comparisonType">
   ///   <see cref="StringComparison"/> enumeration value that specified how the
   ///   <paramref name="value"/> and <paramref name="target"/> strings are 
   ///   compared.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must be greater than {Target}".
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
   public static String EnsuresGreaterThan(
      this String value,
      String target,
      StringComparison comparisonType,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!,
      [CallerArgumentExpression(nameof(target))] String targetExpression = null!)
   {
      CheckGreaterThan(
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
   ///   Value GreaterThan precondition. Confirm that <paramref name="value"/>
   ///   is greater than <paramref name="target"/> and throw an exception if it 
   ///   is not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="target">
   ///   The target that <paramref name="value"/> should be greater than.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must be greater than {Target}".
   /// </param>
   /// <param name="exceptionFactory">
   ///   Optional. The <see cref="IExceptionFactory"/> used to create the
   ///   exception that is thrown if the <paramref name="value"/> is 
   ///   <see langword="null"/>. Defaults to 
   ///   <see cref="StandardExceptionFactories.ArgumentOutOfRangeExceptionFactory"/>.
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
   public static T RequiresGreaterThan<T>(
      this T value,
      T target,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!,
      [CallerArgumentExpression(nameof(target))] String targetExpression = null!) where T : IComparable<T>
   {
      CheckGreaterThan(
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
   ///   Value GreaterThan precondition. Confirm that <paramref name="value"/>
   ///   is greater than <paramref name="target"/> and throw an exception if it 
   ///   is not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="target">
   ///   The target that <paramref name="value"/> should be greater than.
   /// </param>
   /// <param name="comparer">
   ///   An <see cref="IComparer{T}"/> used to compare <paramref name="value"/> 
   ///   and <paramref name="target"/>.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must be greater than {Target}".
   /// </param>
   /// <param name="exceptionFactory">
   ///   Optional. The <see cref="IExceptionFactory"/> used to create the
   ///   exception that is thrown if the <paramref name="value"/> is 
   ///   <see langword="null"/>. Defaults to 
   ///   <see cref="StandardExceptionFactories.ArgumentOutOfRangeExceptionFactory"/>.
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
   public static T RequiresGreaterThan<T>(
      this T value,
      T target,
      IComparer<T> comparer,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!,
      [CallerArgumentExpression(nameof(target))] String targetExpression = null!)
   {
      CheckGreaterThan(
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
   ///   Value GreaterThan precondition. Confirm that the <see cref="String"/>
   ///   <paramref name="value"/> is greater than the <see cref="String"/> 
   ///   <paramref name="target"/> and throw an exception if it is not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="target">
   ///   The target that <paramref name="value"/> should be greater than.
   /// </param>
   /// <param name="comparisonType">
   ///   <see cref="StringComparison"/> enumeration value that specified how the
   ///   <paramref name="value"/> and <paramref name="target"/> strings are 
   ///   compared.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must be greater than {Target}".
   /// </param>
   /// <param name="exceptionFactory">
   ///   Optional. The <see cref="IExceptionFactory"/> used to create the
   ///   exception that is thrown if the <paramref name="value"/> is 
   ///   <see langword="null"/>. Defaults to 
   ///   <see cref="StandardExceptionFactories.ArgumentOutOfRangeExceptionFactory"/>.
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
   public static String RequiresGreaterThan(
      this String value,
      String target,
      StringComparison comparisonType,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!,
      [CallerArgumentExpression(nameof(target))] String targetExpression = null!)
   {
      CheckGreaterThan(
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

   private static void CheckGreaterThan<T>(
      T value,
      T target,
      RequirementType requirementType,
      String? messageTemplate,
      IExceptionFactory? exceptionFactory,
      String valueExpression,
      String targetExpression) where T : IComparable<T>
   {
      if (value is null || value!.CompareTo(target) <= 0)
      {
         messageTemplate ??= MessageTemplates.GreaterThanTemplate;
         exceptionFactory ??= GetExceptionFactory(requirementType);
         var data = GetDataDictionary(
            requirementType,
            value!,
            valueExpression,
            target!,
            targetExpression);

         throw exceptionFactory.CreateException(data, messageTemplate);
      }
   }

   private static void CheckGreaterThan<T>(
      T value,
      T target,
      IComparer<T> comparer,
      RequirementType requirementType,
      String? messageTemplate,
      IExceptionFactory? exceptionFactory,
      String valueExpression,
      String targetExpression)
   {
      if (comparer.Compare(value, target) <= 0)
      {
         messageTemplate ??= MessageTemplates.GreaterThanTemplate;
         exceptionFactory ??= GetExceptionFactory(requirementType);
         var data = GetDataDictionary(
            requirementType,
            value!,
            valueExpression,
            target!,
            targetExpression);

         throw exceptionFactory.CreateException(data, messageTemplate);
      }
   }

   private static void CheckGreaterThan(
      String value,
      String target,
      StringComparison comparisonType,
      RequirementType requirementType,
      String? messageTemplate,
      IExceptionFactory? exceptionFactory,
      String valueExpression,
      String targetExpression)
   {
      if (String.Compare(value, target, comparisonType) <= 0)
      {
         messageTemplate ??= MessageTemplates.GreaterThanTemplate;
         exceptionFactory ??= GetExceptionFactory(requirementType);
         var data = GetDataDictionary(
            requirementType,
            value!,
            valueExpression,
            target!,
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
         {  DataNames.RequirementName, RequirementNames.GreaterThan },
         {  DataNames.Value, value! },
         {  DataNames.ValueExpression, valueExpression },
         {  DataNames.Target, target! },
         {  DataNames.TargetExpression, targetExpression }
      };

   private static IExceptionFactory GetExceptionFactory(RequirementType requirementType)
      => requirementType == RequirementType.Precondition
         ? StandardExceptionFactories.ArgumentOutOfRangeExceptionFactory
         : StandardExceptionFactories.PostconditionFailedExceptionFactory;
}
