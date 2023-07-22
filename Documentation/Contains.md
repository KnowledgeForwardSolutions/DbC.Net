### Contains

Contains requires that the string value being checked contain the target substring.
Contains supports an optional StringComparison parameter that specifies how the 
substring check is performed. By default the check is performed using an ordinal,
case-sensitive comparison.

Contains will always fail if the string value being checked is null.  An empty 
target substring (String.Empty) will always pass the requirement (unless the
string being checked is null).

**Method signatures:**
```C#
String RequiresContains(this String value, String target, [StringComparison comparisonType = StringComparison.Ordinal], [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null])

String EnsuresContains(this String value, String target, [StringComparison comparisonType = StringComparison.Ordinal], [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null])
```

The default message template for Contains is "{RequirementType} {RequirementName} failed: {ValueExpression} must contain the substring "{Target}"".
The default exception factory for RequiresContains is StandardExceptionFactories.ArgumentExceptionFactory 
and StandardExceptionFactories.PostconditionFailedExceptionFactory for 
EnsuresContains.

The data dictionary for exceptions thrown will contain entries for RequirementType,
RequirementName, Value, Target, StringComparison, ValueExpression and TargetExpression.

Requires/EnsuresContains will throw an ArgumentNullException if the target substring
is null.

**Examples:**
```C#
var customMessageTemplate = "{ValueExpression} must contain target substring";
var customExceptionFactory = new CustomExceptionFactory();

var value = "This is a test. This is only a test";
var target = "ONLY";
var comparisionType = StringComparison.OrdinalIgnoreCase;


// Precondition with default comparisionType, default message template and default exception factory.
value.RequiresContains(target);

// Precondition with default comparisionType, custom message template and default exception factory.
value.RequiresContains(target, messageTemplate: customMessageTemplate);

// Precondition with default comparisionType, default message template and custom exception factory.
value.RequiresContains(target, exceptionFactory: customExceptionFactory);

// Precondition with default comparisionType, custom message template and custom exception factory.
value.RequiresContains(target, messageTemplate: customMessageTemplate, exceptionFactory: customExceptionFactory);


// Precondition with comparisionType, default message template and default exception factory.
value.RequiresContains(target, comparisionType);

// Precondition with comparisionType, custom message template and default exception factory.
value.RequiresContains(target, comparisionType, customMessageTemplate);

// Precondition with comparisionType, default message template and custom exception factory.
value.RequiresContains(target, comparisionType, exceptionFactory: customExceptionFactory);

// Precondition with comparisionType, custom message template and custom exception factory.
value.RequiresContains(target, comparisionType, customMessageTemplate, customExceptionFactory);


// Postcondition with default comparisionType, default message template and default exception factory.
value.EnsuresContains(target);

// Postcondition with default comparisionType, custom message template and default exception factory.
value.EnsuresContains(target, messageTemplate: customMessageTemplate);

// Postcondition with default comparisionType, default message template and custom exception factory.
value.EnsuresContains(target, exceptionFactory: customExceptionFactory);

// Postcondition with default comparisionType, custom message template and custom exception factory.
value.EnsuresContains(target, messageTemplate: customMessageTemplate, exceptionFactory: customExceptionFactory);


// Postcondition with comparisionType, default message template and default exception factory.
value.EnsuresContains(target, comparisionType);

// Postcondition with comparisionType, custom message template and default exception factory.
value.EnsuresContains(target, comparisionType, customMessageTemplate);

// Postcondition with comparisionType, default message template and custom exception factory.
value.EnsuresContains(target, comparisionType, exceptionFactory: customExceptionFactory);

// Postcondition with comparisionType, custom message template and custom exception factory.
value.EnsuresContains(target, comparisionType, customMessageTemplate, customExceptionFactory);
```