### LessThanZero

LessThanZero requires that the INumber<T> value being checked be less than zero.

NOTE: Unsigned numeric types will always fail LessThanZero.

**Method signatures:**
```C#
T RequiresLessThanZero<T>(this T value, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null]) where T : INumber<T>

T EnsuresLessThanZero<T>(this T value, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null]) where T : INumber<T>
```

The default message template for LessThanZero is "{RequirementType} {RequirementName} failed: {ValueExpression} must be less than zero".
The default exception factory for RequiresLessThanZero is StandardExceptionFactories.ArgumentOutOfRangeExceptionFactory
and StandardExceptionFactories.PostconditionFailedExceptionFactory for 
EnsuresLessThanZero.

The data dictionary for exceptions thrown will contain entries for RequirementType,
RequirementName, Value, and ValueExpression.

**Examples:**
```C#
var customMessageTemplate = "{ValueExpression} must be less than zero";
var customExceptionFactory = new CustomExceptionFactory();

var value = Double.Pi;

// Precondition with default message template and default exception factory.
value.RequiresLessThanZero();

// Precondition with custom message template and default exception factory.
value.RequiresLessThanZero(customMessageTemplate);

// Precondition with default message template and custom exception factory.
value.RequiresLessThanZero(exceptionFactory: customExceptionFactory);

// Precondition with custom message template and custom exception factory.
value.RequiresLessThanZero(customMessageTemplate, customExceptionFactory);


// Postcondition with default message template and default exception factory.
value.EnsuresLessThanZero();

// Postcondition with custom message template and default exception factory.
value.EnsuresLessThanZero(customMessageTemplate);

// Postcondition with default message template and custom exception factory.
value.EnsuresLessThanZero(exceptionFactory: customExceptionFactory);

// Postcondition with custom message template and custom exception factory.
value.EnsuresLessThanZero(customMessageTemplate, customExceptionFactory);
```
