### NotEqual

NotEqual requires that the value being checked is not equal to a target value. 
RequiresNotEqual and EnsuresNotEqual have several overloads that support IEquatable<T> 
and IEqualtiyComparer<T> as well as an overload for String that accepts a 
StringComparison value that specifies how the comparison is performed.

Method signatures:
```C#
T RequiresNotEqual<T>(this T value, T target, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null]) where T : IEquatable<T>

T RequiresNotEqual<T>(this T value, T target, IEqualityComparer<T> comparer, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null])

String RequiresNotEqual<T>(this String value, String target, StringComparison comparisonType, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null])

T EnsuresNotEqual<T>(this T value, T target, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null]) where T : IEquatable<T>

T EnsuresNotEqual<T>(this T value, T target, IEqualityComparer<T> comparer, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null])

String EnsuresNotEqual<T>(this String value, String target, StringComparison comparisonType, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null])
```

The default message template for NotEqual is "{RequirementType} {RequirementName} failed: {ValueExpression} must not be equal to {Target}".
The default exception factory for RequiresNotEqual is StandardExceptionFactories.ArgumentExceptionFactory
and StandardExceptionFactories.PostconditionFailedExceptionFactory for 
EnsuresNotEqual.

The data dictionary for exceptions thrown will contain entries for RequirementType,
RequirementName, Value, ValueExpression, Target and TargetExpression. The data
dictionary for the String overloads will contain an additional entry for 
StringComparison.

Examples:

```C#
var customMessageTemplate = "{ValueExpression} must not be equal to {Target}";
var customExceptionFactory = new CustomExceptionFactory();

var currentDate = new DateOnly(2021, 12, 25);
var targetDate = new DateOnly(2021, 12, 25);

// Precondition with default message template/default exception factory.
currentDate.RequiresNotEqual(targetDate);

// Precondition with custom message template/default exception factory.
currentDate.RequiresNotEqual(targetDate, customMessageTemplate);

// Precondition with default message template/custom exception factory.
currentDate.RequiresNotEqual(targetDate, exceptionFactory: customExceptionFactory);

// Precondition with custom message template/custom exception factory.
currentDate.RequiresNotEqual(targetDate, customMessageTemplate, customExceptionFactory);


// Postcondition with default message template/default exception factory.
currentDate.EnsuresNotEqual(targetDate);

// Postcondition with custom message template/default exception factory.
currentDate.EnsuresNotEqual(targetDate, customMessageTemplate);

// Postcondition with default message template/custom exception factory.
currentDate.EnsuresNotEqual(targetDate, exceptionFactory: customExceptionFactory);

// Postcondition with custom message template/custom exception factory.
currentDate.EnsuresNotEqual(targetDate, customMessageTemplate, customExceptionFactory);


var box = new Box(1, 1, 8, "Red");
var targetBox = new Box(2, 2, 2, "Blue");
var comparer = new BoxVolumeComparer();

// Precondition with default message template/default exception factory.
box.RequiresNotEqual(targetBox, comparer);

// Precondition with custom message template/default exception factory.
box.RequiresNotEqual(targetBox, comparer, customMessageTemplate);

// Precondition with default message template/custom exception factory.
box.RequiresNotEqual(targetBox, comparer, exceptionFactory: customExceptionFactory);

// Precondition with custom message template/custom exception factory.
box.RequiresNotEqual(targetBox, comparer, customMessageTemplate, customExceptionFactory);


// Postcondition with default message template/default exception factory.
box.EnsuresNotEqual(targetBox, comparer);

// Postcondition with custom message template/default exception factory.
box.EnsuresNotEqual(targetBox, comparer, customMessageTemplate);

// Postcondition with default message template/custom exception factory.
box.EnsuresNotEqual(targetBox, comparer, exceptionFactory: customExceptionFactory);

// Postcondition with custom message template/custom exception factory.
box.EnsuresNotEqual(targetBox, comparer, customMessageTemplate, customExceptionFactory);


var str = "qwerty";
var targetStr = "QWERTY";
var comparisonType = StringComparison.OrdinalIgnoreCase;

// Precondition with default message template/default exception factory.
str.RequiresNotEqual(targetStr, comparisonType);

// Precondition with custom message template/default exception factory.
str.RequiresNotEqual(targetStr, comparisonType, customMessageTemplate);

// Precondition with default message template/custom exception factory.
str.RequiresNotEqual(targetStr, comparisonType, exceptionFactory: customExceptionFactory);

// Precondition with custom message template/custom exception factory.
str.RequiresNotEqual(targetStr, comparisonType, customMessageTemplate, customExceptionFactory);


// Postcondition with default message template/default exception factory.
str.EnsuresNotEqual(targetStr, comparisonType);

// Postcondition with custom message template/default exception factory.
str.EnsuresNotEqual(targetStr, comparisonType, customMessageTemplate);

// Postcondition with default message template/custom exception factory.
str.EnsuresNotEqual(targetStr, comparisonType, exceptionFactory: customExceptionFactory);

// Postcondition with custom message template/custom exception factory.
str.EnsuresNotEqual(targetStr, comparisonType, customMessageTemplate, customExceptionFactory);
```

