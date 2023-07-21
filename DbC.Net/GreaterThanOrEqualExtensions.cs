namespace DbC.Net;

/// <summary>
///   Extension methods that implement GreaterThanOrEqualTo requirement for 
///   types that implement <see cref="IComparable{T}"/> or that use 
///   <see cref="IComparer{T}"/>.
/// </summary>
public static class GreaterThanOrEqualToExtensions
{
   private const String _requirementName = RequirementNames.GreaterThanOrEqual;

   /// <summary>
   ///   Value GreaterThanOrEqual postcondition. Confirm that 
   ///   <paramref name="value"/> is greater than or equal to 
   ///   <paramref name="lowerBound"/> and throw an exception if it is not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="lowerBound">
   ///   The lower bound that <paramref name="value"/> should be greater than or
   ///   equal to.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must be greater than or equal to {LowerBound}".
   /// </param>
   /// <param name="exceptionFactory">
   ///   Optional. The <see cref="IExceptionFactory"/> used to create the
   ///   exception that is thrown if the <paramref name="value"/> is not greater
   ///   than or equal to <paramref name="lowerBound"/>. Defaults to 
   ///   <see cref="StandardExceptionFactories.PostconditionFailedExceptionFactory"/>.
   /// </param>
   /// <param name="valueExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="value"/>. 
   /// </param>
   /// <param name="lowerBoundExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="lowerBound"/>. 
   /// </param>
   /// <returns>
   ///   The tested <paramref name="value"/> is returned unaltered to support 
   ///   chaining requirements.
   /// </returns>
   public static T EnsuresGreaterThanOrEqual<T>(
      this T value,
      T lowerBound,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!,
      [CallerArgumentExpression(nameof(lowerBound))] String lowerBoundExpression = null!) where T : IComparable<T>
   {
      CheckGreaterThanOrEqual(
         value,
         lowerBound,
         RequirementType.Postcondition,
         messageTemplate,
         exceptionFactory,
         valueExpression,
         lowerBoundExpression);

      return value;
   }

   /// <summary>
   ///   Value GreaterThanOrEqual postcondition. Confirm 
   ///   that <paramref name="value"/> is greater than or equal to
   ///   <paramref name="lowerBound"/> and throw an exception if it is not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="lowerBound">
   ///   The lower bound that <paramref name="value"/> should be greater than or
   ///   equal to.
   /// </param>
   /// <param name="comparer">
   ///   An <see cref="IComparer{T}"/> used to compare <paramref name="value"/> 
   ///   and <paramref name="lowerBound"/>.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must be greater than or equal to {LowerBound}".
   /// </param>
   /// <param name="exceptionFactory">
   ///   Optional. The <see cref="IExceptionFactory"/> used to create the
   ///   exception that is thrown if the <paramref name="value"/> is not greater
   ///   than or equal to <paramref name="lowerBound"/>. Defaults to
   ///   <see cref="StandardExceptionFactories.PostconditionFailedExceptionFactory"/>.
   /// </param>
   /// <param name="valueExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="value"/>. 
   /// </param>
   /// <param name="lowerBoundExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="lowerBound"/>. 
   /// </param>
   /// <returns>
   ///   The tested <paramref name="value"/> is returned unaltered to support 
   ///   chaining requirements.
   /// </returns>
   /// <exception cref="ArgumentNullException">
   ///   <paramref name="comparer"/> is <see langword="null"/>.
   /// </exception>
   public static T EnsuresGreaterThanOrEqual<T>(
      this T value,
      T lowerBound,
      IComparer<T> comparer,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!,
      [CallerArgumentExpression(nameof(lowerBound))] String lowerBoundExpression = null!)
   {
      CheckGreaterThanOrEqual(
         value,
         lowerBound,
         comparer ?? throw new ArgumentNullException(nameof(comparer), Messages.ComparerIsNull),
         RequirementType.Postcondition,
         messageTemplate,
         exceptionFactory,
         valueExpression,
         lowerBoundExpression);

      return value;
   }

   /// <summary>
   ///   Value GreaterThanOrEqual postcondition. Confirm that the 
   ///   <see cref="String"/> <paramref name="value"/> is greater than or equal
   ///   to the <see cref="String"/> <paramref name="lowerBound"/> and throw an 
   ///   exception if it is not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="lowerBound">
   ///   The lower bound that <paramref name="value"/> should be greater than or
   ///   equal to.
   /// </param>
   /// <param name="comparisonType">
   ///   <see cref="StringComparison"/> enumeration value that specifies how the
   ///   <paramref name="value"/> and <paramref name="lowerBound"/> strings are 
   ///   compared.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must be greater than or equal to {LowerBound}".
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
   /// <param name="lowerBoundExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="lowerBound"/>. 
   /// </param>
   /// <returns>
   ///   The tested <paramref name="value"/> is returned unaltered to support 
   ///   chaining requirements.
   /// </returns>
   public static String EnsuresGreaterThanOrEqual(
      this String value,
      String lowerBound,
      StringComparison comparisonType,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!,
      [CallerArgumentExpression(nameof(lowerBound))] String lowerBoundExpression = null!)
   {
      CheckGreaterThanOrEqual(
         value,
         lowerBound,
         comparisonType,
         RequirementType.Postcondition,
         messageTemplate,
         exceptionFactory,
         valueExpression,
         lowerBoundExpression);

      return value;
   }

   /// <summary>
   ///   Value GreaterThanOrEqual precondition. Confirm that 
   ///   <paramref name="value"/> is greater than or equal to 
   ///   <paramref name="lowerBound"/> and throw an exception if it is not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="lowerBound">
   ///   The lower bound that <paramref name="value"/> should be greater than or
   ///   equal to.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must be greater than or equal to {LowerBound}".
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
   /// <param name="lowerBoundExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="lowerBound"/>. 
   /// </param>
   /// <returns>
   ///   The tested <paramref name="value"/> is returned unaltered to support 
   ///   chaining requirements.
   /// </returns>
   public static T RequiresGreaterThanOrEqual<T>(
      this T value,
      T lowerBound,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!,
      [CallerArgumentExpression(nameof(lowerBound))] String lowerBoundExpression = null!) where T : IComparable<T>
   {
      CheckGreaterThanOrEqual(
         value,
         lowerBound,
         RequirementType.Precondition,
         messageTemplate,
         exceptionFactory,
         valueExpression,
         lowerBoundExpression);

      return value;
   }

   /// <summary>
   ///   Value GreaterThanOrEqual precondition. Confirm 
   ///   that <paramref name="value"/> is greater than or equal to
   ///   <paramref name="lowerBound"/> and throw an exception if it is not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="lowerBound">
   ///   The lower bound that <paramref name="value"/> should be greater than or
   ///   equal to.
   /// </param>
   /// <param name="comparer">
   ///   An <see cref="IComparer{T}"/> used to compare <paramref name="value"/> 
   ///   and <paramref name="lowerBound"/>.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must be greater than or equal to {LowerBound}".
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
   /// <param name="lowerBoundExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="lowerBound"/>. 
   /// </param>
   /// <returns>
   ///   The tested <paramref name="value"/> is returned unaltered to support 
   ///   chaining requirements.
   /// </returns>
   /// <exception cref="ArgumentNullException">
   ///   <paramref name="comparer"/> is <see langword="null"/>.
   /// </exception>
   public static T RequiresGreaterThanOrEqual<T>(
      this T value,
      T lowerBound,
      IComparer<T> comparer,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!,
      [CallerArgumentExpression(nameof(lowerBound))] String lowerBoundExpression = null!)
   {
      CheckGreaterThanOrEqual(
         value,
         lowerBound,
         comparer ?? throw new ArgumentNullException(nameof(comparer), Messages.ComparerIsNull),
         RequirementType.Precondition,
         messageTemplate,
         exceptionFactory,
         valueExpression,
         lowerBoundExpression);

      return value;
   }

   /// <summary>
   ///   Value GreaterThanOrEqual precondition. Confirm that the 
   ///   <see cref="String"/> <paramref name="value"/> is greater than or equal
   ///   to the <see cref="String"/> <paramref name="lowerBound"/> and throw an 
   ///   exception if it is not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="lowerBound">
   ///   The lower bound that <paramref name="value"/> should be greater than or
   ///   equal to.
   /// </param>
   /// <param name="comparisonType">
   ///   <see cref="StringComparison"/> enumeration value that specifies how the
   ///   <paramref name="value"/> and <paramref name="lowerBound"/> strings are 
   ///   compared.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must be greater than or equal to {LowerBound}".
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
   /// <param name="lowerBoundExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="lowerBound"/>. 
   /// </param>
   /// <returns>
   ///   The tested <paramref name="value"/> is returned unaltered to support 
   ///   chaining requirements.
   /// </returns>
   public static String RequiresGreaterThanOrEqual(
      this String value,
      String lowerBound,
      StringComparison comparisonType,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!,
      [CallerArgumentExpression(nameof(lowerBound))] String lowerBoundExpression = null!)
   {
      CheckGreaterThanOrEqual(
         value,
         lowerBound,
         comparisonType,
         RequirementType.Precondition,
         messageTemplate,
         exceptionFactory,
         valueExpression,
         lowerBoundExpression);

      return value;
   }

   private static void CheckGreaterThanOrEqual<T>(
      T value,
      T lowerBound,
      RequirementType requirementType,
      String? messageTemplate,
      IExceptionFactory? exceptionFactory,
      String valueExpression,
      String lowerBoundExpression) where T : IComparable<T>
   {
      if ((value is null && lowerBound is not null)
         || (value is not null && value.CompareTo(lowerBound) < 0))
      {
         messageTemplate ??= MessageTemplates.GreaterThanOrEqualTemplate;
         exceptionFactory ??= StandardExceptionFactories.ResolveArgumentOutOfRangeFactory(requirementType);
         var data = ExceptionDataBuilder.Create()
            .WithRequirement(requirementType, _requirementName)
            .WithValue(value!, valueExpression)
            .WithLowerBound(lowerBound!, lowerBoundExpression)
            .Build();

         throw exceptionFactory.CreateException(data, messageTemplate);
      }
   }

   private static void CheckGreaterThanOrEqual<T>(
      T value,
      T lowerBound,
      IComparer<T> comparer,
      RequirementType requirementType,
      String? messageTemplate,
      IExceptionFactory? exceptionFactory,
      String valueExpression,
      String lowerBoundExpression)
   {
      if (comparer.Compare(value, lowerBound) < 0)
      {
         messageTemplate ??= MessageTemplates.GreaterThanOrEqualTemplate;
         exceptionFactory ??= StandardExceptionFactories.ResolveArgumentOutOfRangeFactory(requirementType);
         var data = ExceptionDataBuilder.Create()
            .WithRequirement(requirementType, _requirementName)
            .WithValue(value!, valueExpression)
            .WithLowerBound(lowerBound!, lowerBoundExpression)
            .Build();

         throw exceptionFactory.CreateException(data, messageTemplate);
      }
   }

   private static void CheckGreaterThanOrEqual(
      String value,
      String lowerBound,
      StringComparison comparisonType,
      RequirementType requirementType,
      String? messageTemplate,
      IExceptionFactory? exceptionFactory,
      String valueExpression,
      String lowerBoundExpression)
   {
      if (String.Compare(value, lowerBound, comparisonType) < 0)
      {
         messageTemplate ??= MessageTemplates.GreaterThanOrEqualTemplate;
         exceptionFactory ??= StandardExceptionFactories.ResolveArgumentOutOfRangeFactory(requirementType);
         var data = ExceptionDataBuilder.Create()
            .WithRequirement(requirementType, _requirementName)
            .WithValue(value!, valueExpression)
            .WithLowerBound(lowerBound, lowerBoundExpression)
            .WithItem(DataNames.StringComparison, comparisonType)
            .Build();

         throw exceptionFactory.CreateException(data, messageTemplate);
      }
   }
}
