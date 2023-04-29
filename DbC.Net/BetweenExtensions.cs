namespace DbC.Net;

/// <summary>
///   Extension methods that implement Between requirement for types that
///   implement <see cref="IComparable{T}"/> or that use 
///   <see cref="IComparer{T}"/>.
/// </summary>
public static class BetweenExtensions
{
   private const String _requirementName = RequirementNames.Between;

   /// <summary>
   ///   Value Between postcondition. Confirm that <paramref name="value"/>
   ///   is greater than or equal to <paramref name="lowerBound"/> and less than 
   ///   or equal to <paramref name="upperBound"/> and throw an exception if
   ///   it is not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="lowerBound">
   ///   The lower bound that <paramref name="value"/> should be fall below.
   /// </param>
   /// <param name="upperBound">
   ///   The upper bound that <paramref name="value"/> should not exceed.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must be between {LowerBound} and {UpperBound} (inclusive)".
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
   /// <param name="upperBoundExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="upperBound"/>. 
   /// </param>
   /// <returns>
   ///   The tested <paramref name="value"/> is returned unaltered to support 
   ///   chaining requirements.
   /// </returns>
   /// <exception cref="InvalidOperationException">
   ///   Lower bound is greater than upper bound.
   /// </exception>
   public static T EnsuresBetween<T>(
      this T value,
      T lowerBound,
      T upperBound,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!,
      [CallerArgumentExpression(nameof(lowerBound))] String lowerBoundExpression = null!,
      [CallerArgumentExpression(nameof(upperBound))] String upperBoundExpression = null!) where T : IComparable<T>
   {
      CheckNormalizedBounds(lowerBound, upperBound);
      CheckBetween(
         value,
         lowerBound,
         upperBound,
         RequirementType.Postcondition,
         messageTemplate,
         exceptionFactory,
         valueExpression,
         lowerBoundExpression,
         upperBoundExpression);

      return value;
   }

   /// <summary>
   ///   Value Between postcondition. Confirm that <paramref name="value"/>
   ///   is greater than or equal to <paramref name="lowerBound"/> and less than 
   ///   or equal to <paramref name="upperBound"/> and throw an exception if
   ///   it is not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="lowerBound">
   ///   The lower bound that <paramref name="value"/> should be fall below.
   /// </param>
   /// <param name="upperBound">
   ///   The upper bound that <paramref name="value"/> should not exceed.
   /// </param>
   /// <param name="comparer">
   ///   An <see cref="IComparer{T}"/> used to compare <paramref name="value"/> 
   ///   and <paramref name="lowerBound"/> and <paramref name="upperBound"/>.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must be between {LowerBound} and {UpperBound} (inclusive)".
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
   /// <param name="upperBoundExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="upperBound"/>. 
   /// </param>
   /// <returns>
   ///   The tested <paramref name="value"/> is returned unaltered to support 
   ///   chaining requirements.
   /// </returns>
   /// <exception cref="InvalidOperationException">
   ///   Lower bound is greater than upper bound.
   /// </exception>
   /// <exception cref="ArgumentNullException">
   ///   <paramref name="comparer"/> is <see langword="null"/>.
   /// </exception>
   public static T EnsuresBetween<T>(
      this T value,
      T lowerBound,
      T upperBound,
      IComparer<T> comparer,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!,
      [CallerArgumentExpression(nameof(lowerBound))] String lowerBoundExpression = null!,
      [CallerArgumentExpression(nameof(upperBound))] String upperBoundExpression = null!)
   {
      CheckNormalizedBounds(
         lowerBound,
         upperBound,
         comparer ?? throw new ArgumentNullException(nameof(comparer), Messages.ComparerIsNull));
      CheckBetween(
         value,
         lowerBound,
         upperBound,
         comparer,
         RequirementType.Postcondition,
         messageTemplate,
         exceptionFactory,
         valueExpression,
         lowerBoundExpression,
         upperBoundExpression);

      return value;
   }

   /// <summary>
   ///   Value Between precondition. Confirm that <paramref name="value"/>
   ///   is greater than or equal to <paramref name="lowerBound"/> and less than 
   ///   or equal to <paramref name="upperBound"/> and throw an exception if
   ///   it is not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="lowerBound">
   ///   The lower bound that <paramref name="value"/> should be fall below.
   /// </param>
   /// <param name="upperBound">
   ///   The upper bound that <paramref name="value"/> should not exceed.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must be between {LowerBound} and {UpperBound} (inclusive)".
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
   /// <param name="upperBoundExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="upperBound"/>. 
   /// </param>
   /// <returns>
   ///   The tested <paramref name="value"/> is returned unaltered to support 
   ///   chaining requirements.
   /// </returns>
   /// <exception cref="InvalidOperationException">
   ///   Lower bound is greater than upper bound.
   /// </exception>
   public static T RequiresBetween<T>(
      this T value,
      T lowerBound,
      T upperBound,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!,
      [CallerArgumentExpression(nameof(lowerBound))] String lowerBoundExpression = null!,
      [CallerArgumentExpression(nameof(upperBound))] String upperBoundExpression = null!) where T : IComparable<T>
   {
      CheckNormalizedBounds(lowerBound, upperBound);
      CheckBetween(
         value,
         lowerBound,
         upperBound,
         RequirementType.Precondition,
         messageTemplate,
         exceptionFactory,
         valueExpression,
         lowerBoundExpression,
         upperBoundExpression);

      return value;
   }

   /// <summary>
   ///   Value Between precondition. Confirm that <paramref name="value"/>
   ///   is greater than or equal to <paramref name="lowerBound"/> and less than 
   ///   or equal to <paramref name="upperBound"/> and throw an exception if
   ///   it is not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="lowerBound">
   ///   The lower bound that <paramref name="value"/> should be fall below.
   /// </param>
   /// <param name="upperBound">
   ///   The upper bound that <paramref name="value"/> should not exceed.
   /// </param>
   /// <param name="comparer">
   ///   An <see cref="IComparer{T}"/> used to compare <paramref name="value"/> 
   ///   and <paramref name="lowerBound"/> and <paramref name="upperBound"/>.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {ValueExpression} must be between {LowerBound} and {UpperBound} (inclusive)".
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
   /// <param name="upperBoundExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="upperBound"/>. 
   /// </param>
   /// <returns>
   ///   The tested <paramref name="value"/> is returned unaltered to support 
   ///   chaining requirements.
   /// </returns>
   /// <exception cref="InvalidOperationException">
   ///   Lower bound is greater than upper bound.
   /// </exception>
   /// <exception cref="ArgumentNullException">
   ///   <paramref name="comparer"/> is <see langword="null"/>.
   /// </exception>
   public static T RequiresBetween<T>(
      this T value,
      T lowerBound,
      T upperBound,
      IComparer<T> comparer,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!,
      [CallerArgumentExpression(nameof(lowerBound))] String lowerBoundExpression = null!,
      [CallerArgumentExpression(nameof(upperBound))] String upperBoundExpression = null!)
   {
      CheckNormalizedBounds(
         lowerBound, 
         upperBound, 
         comparer ?? throw new ArgumentNullException(nameof(comparer), Messages.ComparerIsNull));
      CheckBetween(
         value,
         lowerBound,
         upperBound,
         comparer,
         RequirementType.Precondition,
         messageTemplate,
         exceptionFactory,
         valueExpression,
         lowerBoundExpression,
         upperBoundExpression);

      return value;
   }

   private static void CheckBetween<T>(
      T value,
      T lowerBound,
      T upperBound,
      RequirementType requirementType,
      String? messageTemplate,
      IExceptionFactory? exceptionFactory,
      String valueExpression,
      String lowerBoundExpression,
      String upperBoundExpression) where T : IComparable<T>
   {
      if ((value is null && lowerBound is not null)
         ||(value is not null && (value!.CompareTo(lowerBound) < 0 || value.CompareTo(upperBound) > 0))) 
      {
         messageTemplate ??= MessageTemplates.BetweenTemplate;
         exceptionFactory ??= StandardExceptionFactories.ResolveArgumentOutOfRangeFactory(requirementType);
         var data = ExceptionDataBuilder.Create()
            .WithRequirement(requirementType, _requirementName)
            .WithValue(value!, valueExpression)
            .WithLowerBound(lowerBound!, lowerBoundExpression)
            .WithUpperBound(upperBound!, upperBoundExpression)
            .Build();

         throw exceptionFactory.CreateException(data, messageTemplate);
      }
   }

   private static void CheckBetween<T>(
      T value,
      T lowerBound,
      T upperBound,
      IComparer<T> comparer,
      RequirementType requirementType,
      String? messageTemplate,
      IExceptionFactory? exceptionFactory,
      String valueExpression,
      String lowerBoundExpression,
      String upperBoundExpression)
   {
      if (comparer.Compare(value, lowerBound) < 0 || comparer.Compare(value, upperBound) > 0)
      {
         messageTemplate ??= MessageTemplates.BetweenTemplate;
         exceptionFactory ??= StandardExceptionFactories.ResolveArgumentOutOfRangeFactory(requirementType);
         var data = ExceptionDataBuilder.Create()
            .WithRequirement(requirementType, _requirementName)
            .WithValue(value!, valueExpression)
            .WithLowerBound(lowerBound!, lowerBoundExpression)
            .WithUpperBound(upperBound!, upperBoundExpression)
            .Build();

         throw exceptionFactory.CreateException(data, messageTemplate);
      }
   }

   private static void CheckNormalizedBounds<T>(T lowerBound, T upperBound) where T : IComparable<T>
   {
      // Lower bound must be less than or equal to upper bound.
      if (lowerBound is not null && lowerBound.CompareTo(upperBound) > 0)
      {
         throw new InvalidOperationException(Messages.BetweenBoundsNotNormalized);
      }
   }

   private static void CheckNormalizedBounds<T>(T lowerBound, T upperBound, IComparer<T> comparer)
   {
      // Lower bound must be less than or equal to upper bound.
      if (comparer.Compare(lowerBound, upperBound) > 0)
      {
         throw new InvalidOperationException(Messages.BetweenBoundsNotNormalized);
      }
   }
}
