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
var customMessageTemplate = "{ValueExpression} must be less than {UpperBound}";
var customExceptionFactory = new CustomExceptionFactory();

var changeDate = new DateTime(2023, 1, 1);
var upperBoundDate = new DateTime(2023, 3, 12, 11, 17, 38, 1234);

// Precondition with default message template/default exception factory.
changeDate.RequiresLessThan(upperBoundDate);

// Precondition with custom message template/default exception factory.
changeDate.RequiresLessThan(upperBoundDate, customMessageTemplate);

// Precondition with default message template/custom exception factory.
changeDate.RequiresLessThan(upperBoundDate, exceptionFactory: customExceptionFactory);

// Precondition with custom message template/custom exception factory.
changeDate.RequiresLessThan(upperBoundDate, customMessageTemplate, customExceptionFactory);


// Postcondition with default message template/default exception factory.
changeDate.EnsuresLessThan(upperBoundDate);

// Postcondition with custom message template/default exception factory.
changeDate.EnsuresLessThan(upperBoundDate, customMessageTemplate);

// Postcondition with default message template/custom exception factory.
changeDate.EnsuresLessThan(upperBoundDate, exceptionFactory: customExceptionFactory);

// Postcondition with custom message template/custom exception factory.
changeDate.EnsuresLessThan(upperBoundDate, customMessageTemplate, customExceptionFactory);


var point = new Point { X = 1, Y = 12 };
var upperBoundPoint = new Point { X = 10, Y = 10 };
var comparer = new PointDistanceFromOriginComparer();

// Precondition with default message template/default exception factory.
point.RequiresLessThan(upperBoundPoint, comparer);

// Precondition with custom message template/default exception factory.
point.RequiresLessThan(upperBoundPoint, comparer, customMessageTemplate);

// Precondition with default message template/custom exception factory.
point.RequiresLessThan(upperBoundPoint, comparer, exceptionFactory: customExceptionFactory);

// Precondition with custom message template/custom exception factory.
point.RequiresLessThan(upperBoundPoint, comparer, customMessageTemplate, customExceptionFactory);


// Postcondition with default message template/default exception factory.
point.EnsuresLessThan(upperBoundPoint, comparer);

// Postcondition with custom message template/default exception factory.
point.EnsuresLessThan(upperBoundPoint, comparer, customMessageTemplate);

// Postcondition with default message template/custom exception factory.
point.EnsuresLessThan(upperBoundPoint, comparer, exceptionFactory: customExceptionFactory);

// Postcondition with custom message template/custom exception factory.
point.EnsuresLessThan(upperBoundPoint, comparer, customMessageTemplate, customExceptionFactory);


var str = "QWERTY";
var upperBoundStr = "asdf";
var comparisonType = StringComparison.OrdinalIgnoreCase;

// Precondition with default message template/default exception factory.
str.RequiresLessThan(upperBoundStr, comparisonType);

// Precondition with custom message template/default exception factory.
str.RequiresLessThan(upperBoundStr, comparisonType, customMessageTemplate);

// Precondition with default message template/custom exception factory.
str.RequiresLessThan(upperBoundStr, comparisonType, exceptionFactory: customExceptionFactory);

// Precondition with custom message template/custom exception factory.
str.RequiresLessThan(upperBoundStr, comparisonType, customMessageTemplate, customExceptionFactory);


// Postcondition with default message template/default exception factory.
str.EnsuresLessThan(upperBoundStr, comparisonType);

// Postcondition with custom message template/default exception factory.
str.EnsuresLessThan(upperBoundStr, comparisonType, customMessageTemplate);

// Postcondition with default message template/custom exception factory.
str.EnsuresLessThan(upperBoundStr, comparisonType, exceptionFactory: customExceptionFactory);

// Postcondition with custom message template/custom exception factory.
str.EnsuresLessThan(upperBoundStr, comparisonType, customMessageTemplate, customExceptionFactory);
```

Implementation details for the Point examples:

[Point struct](/DbC.Net.TestAndExampleResources/Point.cs)

[PointDistanceFromOriginComparer](/DbC.Net.TestAndExampleResources/PointDistanceFromOriginComparer.cs)
