### StartsWith

StartsWith requires that the string value being checked start with the target substring.
StartsWith supports an optional StringComparison parameter that specifies how the 
substring check is performed. By default the check is performed using an ordinal,
case-sensitive comparison.

StartsWith will always fail if the string value being checked is null.  An empty 
target substring (String.Empty) will always pass the requirement (unless the
string being checked is null).

**Method signatures:**
```C#
String RequiresStartsWith(this String value, String target, [StringComparison comparisonType = StringComparison.Ordinal], [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null])

String EnsuresStartsWith(this String value, String target, [StringComparison comparisonType = StringComparison.Ordinal], [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null])
```

The default message template for StartsWith is "{RequirementType} {RequirementName} failed: {ValueExpression} must start with the substring "{Target}"".
The default exception factory for RequiresStartsWith is StandardExceptionFactories.ArgumentExceptionFactory 
and StandardExceptionFactories.PostconditionFailedExceptionFactory for 
EnsuresStartsWith.

The data dictionary for exceptions thrown will contain entries for RequirementType,
RequirementName, Value, Target, StringComparison, ValueExpression and TargetExpression.

Requires/EnsuresStartsWith will throw an ArgumentNullException if the target substring
is null.

**Examples:**
```C#
var customMessageTemplate = "{ValueExpression} must start with target substring";
var customExceptionFactory = new CustomExceptionFactory();

var value = "This is a test. This is only a test";
var target = "THIS";
var comparisionType = StringComparison.OrdinalIgnoreCase;


// Precondition with default comparisionType, default message template and default exception factory.
value.RequiresStartsWith(target);

// Precondition with default comparisionType, custom message template and default exception factory.
value.RequiresStartsWith(target, messageTemplate: customMessageTemplate);

// Precondition with default comparisionType, default message template and custom exception factory.
value.RequiresStartsWith(target, exceptionFactory: customExceptionFactory);

// Precondition with default comparisionType, custom message template and custom exception factory.
value.RequiresStartsWith(target, messageTemplate: customMessageTemplate, exceptionFactory: customExceptionFactory);


// Precondition with comparisionType, default message template and default exception factory.
value.RequiresStartsWith(target, comparisionType);

// Precondition with comparisionType, custom message template and default exception factory.
value.RequiresStartsWith(target, comparisionType, customMessageTemplate);

// Precondition with comparisionType, default message template and custom exception factory.
value.RequiresStartsWith(target, comparisionType, exceptionFactory: customExceptionFactory);

// Precondition with comparisionType, custom message template and custom exception factory.
value.RequiresStartsWith(target, comparisionType, customMessageTemplate, customExceptionFactory);


// Postcondition with default comparisionType, default message template and default exception factory.
value.EnsuresStartsWith(target);

// Postcondition with default comparisionType, custom message template and default exception factory.
value.EnsuresStartsWith(target, messageTemplate: customMessageTemplate);

// Postcondition with default comparisionType, default message template and custom exception factory.
value.EnsuresStartsWith(target, exceptionFactory: customExceptionFactory);

// Postcondition with default comparisionType, custom message template and custom exception factory.
value.EnsuresStartsWith(target, messageTemplate: customMessageTemplate, exceptionFactory: customExceptionFactory);


// Postcondition with comparisionType, default message template and default exception factory.
value.EnsuresStartsWith(target, comparisionType);

// Postcondition with comparisionType, custom message template and default exception factory.
value.EnsuresStartsWith(target, comparisionType, customMessageTemplate);

// Postcondition with comparisionType, default message template and custom exception factory.
value.EnsuresStartsWith(target, comparisionType, exceptionFactory: customExceptionFactory);

// Postcondition with comparisionType, custom message template and custom exception factory.
value.EnsuresStartsWith(target, comparisionType, customMessageTemplate, customExceptionFactory);
```