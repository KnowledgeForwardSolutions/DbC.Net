### AlphaNumericOnly

AlphaNumericOnly requires that the string value being checked contain only 
alphanumeric characters (as defined by the Char.IsLetterOrDigit method). A null
or empty string will fail the requirement.

**Method signatures:**
```C#
String RequiresAlphaNumericOnly(this String value, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null])

String EnsuresAlphaNumericOnly(this String value, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null])
```

The default message template for AlphaNumericOnly is "{RequirementType} {RequirementName} failed: {ValueExpression} may only contain alphanumeric characters".
The default exception factory for RequiresAlphaNumericOnly is StandardExceptionFactories.ArgumentExceptionFactory 
and StandardExceptionFactories.PostconditionFailedExceptionFactory for 
EnsuresAlphaNumericOnly.

The data dictionary for exceptions thrown will contain entries for RequirementType,
RequirementName, Value and ValueExpression.

**Examples:**
```C#
var customMessageTemplate = "{ValueExpression} must contain only letters or digits";
var customExceptionFactory = new CustomExceptionFactory();

var value = "This is a test!";

// Precondition with default message template and default exception factory.
value.RequiresAlphaNumericOnly();

// Precondition with custom message template and default exception factory.
value.RequiresAlphaNumericOnly(customMessageTemplate);

// Precondition with default message template and custom exception factory.
value.RequiresAlphaNumericOnly(exceptionFactory: customExceptionFactory);

// Precondition with custom message template and custom exception factory.
value.RequiresAlphaNumericOnly(customMessageTemplate, customExceptionFactory);


// Postcondition with default message template and default exception factory.
value.EnsuresAlphaNumericOnly();

// Postcondition with custom message template and default exception factory.
value.EnsuresAlphaNumericOnly(customMessageTemplate);

// Postcondition with default message template and custom exception factory.
value.EnsuresAlphaNumericOnly(exceptionFactory: customExceptionFactory);

// Postcondition with custom message template and custom exception factory.
value.EnsuresAlphaNumericOnly(customMessageTemplate, customExceptionFactory);
```