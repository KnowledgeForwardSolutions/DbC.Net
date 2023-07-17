### DigitsOnly

DigitsOnly requires that the string value being checked contain only numeric 
characters (as defined by the Char.IsDigit method). A null or empty string will 
pass the requirement.

**Method signatures:**
```C#
String RequiresDigitsOnly(this String value, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null])

String EnsuresDigitsOnly(this String value, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null])
```

The default message template for DigitsOnly is "{RequirementType} {RequirementName} failed: {ValueExpression} may only contain numeric characters".
The default exception factory for RequiresDigitsOnly is StandardExceptionFactories.ArgumentExceptionFactory 
and StandardExceptionFactories.PostconditionFailedExceptionFactory for 
EnsuresDigitsOnly.

The data dictionary for exceptions thrown will contain entries for RequirementType,
RequirementName, Value and ValueExpression.

**Examples:**
```C#
var customMessageTemplate = "{ValueExpression} must contain only letters or digits";
var customExceptionFactory = new CustomExceptionFactory();

var value = "abc123";

// Precondition with default message template and default exception factory.
value.RequiresDigitsOnly();

// Precondition with custom message template and default exception factory.
value.RequiresDigitsOnly(customMessageTemplate);

// Precondition with default message template and custom exception factory.
value.RequiresDigitsOnly(exceptionFactory: customExceptionFactory);

// Precondition with custom message template and custom exception factory.
value.RequiresDigitsOnly(customMessageTemplate, customExceptionFactory);


// Postcondition with default message template and default exception factory.
value.EnsuresDigitsOnly();

// Postcondition with custom message template and default exception factory.
value.EnsuresDigitsOnly(customMessageTemplate);

// Postcondition with default message template and custom exception factory.
value.EnsuresDigitsOnly(exceptionFactory: customExceptionFactory);

// Postcondition with custom message template and custom exception factory.
value.EnsuresDigitsOnly(customMessageTemplate, customExceptionFactory);
```