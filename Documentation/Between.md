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
T RequiresBetween<T>(this T value, T lowerBound, T upperBound, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? lowerBoundExpression = null], [String? upperBoundExpression = null]) where T : IComparable<T>

T RequiresBetween<T>(this T value, T lowerBound, T upperBound, IComparer<T> comparer, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? lowerBoundExpression = null], [String? upperBoundExpression = null])

String RequiresBetween(this String value, String lowerBound, String upperBound, StringComparison comparisonType, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? lowerBoundExpression = null], [String? upperBoundExpression = null])

T EnsuresBetween<T>(this T value, T lowerBound, T upperBound, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? lowerBoundExpression = null], [String? upperBoundExpression = null]) where T : IComparable<T>

T EnsuresBetween<T>(this T value, T lowerBound, T upperBound, IComparer<T> comparer, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? lowerBoundExpression = null], [String? upperBoundExpression = null])

String EnsuresBetween(this String value, String lowerBound, String upperBound, StringComparison comparisonType, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? lowerBoundExpression = null], [String? upperBoundExpression = null])
```

The default message template for Between is "{RequirementType} {RequirementName} failed: {ValueExpression} must be between {LowerBound} and {UpperBound} (inclusive)".
The default exception factory for RequiresBetween is StandardExceptionFactories.ArgumentOutOfRangeExceptionFactory
and StandardExceptionFactories.PostconditionFailedExceptionFactory for 
EnsuresBetween.

The data dictionary for exceptions thrown will contain entries for RequirementType,
RequirementName, Value, ValueExpression, LowerBound, LowerBoundExpression, UpperBound
and UpperBoundExpression. The data dictionary for the String overloads will 
contain an additional entry for StringComparison.

**Examples:**
```C#
var customMessageTemplate = "{ValueExpression} must be greater than (or equal to) {LowerBound} and less than (or equal to) {UpperBound}";
var customExceptionFactory = new CustomExceptionFactory();

var number = 42;
var intLowerBound = 0;
var intUpperBound = 100;

// Precondition with default message template and default exception factory.
number.RequiresBetween(intLowerBound, intUpperBound);

// Precondition with custom message template and default exception factory.
number.RequiresBetween(intLowerBound, intUpperBound, customMessageTemplate);

// Precondition with default message template and custom exception factory.
number.RequiresBetween(intLowerBound, intUpperBound, exceptionFactory: customExceptionFactory);

// Precondition with custom message template and custom exception factory.
number.RequiresBetween(intLowerBound, intUpperBound, customMessageTemplate, customExceptionFactory);


// Postcondition with default message template and default exception factory.
number.RequiresBetween(intLowerBound, intUpperBound);

// Postcondition with custom message template and default exception factory.
number.RequiresBetween(intLowerBound, intUpperBound, customMessageTemplate);

// Postcondition with default message template and custom exception factory.
number.RequiresBetween(intLowerBound, intUpperBound, exceptionFactory: customExceptionFactory);

// Postcondition with custom message template and custom exception factory.
number.RequiresBetween(intLowerBound, intUpperBound, customMessageTemplate, customExceptionFactory);


var point = new Point { X = 1, Y = 12 };
var pointLowerBound = new Point { X = 0, Y = 0 };
var pointUpperBound = new Point { X = 10, Y = 10 };
var comparer = new PointDistanceFromOriginComparer();

// Precondition with default message template and default exception factory.
point.RequiresBetween(pointLowerBound, pointUpperBound, comparer);

// Precondition with custom message template and default exception factory.
point.RequiresBetween(pointLowerBound, pointUpperBound, comparer, customMessageTemplate);

// Precondition with default message template and custom exception factory.
point.RequiresBetween(pointLowerBound, pointUpperBound, comparer, exceptionFactory: customExceptionFactory);

// Precondition with custom message template and custom exception factory.
point.RequiresBetween(pointLowerBound, pointUpperBound, comparer, customMessageTemplate, customExceptionFactory);


// Postcondition with default message template and default exception factory.
point.RequiresBetween(pointLowerBound, pointUpperBound, comparer);

// Postcondition with custom message template and default exception factory.
point.RequiresBetween(pointLowerBound, pointUpperBound, comparer, customMessageTemplate);

// Postcondition with default message template and custom exception factory.
point.RequiresBetween(pointLowerBound, pointUpperBound, comparer, exceptionFactory: customExceptionFactory);

// Postcondition with custom message template and custom exception factory.
point.RequiresBetween(pointLowerBound, pointUpperBound, comparer, customMessageTemplate, customExceptionFactory);


var str = "ELEPHANT";
var strLowerBound = "Aardvark";
var strUpperBound = "Zebra";
var comparisonType = StringComparison.OrdinalIgnoreCase;

// Precondition with default message template and default exception factory.
str.RequiresBetween(strLowerBound, strUpperBound, comparisonType);

// Precondition with custom message template and default exception factory.
str.RequiresBetween(strLowerBound, strUpperBound, comparisonType, customMessageTemplate);

// Precondition with default message template and custom exception factory.
str.RequiresBetween(strLowerBound, strUpperBound, comparisonType, exceptionFactory: customExceptionFactory);

// Precondition with custom message template and custom exception factory.
str.RequiresBetween(strLowerBound, strUpperBound, comparisonType, customMessageTemplate, customExceptionFactory);


// Postcondition with default message template and default exception factory.
str.RequiresBetween(strLowerBound, strUpperBound, comparisonType);

// Postcondition with custom message template and default exception factory.
str.RequiresBetween(strLowerBound, strUpperBound, comparisonType, customMessageTemplate);

// Postcondition with default message template and custom exception factory.
str.RequiresBetween(strLowerBound, strUpperBound, comparisonType, exceptionFactory: customExceptionFactory);

// Postcondition with custom message template and custom exception factory.
str.RequiresBetween(strLowerBound, strUpperBound, comparisonType, customMessageTemplate, customExceptionFactory);
```

Implementation details for the Point examples:

[Point struct](/DbC.Net.TestAndExampleResources/Point.cs)

[PointDistanceFromOriginComparer](/DbC.Net.TestAndExampleResources/PointDistanceFromOriginComparer.cs)
