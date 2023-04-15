namespace DbC.Net;

/// <summary>
///   Extension methods that implement LessThanOrEqual requirement for types that
///   implement <see cref="IComparable{T}"/> or that use 
///   <see cref="IComparer{T}"/>.
/// </summary>
public static class LessThanOrEqualExtensions
{
   private const String _requirementName = RequirementNames.LessThanOrEqual;

   /// <summary>
   ///   Value LessThanOrEqual postcondition. Confirm that <paramref name="value"/>
   ///   is less than or equal to <paramref name="upperBound"/> and throw an 
   ///   exception if it is not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="upperBound">
   ///   The upper bound that <paramref name="value"/> should not exceed.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must be less than or equal to {UpperBound}".
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
   /// <param name="upperBoundExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="upperBound"/>. 
   /// </param>
   /// <returns>
   ///   The tested <paramref name="value"/> is returned unaltered to support 
   ///   chaining requirements.
   /// </returns>
   public static T EnsuresLessThanOrEqual<T>(
      this T value,
      T upperBound,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!,
      [CallerArgumentExpression(nameof(upperBound))] String upperBoundExpression = null!) where T : IComparable<T>
   {
      CheckLessThanOrEqual(
         value,
         upperBound,
         RequirementType.Postcondition,
         messageTemplate,
         exceptionFactory,
         valueExpression,
         upperBoundExpression);

      return value;
   }

   /// <summary>
   ///   Value LessThanOrEqual postcondition. Confirm that <paramref name="value"/>
   ///   is less than or equal to <paramref name="upperBound"/> and throw an 
   ///   exception if it is not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="upperBound">
   ///   The upper bound that <paramref name="value"/> should not exceed.
   /// </param>
   /// <param name="comparer">
   ///   An <see cref="IComparer{T}"/> used to compare <paramref name="value"/> 
   ///   and <paramref name="upperBound"/>.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must be less than or equal to {UpperBound}".
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
   /// <param name="upperBoundExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="upperBound"/>. 
   /// </param>
   /// <returns>
   ///   The tested <paramref name="value"/> is returned unaltered to support 
   ///   chaining requirements.
   /// </returns>
   /// <exception cref="ArgumentNullException">
   ///   <paramref name="comparer"/> is <see langword="null"/>.
   /// </exception>
   public static T EnsuresLessThanOrEqual<T>(
      this T value,
      T upperBound,
      IComparer<T> comparer,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!,
      [CallerArgumentExpression(nameof(upperBound))] String upperBoundExpression = null!)
   {
      CheckLessThanOrEqual(
         value,
         upperBound,
         comparer ?? throw new ArgumentNullException(nameof(comparer), Messages.ComparerIsNull),
         RequirementType.Postcondition,
         messageTemplate,
         exceptionFactory,
         valueExpression,
         upperBoundExpression);

      return value;
   }

   /// <summary>
   ///   Value LessThanOrEqual postcondition. Confirm that the 
   ///   <see cref="String"/> <paramref name="value"/> is less than or equal
   ///   to the <see cref="String"/> <paramref name="upperBound"/> and throw an 
   ///   exception if it is not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="upperBound">
   ///   The upper bound that <paramref name="value"/> should not exceed.
   /// </param>
   /// <param name="comparisonType">
   ///   <see cref="StringComparison"/> enumeration value that specified how the
   ///   <paramref name="value"/> and <paramref name="upperBound"/> strings are 
   ///   compared.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must be less than or equal to {UpperBound}".
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
   /// <param name="upperBoundExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="upperBound"/>. 
   /// </param>
   /// <returns>
   ///   The tested <paramref name="value"/> is returned unaltered to support 
   ///   chaining requirements.
   /// </returns>
   public static String EnsuresLessThanOrEqual(
      this String value,
      String upperBound,
      StringComparison comparisonType,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!,
      [CallerArgumentExpression(nameof(upperBound))] String upperBoundExpression = null!)
   {
      CheckLessThanOrEqual(
         value,
         upperBound,
         comparisonType,
         RequirementType.Postcondition,
         messageTemplate,
         exceptionFactory,
         valueExpression,
         upperBoundExpression);

      return value;
   }

   /// <summary>
   ///   Value LessThanOrEqual precondition. Confirm that <paramref name="value"/>
   ///   is less than or equal to <paramref name="upperBound"/> and throw an 
   ///   exception if it is not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="upperBound">
   ///   The upper bound that <paramref name="value"/> should not exceed.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must be less than or equal to {UpperBound}".
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
   /// <param name="upperBoundExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="upperBound"/>. 
   /// </param>
   /// <returns>
   ///   The tested <paramref name="value"/> is returned unaltered to support 
   ///   chaining requirements.
   /// </returns>
   public static T RequiresLessThanOrEqual<T>(
      this T value,
      T upperBound,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!,
      [CallerArgumentExpression(nameof(upperBound))] String upperBoundExpression = null!) where T : IComparable<T>
   {
      CheckLessThanOrEqual(
         value,
         upperBound,
         RequirementType.Precondition,
         messageTemplate,
         exceptionFactory,
         valueExpression,
         upperBoundExpression);

      return value;
   }

   /// <summary>
   ///   Value LessThanOrEqual precondition. Confirm that <paramref name="value"/>
   ///   is less than or equal to <paramref name="upperBound"/> and throw an 
   ///   exception if it is not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="upperBound">
   ///   The upper bound that <paramref name="value"/> should not exceed.
   /// </param>
   /// <param name="comparer">
   ///   An <see cref="IComparer{T}"/> used to compare <paramref name="value"/> 
   ///   and <paramref name="upperBound"/>.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must be less than or equal to {UpperBound}".
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
   /// <param name="upperBoundExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="upperBound"/>. 
   /// </param>
   /// <returns>
   ///   The tested <paramref name="value"/> is returned unaltered to support 
   ///   chaining requirements.
   /// </returns>
   /// <exception cref="ArgumentNullException">
   ///   <paramref name="comparer"/> is <see langword="null"/>.
   /// </exception>
   public static T RequiresLessThanOrEqual<T>(
      this T value,
      T upperBound,
      IComparer<T> comparer,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!,
      [CallerArgumentExpression(nameof(upperBound))] String upperBoundExpression = null!)
   {
      CheckLessThanOrEqual(
         value,
         upperBound,
         comparer ?? throw new ArgumentNullException(nameof(comparer), Messages.ComparerIsNull),
         RequirementType.Precondition,
         messageTemplate,
         exceptionFactory,
         valueExpression,
         upperBoundExpression);

      return value;
   }

   /// <summary>
   ///   Value LessThanOrEqual precondition. Confirm that the 
   ///   <see cref="String"/> <paramref name="value"/> is less than or equal
   ///   to the <see cref="String"/> <paramref name="upperBound"/> and throw an 
   ///   exception if it is not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="upperBound">
   ///   The upper bound that <paramref name="value"/> should not exceed.
   /// </param>
   /// <param name="comparisonType">
   ///   <see cref="StringComparison"/> enumeration value that specified how the
   ///   <paramref name="value"/> and <paramref name="upperBound"/> strings are 
   ///   compared.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must be less than or equal to {UpperBound}".
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
   /// <param name="upperBoundExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="upperBound"/>. 
   /// </param>
   /// <returns>
   ///   The tested <paramref name="value"/> is returned unaltered to support 
   ///   chaining requirements.
   /// </returns>
   public static String RequiresLessThanOrEqual(
      this String value,
      String upperBound,
      StringComparison comparisonType,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!,
      [CallerArgumentExpression(nameof(upperBound))] String upperBoundExpression = null!)
   {
      CheckLessThanOrEqual(
         value,
         upperBound,
         comparisonType,
         RequirementType.Precondition,
         messageTemplate,
         exceptionFactory,
         valueExpression,
         upperBoundExpression);

      return value;
   }

   private static void CheckLessThanOrEqual<T>(
      T value,
      T upperBound,
      RequirementType requirementType,
      String? messageTemplate,
      IExceptionFactory? exceptionFactory,
      String valueExpression,
      String upperBoundExpression) where T : IComparable<T>
   {
      if ((value is null && upperBound is not null)
         || (value is not null && value.CompareTo(upperBound) > 0))
      {
         messageTemplate ??= MessageTemplates.LessThanOrEqualTemplate;
         exceptionFactory ??= StandardExceptionFactories.ResolveArgumentOutOfRangeFactory(requirementType);
         var data = ExceptionDataBuilder.Create()
            .WithRequirement(requirementType, _requirementName)
            .WithValue(value!, valueExpression)
            .WithUpperBound(upperBound!, upperBoundExpression)
            .Build();

         throw exceptionFactory.CreateException(data, messageTemplate);
      }
   }

   private static void CheckLessThanOrEqual<T>(
      T value,
      T upperBound,
      IComparer<T> comparer,
      RequirementType requirementType,
      String? messageTemplate,
      IExceptionFactory? exceptionFactory,
      String valueExpression,
      String upperBoundExpression)
   {
      if (comparer.Compare(value, upperBound) > 0)
      {
         messageTemplate ??= MessageTemplates.LessThanOrEqualTemplate;
         exceptionFactory ??= StandardExceptionFactories.ResolveArgumentOutOfRangeFactory(requirementType);
         var data = ExceptionDataBuilder.Create()
            .WithRequirement(requirementType, _requirementName)
            .WithValue(value!, valueExpression)
            .WithUpperBound(upperBound!, upperBoundExpression)
            .Build();

         throw exceptionFactory.CreateException(data, messageTemplate);
      }
   }

   private static void CheckLessThanOrEqual(
      String value,
      String upperBound,
      StringComparison comparisonType,
      RequirementType requirementType,
      String? messageTemplate,
      IExceptionFactory? exceptionFactory,
      String valueExpression,
      String upperBoundExpression)
   {
      if (String.Compare(value, upperBound, comparisonType) > 0)
      {
         messageTemplate ??= MessageTemplates.LessThanOrEqualTemplate;
         exceptionFactory ??= StandardExceptionFactories.ResolveArgumentOutOfRangeFactory(requirementType);
         var data = ExceptionDataBuilder.Create()
            .WithRequirement(requirementType, _requirementName)
            .WithValue(value!, valueExpression)
            .WithUpperBound(upperBound!, upperBoundExpression)
            .WithItem(DataNames.StringComparison, comparisonType)
            .Build();

         throw exceptionFactory.CreateException(data, messageTemplate);
      }
   }
}
