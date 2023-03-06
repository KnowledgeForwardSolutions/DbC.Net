### Equal

Equal requires that the value being checked is equal to a target value. RequiresEqual
and EnsuresEqual have several overloads that support IEquatable<T> and
IEqualtiyComparer<T> as well as an overload for String that accepts a 
StringComparison value that specifies how the comparison is performed.

**Method signatures:**
```C#
T RequiresEqual<T>(this T value, T target, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null]) where T : IEquatable<T>

T RequiresEqual<T>(this T value, T target, IEqualityComparer<T> comparer, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null])

String RequiresEqual<T>(this String value, String target, StringComparison comparisonType, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null])

T EnsuresEqual<T>(this T value, T target, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null]) where T : IEquatable<T>

T EnsuresEqual<T>(this T value, T target, IEqualityComparer<T> comparer, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null])

String EnsuresEqual<T>(this String value, String target, StringComparison comparisonType, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null])
```

The default message template for Equal is "{RequirementType} {RequirementName} failed: {ValueExpression} must be equal to {Target}".
The default exception factory for RequiresEqual is StandardExceptionFactories.ArgumentExceptionFactory
and StandardExceptionFactories.PostconditionFailedExceptionFactory for 
EnsuresEqual.

The data dictionary for exceptions thrown will contain entries for RequirementType,
RequirementName, Value, ValueExpression, Target and TargetExpression. The data
dictionary for the String overloads will contain an additional entry for 
StringComparison.

**Examples:**
```C#
var customMessageTemplate = "{ValueExpression} must be equal to {Target}";
var customExceptionFactory = new CustomExceptionFactory();

var totalCount = 99;
var targetCount = 100;

// Precondition with default message template/default exception factory.
totalCount.RequiresEqual(targetCount);

// Precondition with custom message template/default exception factory.
totalCount.RequiresEqual(targetCount, customMessageTemplate);

// Precondition with default message template/custom exception factory.
totalCount.RequiresEqual(targetCount, exceptionFactory: customExceptionFactory);

// Precondition with custom message template/custom exception factory.
totalCount.RequiresEqual(targetCount, customMessageTemplate, customExceptionFactory);


// Postcondition with default message template/default exception factory.
totalCount.EnsuresEqual(targetCount);

// Postcondition with custom message template/default exception factory.
totalCount.EnsuresEqual(targetCount, customMessageTemplate);

// Postcondition with default message template/custom exception factory.
totalCount.EnsuresEqual(targetCount, exceptionFactory: customExceptionFactory);

// Postcondition with custom message template/custom exception factory.
totalCount.EnsuresEqual(targetCount, customMessageTemplate, customExceptionFactory);


var box = new Box(1, 2, 3, "Red");
var targetBox = new Box(2, 2, 2, "Blue");
var comparer = new BoxVolumeComparer();

// Precondition with default message template/default exception factory.
box.RequiresEqual(targetBox, comparer);

// Precondition with custom message template/default exception factory.
box.RequiresEqual(targetBox, comparer, customMessageTemplate);

// Precondition with default message template/custom exception factory.
box.RequiresEqual(targetBox, comparer, exceptionFactory: customExceptionFactory);

// Precondition with custom message template/custom exception factory.
box.RequiresEqual(targetBox, comparer, customMessageTemplate, customExceptionFactory);


// Postcondition with default message template/default exception factory.
box.EnsuresEqual(targetBox, comparer);

// Postcondition with custom message template/default exception factory.
box.EnsuresEqual(targetBox, comparer, customMessageTemplate);

// Postcondition with default message template/custom exception factory.
box.EnsuresEqual(targetBox, comparer, exceptionFactory: customExceptionFactory);

// Postcondition with custom message template/custom exception factory.
box.EnsuresEqual(targetBox, comparer, customMessageTemplate, customExceptionFactory);


var str = "asdf";
var targetStr = "QWERTY";
var comparisonType = StringComparison.OrdinalIgnoreCase;

// Precondition with default message template/default exception factory.
str.RequiresEqual(targetStr, comparisonType);

// Precondition with custom message template/default exception factory.
str.RequiresEqual(targetStr, comparisonType, customMessageTemplate);

// Precondition with default message template/custom exception factory.
str.RequiresEqual(targetStr, comparisonType, exceptionFactory: customExceptionFactory);

// Precondition with custom message template/custom exception factory.
str.RequiresEqual(targetStr, comparisonType, customMessageTemplate, customExceptionFactory);


// Postcondition with default message template/default exception factory.
str.EnsuresEqual(targetStr, comparisonType);

// Postcondition with custom message template/default exception factory.
str.EnsuresEqual(targetStr, comparisonType, customMessageTemplate);

// Postcondition with default message template/custom exception factory.
str.EnsuresEqual(targetStr, comparisonType, exceptionFactory: customExceptionFactory);

// Postcondition with custom message template/custom exception factory.
str.EnsuresEqual(targetStr, comparisonType, customMessageTemplate, customExceptionFactory);
```

Implementation details for the Box examples:

[Box record](/DbC.Net.TestAndExampleResources/Box.cs)

[BoxVolumeComparer](/DbC.Net.TestAndExampleResources/BoxVolumeComparer.cs)


