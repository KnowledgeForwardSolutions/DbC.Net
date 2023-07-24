### EndsWith

EndsWith requires that the string value being checked end with the target substring.
EndsWith supports an optional StringComparison parameter that specifies how the 
substring check is performed. By default the check is performed using an ordinal,
case-sensitive comparison.

EndsWith will always fail if the string value being checked is null.  An empty 
target substring (String.Empty) will always pass the requirement (unless the
string being checked is null).

**Method signatures:**
```C#
String RequiresEndsWith(this String value, String target, [StringComparison comparisonType = StringComparison.Ordinal], [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null])

String EnsuresEndsWith(this String value, String target, [StringComparison comparisonType = StringComparison.Ordinal], [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null])
```

The default message template for EndsWith is "{RequirementType} {RequirementName} failed: {ValueExpression} must end with the substring "{Target}"".
The default exception factory for RequiresEndsWith is StandardExceptionFactories.ArgumentExceptionFactory 
and StandardExceptionFactories.PostconditionFailedExceptionFactory for 
EnsuresEndsWith.

The data dictionary for exceptions thrown will contain entries for RequirementType,
RequirementName, Value, Target, StringComparison, ValueExpression and TargetExpression.

Requires/EnsuresEndsWith will throw an ArgumentNullException if the target substring
is null.

**Examples:**
```C#
var customMessageTemplate = "{ValueExpression} must end with target substring";
var customExceptionFactory = new CustomExceptionFactory();

var value = "This is a test. This is only a test";
var target = "test";
var comparisionType = StringComparison.OrdinalIgnoreCase;


// Precondition with default comparisionType, default message template and default exception factory.
value.RequiresEndsWith(target);

// Precondition with default comparisionType, custom message template and default exception factory.
value.RequiresEndsWith(target, messageTemplate: customMessageTemplate);

// Precondition with default comparisionType, default message template and custom exception factory.
value.RequiresEndsWith(target, exceptionFactory: customExceptionFactory);

// Precondition with default comparisionType, custom message template and custom exception factory.
value.RequiresEndsWith(target, messageTemplate: customMessageTemplate, exceptionFactory: customExceptionFactory);


// Precondition with comparisionType, default message template and default exception factory.
value.RequiresEndsWith(target, comparisionType);

// Precondition with comparisionType, custom message template and default exception factory.
value.RequiresEndsWith(target, comparisionType, customMessageTemplate);

// Precondition with comparisionType, default message template and custom exception factory.
value.RequiresEndsWith(target, comparisionType, exceptionFactory: customExceptionFactory);

// Precondition with comparisionType, custom message template and custom exception factory.
value.RequiresEndsWith(target, comparisionType, customMessageTemplate, customExceptionFactory);


// Postcondition with default comparisionType, default message template and default exception factory.
value.EnsuresEndsWith(target);

// Postcondition with default comparisionType, custom message template and default exception factory.
value.EnsuresEndsWith(target, messageTemplate: customMessageTemplate);

// Postcondition with default comparisionType, default message template and custom exception factory.
value.EnsuresEndsWith(target, exceptionFactory: customExceptionFactory);

// Postcondition with default comparisionType, custom message template and custom exception factory.
value.EnsuresEndsWith(target, messageTemplate: customMessageTemplate, exceptionFactory: customExceptionFactory);


// Postcondition with comparisionType, default message template and default exception factory.
value.EnsuresEndsWith(target, comparisionType);

// Postcondition with comparisionType, custom message template and default exception factory.
value.EnsuresEndsWith(target, comparisionType, customMessageTemplate);

// Postcondition with comparisionType, default message template and custom exception factory.
value.EnsuresEndsWith(target, comparisionType, exceptionFactory: customExceptionFactory);

// Postcondition with comparisionType, custom message template and custom exception factory.
value.EnsuresEndsWith(target, comparisionType, customMessageTemplate, customExceptionFactory);
```