namespace DbC.Net;

/// <summary>
///   Extension methods that implement GreaterThan requirement for types that
///   implement <see cref="IComparable{T}"/> or that use 
///   <see cref="IComparer{T}"/>.
/// </summary>
public static class GreaterThanExtensions
{
   private const String _requirementName = RequirementNames.GreaterThan;

   /// <summary>
   ///   Value GreaterThan postcondition. Confirm that <paramref name="value"/>
   ///   is greater than <paramref name="lowerBound"/> and throw an exception if
   ///   it is not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="lowerBound">
   ///   The lower bound that <paramref name="value"/> should be greater than.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must be greater than {LowerBound}".
   /// </param>
   /// <param name="exceptionFactory">
   ///   Optional. The <see cref="IExceptionFactory"/> used to create the
   ///   exception that is thrown if the <paramref name="value"/> is not greater
   ///   than <paramref name="lowerBound"/>. Defaults to 
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
   public static T EnsuresGreaterThan<T>(
      this T value,
      T lowerBound,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!,
      [CallerArgumentExpression(nameof(lowerBound))] String lowerBoundExpression = null!) where T : IComparable<T>
   {
      CheckGreaterThan(
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
   ///   Value GreaterThan postcondition. Confirm that <paramref name="value"/>
   ///   is greater than <paramref name="lowerBound"/> and throw an exception if
   ///   it is not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="lowerBound">
   ///   The lower bound that <paramref name="value"/> should be greater than.
   /// </param>
   /// <param name="comparer">
   ///   An <see cref="IComparer{T}"/> used to compare <paramref name="value"/> 
   ///   and <paramref name="lowerBound"/>.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must be greater than {LowerBound}".
   /// </param>
   /// <param name="exceptionFactory">
   ///   Optional. The <see cref="IExceptionFactory"/> used to create the
   ///   exception that is thrown if the <paramref name="value"/> is not greater
   ///   than <paramref name="lowerBound"/>. Defaults to 
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
   public static T EnsuresGreaterThan<T>(
      this T value,
      T lowerBound,
      IComparer<T> comparer,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!,
      [CallerArgumentExpression(nameof(lowerBound))] String lowerBoundExpression = null!)
   {
      CheckGreaterThan(
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
   ///   Value GreaterThan postcondition. Confirm that the <see cref="String"/>
   ///   <paramref name="value"/> is greater than the <see cref="String"/> 
   ///   <paramref name="lowerBound"/> and throw an exception if it is not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="lowerBound">
   ///   The lower bound that <paramref name="value"/> should be greater than.
   /// </param>
   /// <param name="comparisonType">
   ///   <see cref="StringComparison"/> enumeration value that specified how the
   ///   <paramref name="value"/> and <paramref name="lowerBound"/> strings are 
   ///   compared.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must be greater than {LowerBound}".
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
   public static String EnsuresGreaterThan(
      this String value,
      String lowerBound,
      StringComparison comparisonType,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!,
      [CallerArgumentExpression(nameof(lowerBound))] String lowerBoundExpression = null!)
   {
      CheckGreaterThan(
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
   ///   Value GreaterThan precondition. Confirm that <paramref name="value"/>
   ///   is greater than <paramref name="lowerBound"/> and throw an exception if
   ///   it is not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="lowerBound">
   ///   The lower bound that <paramref name="value"/> should be greater than.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must be greater than {LowerBound}".
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
   public static T RequiresGreaterThan<T>(
      this T value,
      T lowerBound,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!,
      [CallerArgumentExpression(nameof(lowerBound))] String lowerBoundExpression = null!) where T : IComparable<T>
   {
      CheckGreaterThan(
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
   ///   Value GreaterThan precondition. Confirm that <paramref name="value"/>
   ///   is greater than <paramref name="lowerBound"/> and throw an exception if
   ///   it is not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="lowerBound">
   ///   The lower bound that <paramref name="value"/> should be greater than.
   /// </param>
   /// <param name="comparer">
   ///   An <see cref="IComparer{T}"/> used to compare <paramref name="value"/> 
   ///   and <paramref name="lowerBound"/>.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must be greater than {LowerBound}".
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
   public static T RequiresGreaterThan<T>(
      this T value,
      T lowerBound,
      IComparer<T> comparer,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!,
      [CallerArgumentExpression(nameof(lowerBound))] String lowerBoundExpression = null!)
   {
      CheckGreaterThan(
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
   ///   Value GreaterThan precondition. Confirm that the <see cref="String"/>
   ///   <paramref name="value"/> is greater than the <see cref="String"/> 
   ///   <paramref name="lowerBound"/> and throw an exception if it is not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="lowerBound">
   ///   The lower bound that <paramref name="value"/> should be greater than.
   /// </param>
   /// <param name="comparisonType">
   ///   <see cref="StringComparison"/> enumeration value that specified how the
   ///   <paramref name="value"/> and <paramref name="lowerBound"/> strings are 
   ///   compared.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must be greater than {LowerBound}".
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
   public static String RequiresGreaterThan(
      this String value,
      String lowerBound,
      StringComparison comparisonType,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!,
      [CallerArgumentExpression(nameof(lowerBound))] String lowerBoundExpression = null!)
   {
      CheckGreaterThan(
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

   private static void CheckGreaterThan<T>(
      T value,
      T lowerBound,
      RequirementType requirementType,
      String? messageTemplate,
      IExceptionFactory? exceptionFactory,
      String valueExpression,
      String lowerBoundExpression) where T : IComparable<T>
   {
      if (value is null || value!.CompareTo(lowerBound) <= 0)
      {
         messageTemplate ??= MessageTemplates.GreaterThanTemplate;
         exceptionFactory ??= StandardExceptionFactories.ResolveArgumentOutOfRangeFactory(requirementType);
         var data = ExceptionDataBuilder.Create()
            .WithRequirement(requirementType, _requirementName)
            .WithValue(value!, valueExpression)
            .WithLowerBound(lowerBound, lowerBoundExpression)
            .Build();

         throw exceptionFactory.CreateException(data, messageTemplate);
      }
   }

   private static void CheckGreaterThan<T>(
      T value,
      T lowerBound,
      IComparer<T> comparer,
      RequirementType requirementType,
      String? messageTemplate,
      IExceptionFactory? exceptionFactory,
      String valueExpression,
      String lowerBoundExpression)
   {
      if (comparer.Compare(value, lowerBound) <= 0)
      {
         messageTemplate ??= MessageTemplates.GreaterThanTemplate;
         exceptionFactory ??= StandardExceptionFactories.ResolveArgumentOutOfRangeFactory(requirementType);
         var data = ExceptionDataBuilder.Create()
            .WithRequirement(requirementType, _requirementName)
            .WithValue(value!, valueExpression)
            .WithLowerBound(lowerBound!, lowerBoundExpression)
            .Build();

         throw exceptionFactory.CreateException(data, messageTemplate);
      }
   }

   private static void CheckGreaterThan(
      String value,
      String lowerBound,
      StringComparison comparisonType,
      RequirementType requirementType,
      String? messageTemplate,
      IExceptionFactory? exceptionFactory,
      String valueExpression,
      String lowerBoundExpression)
   {
      if (String.Compare(value, lowerBound, comparisonType) <= 0)
      {
         messageTemplate ??= MessageTemplates.GreaterThanTemplate;
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
