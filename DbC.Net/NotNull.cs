using System.Runtime.CompilerServices;

using DbC.Net.ExceptionFactories;

namespace DbC.Net;

/// <summary>
///   Extension methods that implement NotNull requirement.
/// </summary>
public static class NotNull
{
   /// <summary>
   ///   Confirm that <paramref name="value"/> is not <see langword="null"/> and
   ///   throw an exception if it is null.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} may not be null".
   /// </param>
   /// <param name="exceptionFactory">
   ///   Optional. The <see cref="IExceptionFactory"/> used to create the
   ///   exception that is thrown if the <paramref name="value"/> is 
   ///   <see langword="null"/>. Defaults to 
   ///   <see cref="StandardExceptionFactories.ArgumentNullExceptionFactory"/>.
   /// </param>
   /// <param name="valueExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="value"/>. 
   /// </param>
   /// <returns>
   ///   The tested <paramref name="value"/> is returned unaltered to support 
   ///   chaining requirements.
   /// </returns>
   public static T RequiresNotNull<T>(
      this T value,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression("value")] String valueExpression = null!)
   {
      CheckNotNull(
         value!, 
         RequirementType.Precondition, 
         messageTemplate,
         exceptionFactory,
         valueExpression);

      return value;
   }

   private static void CheckNotNull<T>(
      T value,
      RequirementType requirementType,
      String? messageTemplate,
      IExceptionFactory? exceptionFactory,
      String valueExpression)
   {
      if (value is null)
      {
         messageTemplate ??= MessageTemplates.NotNullTemplate;
         exceptionFactory ??= StandardExceptionFactories.ArgumentNullExceptionFactory;
         var data = new Dictionary<String, Object>()
         {
            {  DataNames.RequirementType, requirementType },
            {  DataNames.RequirementName, nameof(NotNull) },
            {  DataNames.ValueExpression, valueExpression },
         };

         throw exceptionFactory.CreateException(data, messageTemplate);
      }
   }
}
