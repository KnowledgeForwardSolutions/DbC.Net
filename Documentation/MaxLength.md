### MaxLength

MaxLength requires that the string value being checked has a length that does not
exceed the specified maximum length. MaxLength treats a null string as a zero 
length string.

RequiresMaxLength and EnsuresMaxLength overloads will throw an ArgumentOutOfRangeException
if the supplied maxLength is negative.

**Method signatures:**
```C#
String RequiresMaxLength(this String value, Int32 maxLength, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? maxLengthExpression = null])

String EnsuresMaxLength(this String value, Int32 maxLength, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? maxLengthExpression = null])
```

The default message template for MaxLength is "{RequirementType} {RequirementName} failed: {ValueExpression} must have a maximum length of {MaxLength}".
The default exception factory for RequiresMaxLength is StandardExceptionFactories.ArgumentExceptionFactory
and StandardExceptionFactories.PostconditionFailedExceptionFactory for 
EnsuresMaxLength.

The data dictionary for exceptions thrown will contain entries for RequirementType,
RequirementName, Value, ValueExpression, MaxLength and MaxLengthExpression.

**Examples:**
```C#
var customMessageTemplate = "{ValueExpression} may not exceed 10 characters in length";
var customExceptionFactory = new CustomExceptionFactory();

var value = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
var maxLength = 10;

// Precondition with default message template and default exception factory.
value.RequiresMaxLength(maxLength);

// Precondition with custom message template and default exception factory.
value.RequiresMaxLength(maxLength, customMessageTemplate);

// Precondition with default message template and custom exception factory.
value.RequiresMaxLength(maxLength, exceptionFactory: customExceptionFactory);

// Precondition with custom message template and custom exception factory.
value.RequiresMaxLength(maxLength, customMessageTemplate, customExceptionFactory);


// Postcondition with default message template and default exception factory.
value.EnsuresMaxLength(maxLength);

// Postcondition with custom message template and default exception factory.
value.EnsuresMaxLength(maxLength, customMessageTemplate);

// Postcondition with default message template and custom exception factory.
value.EnsuresMaxLength(maxLength, exceptionFactory: customExceptionFactory);

// Postcondition with custom message template and custom exception factory.
value.EnsuresMaxLength(maxLength, customMessageTemplate, customExceptionFactory);
```

