### Between

Between requires that the value being checked be greater than or
equal to a lower bound and less than or equal to an upper bound. RequiresBetween 
and EnsuresBetween have several overloads that support IComparable<T> and IComparer<T> 
as well as an overload for String that accepts a StringComparison value that 
specifies how the comparison is performed.

Note that the allowed values are inclusive of the lower an upper bounds (similar
to a SQL BETWEEN clause).

All RequiresBetween and EnsuresBetween overloads will throw an InvalidOperationException 
if the supplied lower bound is greater than the upper bound.

The IComparer<T> overload of RequiresBetween and EnsuresBetween will throw an
ArgumentNullException if the comparer parameter is null.

**Method signatures:**
```C#
T RequiresBetween<T>(this T value, T lowerBound, T upperBound, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null]) where T : IComparable<T>

T RequiresBetween<T>(this T value, T lowerBound, T upperBound, IComparer<T> comparer, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null])

String RequiresBetween(this String value, String lowerBound, String upperBound, StringComparison comparisonType, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null])

T EnsuresBetween<T>(this T value, T lowerBound, T upperBound, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null]) where T : IComparable<T>

T EnsuresBetween<T>(this T value, T lowerBound, T upperBound, IComparer<T> comparer, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null])

String EnsuresBetween(this String value, String lowerBound, String upperBound, StringComparison comparisonType, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null])
```

The default message template for Between is "{RequirementType} {RequirementName} failed: {ValueExpression} must be between {LowerBound} and {UpperBound} (inclusive)".
The default exception factory for RequiresBetween is StandardExceptionFactories.ArgumentOutOfRangeExceptionFactory
and StandardExceptionFactories.PostconditionFailedExceptionFactory for 
EnsuresBetween.

The data dictionary for exceptions thrown will contain entries for RequirementType,
RequirementName, Value, ValueExpression, LowerBound, LowerBoundExpression, UpperBound
and UpperBoundExpression. The data dictionary for the String overloads will 
contain an additional entry for StringComparison.

