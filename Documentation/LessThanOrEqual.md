### LessThanOrEqual

LessThanOrEqual requires that the value being checked be less than or
equal to an upper bound. RequiresLessThanOrEqual and EnsuresLessThanOrEqual
have several overloads that support IComparable<T> and IComparer<T> as well as 
an overload for String that accepts a StringComparison value that specifies how 
the comparison is performed.

**Method signatures:**
```C#
T RequiresLessThanOrEqual<T>(this T value, T upperBound, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null]) where T : IComparable<T>

T RequiresLessThanOrEqual<T>(this T value, T upperBound, IComparer<T> comparer, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null])

String RequiresLessThanOrEqual(this String value, String upperBound, StringComparison comparisonType, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null])

T EnsuresLessThanOrEqual<T>(this T value, T upperBound, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null]) where T : IComparable<T>

T EnsuresLessThanOrEqual<T>(this T value, T upperBound, IComparer<T> comparer, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null])

String EnsuresLessThanOrEqual(this String value, String upperBound, StringComparison comparisonType, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null])
```

The default message template for LessThanOrEqual is "{RequirementType} {RequirementName} failed: {ValueExpression} must be less than or equal to {UpperBound}".
The default exception factory for RequiresLessThanOrEqual is StandardExceptionFactories.ArgumentOutOfRangeExceptionFactory
and StandardExceptionFactories.PostconditionFailedExceptionFactory for 
EnsuresLessThanOrEqual.

The data dictionary for exceptions thrown will contain entries for RequirementType,
RequirementName, Value, ValueExpression, UpperBound and UpperBoundExpression. The 
data dictionary for the String overloads will contain an additional entry for 
StringComparison.

**Examples:**
```C#
var customMessageTemplate = "{ValueExpression} must be less than or equal to {UpperBound}";
var customExceptionFactory = new CustomExceptionFactory();

var changeDate = new DateTime(2023, 1, 1);
var upperBoundDate = new DateTime(2023, 3, 12, 11, 17, 38, 1234);

// Precondition with default message template and default exception factory.
changeDate.RequiresLessThanOrEqual(upperBoundDate);

// Precondition with custom message template and default exception factory.
changeDate.RequiresLessThanOrEqual(upperBoundDate, customMessageTemplate);

// Precondition with default message template and custom exception factory.
changeDate.RequiresLessThanOrEqual(upperBoundDate, exceptionFactory: customExceptionFactory);

// Precondition with custom message template and custom exception factory.
changeDate.RequiresLessThanOrEqual(upperBoundDate, customMessageTemplate, customExceptionFactory);


// Postcondition with default message template and default exception factory.
changeDate.EnsuresLessThanOrEqual(upperBoundDate);

// Postcondition with custom message template and default exception factory.
changeDate.EnsuresLessThanOrEqual(upperBoundDate, customMessageTemplate);

// Postcondition with default message template and custom exception factory.
changeDate.EnsuresLessThanOrEqual(upperBoundDate, exceptionFactory: customExceptionFactory);

// Postcondition with custom message template and custom exception factory.
changeDate.EnsuresLessThanOrEqual(upperBoundDate, customMessageTemplate, customExceptionFactory);


var point = new Point { X = 1, Y = 12 };
var upperBoundPoint = new Point { X = 10, Y = 10 };
var comparer = new PointDistanceFromOriginComparer();

// Precondition with default message template and default exception factory.
point.RequiresLessThanOrEqual(upperBoundPoint, comparer);

// Precondition with custom message template and default exception factory.
point.RequiresLessThanOrEqual(upperBoundPoint, comparer, customMessageTemplate);

// Precondition with default message template and custom exception factory.
point.RequiresLessThanOrEqual(upperBoundPoint, comparer, exceptionFactory: customExceptionFactory);

// Precondition with custom message template and custom exception factory.
point.RequiresLessThanOrEqual(upperBoundPoint, comparer, customMessageTemplate, customExceptionFactory);


// Postcondition with default message template and default exception factory.
point.EnsuresLessThanOrEqual(upperBoundPoint, comparer);

// Postcondition with custom message template and default exception factory.
point.EnsuresLessThanOrEqual(upperBoundPoint, comparer, customMessageTemplate);

// Postcondition with default message template and custom exception factory.
point.EnsuresLessThanOrEqual(upperBoundPoint, comparer, exceptionFactory: customExceptionFactory);

// Postcondition with custom message template and custom exception factory.
point.EnsuresLessThanOrEqual(upperBoundPoint, comparer, customMessageTemplate, customExceptionFactory);


var str = "QWERTY";
var upperBoundStr = "asdf";
var comparisonType = StringComparison.OrdinalIgnoreCase;

// Precondition with default message template and default exception factory.
str.RequiresLessThanOrEqual(upperBoundStr, comparisonType);

// Precondition with custom message template and default exception factory.
str.RequiresLessThanOrEqual(upperBoundStr, comparisonType, customMessageTemplate);

// Precondition with default message template and custom exception factory.
str.RequiresLessThanOrEqual(upperBoundStr, comparisonType, exceptionFactory: customExceptionFactory);

// Precondition with custom message template and custom exception factory.
str.RequiresLessThanOrEqual(upperBoundStr, comparisonType, customMessageTemplate, customExceptionFactory);


// Postcondition with default message template and default exception factory.
str.EnsuresLessThanOrEqual(upperBoundStr, comparisonType);

// Postcondition with custom message template and default exception factory.
str.EnsuresLessThanOrEqual(upperBoundStr, comparisonType, customMessageTemplate);

// Postcondition with default message template and custom exception factory.
str.EnsuresLessThanOrEqual(upperBoundStr, comparisonType, exceptionFactory: customExceptionFactory);

// Postcondition with custom message template and custom exception factory.
str.EnsuresLessThanOrEqual(upperBoundStr, comparisonType, customMessageTemplate, customExceptionFactory);
```

Implementation details for the Point examples:

[Point struct](/DbC.Net.TestAndExampleResources/Point.cs)

[PointDistanceFromOriginComparer](/DbC.Net.TestAndExampleResources/PointDistanceFromOriginComparer.cs)

