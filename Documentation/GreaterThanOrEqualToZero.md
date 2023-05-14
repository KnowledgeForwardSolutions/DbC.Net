### GreaterThanOrEqualToZero

GreaterThanOrEqualToZero requires that the signed numeric value being checked be 
greater than or equal to zero. GreaterThanOrEqualToZero is only implemented for
signed numeric types because unsigned numeric types would always pass the requirement.

**Method signatures:**
```C#
T RequiresGreaterThanOrEqualToZero<T>(this T value, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null]) where T : ISignedNumber<T>

T EnsuresGreaterThanOrEqualToZero<T>(this T value, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null]) where T : ISignedNumber<T>
```

The default message template for GreaterThanOrEqualToZero is "{RequirementType} {RequirementName} failed: {ValueExpression} must be greater than or equal to zero".
The default exception factory for RequiresGreaterThanOrEqualToZero is StandardExceptionFactories.ArgumentOutOfRangeExceptionFactory
and StandardExceptionFactories.PostconditionFailedExceptionFactory for 
EnsuresGreaterThanOrEqualToZero.

The data dictionary for exceptions thrown will contain entries for RequirementType,
RequirementName, Value, and ValueExpression.

**Examples:**
```C#
var customMessageTemplate = "{ValueExpression} must be greater than or equal to zero";
var customExceptionFactory = new CustomExceptionFactory();

var value = Double.Pi;

// Precondition with default message template and default exception factory.
value.RequiresGreaterThanOrEqualToZero();

// Precondition with custom message template and default exception factory.
value.RequiresGreaterThanOrEqualToZero(customMessageTemplate);

// Precondition with default message template and custom exception factory.
value.RequiresGreaterThanOrEqualToZero(exceptionFactory: customExceptionFactory);

// Precondition with custom message template and custom exception factory.
value.RequiresGreaterThanOrEqualToZero(customMessageTemplate, customExceptionFactory);


// Postcondition with default message template and default exception factory.
value.EnsuresGreaterThanOrEqualToZero();

// Postcondition with custom message template and default exception factory.
value.EnsuresGreaterThanOrEqualToZero(customMessageTemplate);

// Postcondition with default message template and custom exception factory.
value.EnsuresGreaterThanOrEqualToZero(exceptionFactory: customExceptionFactory);

// Postcondition with custom message template and custom exception factory.
value.EnsuresGreaterThanOrEqualToZero(customMessageTemplate, customExceptionFactory);
```
