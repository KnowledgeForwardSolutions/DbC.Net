### GreaterThan

GreaterThan requires that the value being checked be greater than a target value. 
RequiresGreaterThan and EnsuresGreaterThan have several overloads that support 
IComparable<T> and IComparer<T> as well as an overload for String that accepts a 
StringComparison value that specifies how the comparison is performed.

**Method signatures:**
```C#
T RequiresGreaterThan<T>(this T value, T target, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null]) where T : IComparable<T>

T RequiresGreaterThan<T>(this T value, T target, IComparer<T> comparer, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null])

String RequiresGreaterThan(this String value, String target, StringComparison comparisonType, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null])

T EnsuresGreaterThan<T>(this T value, T target, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null]) where T : IComparable<T>

T EnsuresGreaterThan<T>(this T value, T target, IComparer<T> comparer, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null])

String EnsuresGreaterThan(this String value, String target, StringComparison comparisonType, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null])
```

The default message template for GreaterThan is "{RequirementType} {RequirementName} failed: {ValueExpression} must be greater than {Target}".
The default exception factory for RequiresGreaterThan is StandardExceptionFactories.ArgumentOutOfRangeExceptionFactory
and StandardExceptionFactories.PostconditionFailedExceptionFactory for 
EnsuresGreaterThan.

The data dictionary for exceptions thrown will contain entries for RequirementType,
RequirementName, Value, ValueExpression, Target and TargetExpression. The data
dictionary for the String overloads will contain an additional entry for 
StringComparison.

**Examples:**
```C#
var customMessageTemplate = "{ValueExpression} must be greater than to {Target}";
var customExceptionFactory = new CustomExceptionFactory();

var changeDate = new DateTime(2023, 3, 12, 11, 17, 38, 1234);
var targetDate = new DateTime(2023, 1, 1);

// Precondition with default message template/default exception factory.
changeDate.RequiresGreaterThan(targetDate);

// Precondition with custom message template/default exception factory.
changeDate.RequiresGreaterThan(targetDate, customMessageTemplate);

// Precondition with default message template/custom exception factory.
changeDate.RequiresGreaterThan(targetDate, exceptionFactory: customExceptionFactory);

// Precondition with custom message template/custom exception factory.
changeDate.RequiresGreaterThan(targetDate, customMessageTemplate, customExceptionFactory);


// Postcondition with default message template/default exception factory.
changeDate.EnsuresGreaterThan(targetDate);

// Postcondition with custom message template/default exception factory.
changeDate.EnsuresGreaterThan(targetDate, customMessageTemplate);

// Postcondition with default message template/custom exception factory.
changeDate.EnsuresGreaterThan(targetDate, exceptionFactory: customExceptionFactory);

// Postcondition with custom message template/custom exception factory.
changeDate.EnsuresGreaterThan(targetDate, customMessageTemplate, customExceptionFactory);


var point = new Point { X = 10, Y = 10 };
var targetPoint = new Point { X = 1, Y = 12 };
var comparer = new PointDistanceFromOriginComparer();

// Precondition with default message template/default exception factory.
point.RequiresGreaterThan(targetPoint, comparer);

// Precondition with custom message template/default exception factory.
point.RequiresGreaterThan(targetPoint, comparer, customMessageTemplate);

// Precondition with default message template/custom exception factory.
point.RequiresGreaterThan(targetPoint, comparer, exceptionFactory: customExceptionFactory);

// Precondition with custom message template/custom exception factory.
point.RequiresGreaterThan(targetPoint, comparer, customMessageTemplate, customExceptionFactory);


// Postcondition with default message template/default exception factory.
point.EnsuresGreaterThan(targetPoint, comparer);

// Postcondition with custom message template/default exception factory.
point.EnsuresGreaterThan(targetPoint, comparer, customMessageTemplate);

// Postcondition with default message template/custom exception factory.
point.EnsuresGreaterThan(targetPoint, comparer, exceptionFactory: customExceptionFactory);

// Postcondition with custom message template/custom exception factory.
point.EnsuresGreaterThan(targetPoint, comparer, customMessageTemplate, customExceptionFactory);


var str = "asdf";
var targetStr = "QWERTY";
var comparisonType = StringComparison.OrdinalIgnoreCase;

// Precondition with default message template/default exception factory.
str.RequiresGreaterThan(targetStr, comparisonType);

// Precondition with custom message template/default exception factory.
str.RequiresGreaterThan(targetStr, comparisonType, customMessageTemplate);

// Precondition with default message template/custom exception factory.
str.RequiresGreaterThan(targetStr, comparisonType, exceptionFactory: customExceptionFactory);

// Precondition with custom message template/custom exception factory.
str.RequiresGreaterThan(targetStr, comparisonType, customMessageTemplate, customExceptionFactory);


// Postcondition with default message template/default exception factory.
str.EnsuresGreaterThan(targetStr, comparisonType);

// Postcondition with custom message template/default exception factory.
str.EnsuresGreaterThan(targetStr, comparisonType, customMessageTemplate);

// Postcondition with default message template/custom exception factory.
str.EnsuresGreaterThan(targetStr, comparisonType, exceptionFactory: customExceptionFactory);

// Postcondition with custom message template/custom exception factory.
str.EnsuresGreaterThan(targetStr, comparisonType, customMessageTemplate, customExceptionFactory);
```

Implementation details for the Point examples:

[Point struct](/DbC.Net.TestAndExampleResources/Point.cs)

[PointDistanceFromOriginComparer](/DbC.Net.TestAndExampleResources/PointDistanceFromOriginComparer.cs)
