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
      [CallerArgumentExpression("value")] String valueExpression = null!,
      [CallerArgumentExpression("target")] String targetExpression = null!) where T : IComparable<T>
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
      [CallerArgumentExpression("value")] String valueExpression = null!,
      [CallerArgumentExpression("target")] String targetExpression = null!) where T : IComparable<T>
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
         exceptionFactory ??= requirementType == RequirementType.Precondition
            ? StandardExceptionFactories.ArgumentOutOfRangeExceptionFactory
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
}
