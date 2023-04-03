### LessThan

LessThan requires that the value being checked be less than an upper bound. 
RequiresLessThan and EnsuresLessThan have several overloads that support 
IComparable<T> and IComparer<T> as well as an overload for String that accepts a 
StringComparison value that specifies how the comparison is performed.

**Method signatures:**
```C#
T RequiresLessThan<T>(this T value, T upperBound, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null]) where T : IComparable<T>

T RequiresLessThan<T>(this T value, T upperBound, IComparer<T> comparer, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null])

String RequiresLessThan(this String value, String upperBound, StringComparison comparisonType, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null])

T EnsuresLessThan<T>(this T value, T upperBound, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null]) where T : IComparable<T>

T EnsuresLessThan<T>(this T value, T upperBound, IComparer<T> comparer, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null])

String EnsuresLessThan(this String value, String upperBound, StringComparison comparisonType, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null])
```

The default message template for LessThan is "{RequirementType} {RequirementName} failed: {ValueExpression} must be less than {UpperBound}".
The default exception factory for RequiresLessThan is StandardExceptionFactories.ArgumentOutOfRangeExceptionFactory
and StandardExceptionFactories.PostconditionFailedExceptionFactory for 
EnsuresLessThan.

The data dictionary for exceptions thrown will contain entries for RequirementType,
RequirementName, Value, ValueExpression, UpperBound and UpperBoundExpression. The 
data dictionary for the String overloads will contain an additional entry for 
StringComparison.

**Examples:**
```C#
```

Implementation details for the Point examples:

[Point struct](/DbC.Net.TestAndExampleResources/Point.cs)

[PointDistanceFromOriginComparer](/DbC.Net.TestAndExampleResources/PointDistanceFromOriginComparer.cs)
