### GreaterThan

GreaterThan requires that the value being checked be greater than a lower bound. 
RequiresGreaterThan and EnsuresGreaterThan have several overloads that support 
IComparable<T> and IComparer<T> as well as an overload for String that accepts a 
StringComparison value that specifies how the comparison is performed.

**Method signatures:**
```C#
T RequiresGreaterThan<T>(this T value, T lowerBound, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null]) where T : IComparable<T>

T RequiresGreaterThan<T>(this T value, T lowerBound, IComparer<T> comparer, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null])

String RequiresGreaterThan(this String value, String lowerBound, StringComparison comparisonType, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null])

T EnsuresGreaterThan<T>(this T value, T lowerBound, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null]) where T : IComparable<T>

T EnsuresGreaterThan<T>(this T value, T lowerBound, IComparer<T> comparer, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null])

String EnsuresGreaterThan(this String value, String lowerBound, StringComparison comparisonType, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null])
```

The default message template for GreaterThan is "{RequirementType} {RequirementName} failed: {ValueExpression} must be greater than {LowerBound}".
The default exception factory for RequiresGreaterThan is StandardExceptionFactories.ArgumentOutOfRangeExceptionFactory
and StandardExceptionFactories.PostconditionFailedExceptionFactory for 
EnsuresGreaterThan.

The data dictionary for exceptions thrown will contain entries for RequirementType,
RequirementName, Value, ValueExpression, LowerBound and LowerBoundExpression. The 
data dictionary for the String overloads will contain an additional entry for 
StringComparison.

**Examples:**
```C#
var customMessageTemplate = "{ValueExpression} must be greater than {LowerBound}";
var customExceptionFactory = new CustomExceptionFactory();

var changeDate = new DateTime(2023, 3, 12, 11, 17, 38, 1234);
var lowerBoundDate = new DateTime(2023, 1, 1);

// Precondition with default message template/default exception factory.
changeDate.RequiresGreaterThan(lowerBoundDate);

// Precondition with custom message template/default exception factory.
changeDate.RequiresGreaterThan(lowerBoundDate, customMessageTemplate);

// Precondition with default message template/custom exception factory.
changeDate.RequiresGreaterThan(lowerBoundDate, exceptionFactory: customExceptionFactory);

// Precondition with custom message template/custom exception factory.
changeDate.RequiresGreaterThan(lowerBoundDate, customMessageTemplate, customExceptionFactory);


// Postcondition with default message template/default exception factory.
changeDate.EnsuresGreaterThan(lowerBoundDate);

// Postcondition with custom message template/default exception factory.
changeDate.EnsuresGreaterThan(lowerBoundDate, customMessageTemplate);

// Postcondition with default message template/custom exception factory.
changeDate.EnsuresGreaterThan(lowerBoundDate, exceptionFactory: customExceptionFactory);

// Postcondition with custom message template/custom exception factory.
changeDate.EnsuresGreaterThan(lowerBoundDate, customMessageTemplate, customExceptionFactory);


var point = new Point { X = 10, Y = 10 };
var lowerBoundPoint = new Point { X = 1, Y = 12 };
var comparer = new PointDistanceFromOriginComparer();

// Precondition with default message template/default exception factory.
point.RequiresGreaterThan(lowerBoundPoint, comparer);

// Precondition with custom message template/default exception factory.
point.RequiresGreaterThan(lowerBoundPoint, comparer, customMessageTemplate);

// Precondition with default message template/custom exception factory.
point.RequiresGreaterThan(lowerBoundPoint, comparer, exceptionFactory: customExceptionFactory);

// Precondition with custom message template/custom exception factory.
point.RequiresGreaterThan(lowerBoundPoint, comparer, customMessageTemplate, customExceptionFactory);


// Postcondition with default message template/default exception factory.
point.EnsuresGreaterThan(lowerBoundPoint, comparer);

// Postcondition with custom message template/default exception factory.
point.EnsuresGreaterThan(lowerBoundPoint, comparer, customMessageTemplate);

// Postcondition with default message template/custom exception factory.
point.EnsuresGreaterThan(lowerBoundPoint, comparer, exceptionFactory: customExceptionFactory);

// Postcondition with custom message template/custom exception factory.
point.EnsuresGreaterThan(lowerBoundPoint, comparer, customMessageTemplate, customExceptionFactory);


var str = "asdf";
var lowerBoundStr = "QWERTY";
var comparisonType = StringComparison.OrdinalIgnoreCase;

// Precondition with default message template/default exception factory.
str.RequiresGreaterThan(lowerBoundStr, comparisonType);

// Precondition with custom message template/default exception factory.
str.RequiresGreaterThan(lowerBoundStr, comparisonType, customMessageTemplate);

// Precondition with default message template/custom exception factory.
str.RequiresGreaterThan(lowerBoundStr, comparisonType, exceptionFactory: customExceptionFactory);

// Precondition with custom message template/custom exception factory.
str.RequiresGreaterThan(lowerBoundStr, comparisonType, customMessageTemplate, customExceptionFactory);


// Postcondition with default message template/default exception factory.
str.EnsuresGreaterThan(lowerBoundStr, comparisonType);

// Postcondition with custom message template/default exception factory.
str.EnsuresGreaterThan(lowerBoundStr, comparisonType, customMessageTemplate);

// Postcondition with default message template/custom exception factory.
str.EnsuresGreaterThan(lowerBoundStr, comparisonType, exceptionFactory: customExceptionFactory);

// Postcondition with custom message template/custom exception factory.
str.EnsuresGreaterThan(lowerBoundStr, comparisonType, customMessageTemplate, customExceptionFactory);
```

Implementation details for the Point examples:

[Point struct](/DbC.Net.TestAndExampleResources/Point.cs)

[PointDistanceFromOriginComparer](/DbC.Net.TestAndExampleResources/PointDistanceFromOriginComparer.cs)
