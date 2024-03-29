### MinLength

MinLength requires that the string value being checked has a length that is at
least the specified minimum length. MinLength treats a null string as a zero 
length string.

RequiresMinLength and EnsuresMinLength overloads will throw an ArgumentOutOfRangeException
if the supplied minLength is negative.

**Method signatures:**
```C#
String RequiresMinLength(this String value, Int32 minLength, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? minLengthExpression = null])

String EnsuresMinLength(this String value, Int32 minLength, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? minLengthExpression = null])
```

The default message template for MinLength is "{RequirementType} {RequirementName} failed: {ValueExpression} must have a minimum length of {MinLength}".
The default exception factory for RequiresMinLength is StandardExceptionFactories.ArgumentExceptionFactory
and StandardExceptionFactories.PostconditionFailedExceptionFactory for 
EnsuresMinLength.

The data dictionary for exceptions thrown will contain entries for RequirementType,
RequirementName, Value, ValueExpression, MinLength and MinLengthExpression.

**Examples:**
```C#
var customMessageTemplate = "{ValueExpression} may not be less than 10 characters in length";
var customExceptionFactory = new CustomExceptionFactory();

var value = "ABC";
var minLength = 10;

// Precondition with default message template and default exception factory.
value.RequiresMinLength(minLength);

// Precondition with custom message template and default exception factory.
value.RequiresMinLength(minLength, customMessageTemplate);

// Precondition with default message template and custom exception factory.
value.RequiresMinLength(minLength, exceptionFactory: customExceptionFactory);

// Precondition with custom message template and custom exception factory.
value.RequiresMinLength(minLength, customMessageTemplate, customExceptionFactory);


// Postcondition with default message template and default exception factory.
value.EnsuresMinLength(minLength);

// Postcondition with custom message template and default exception factory.
value.EnsuresMinLength(minLength, customMessageTemplate);

// Postcondition with default message template and custom exception factory.
value.EnsuresMinLength(minLength, exceptionFactory: customExceptionFactory);

// Postcondition with custom message template and custom exception factory.
value.EnsuresMinLength(minLength, customMessageTemplate, customExceptionFactory);
```

