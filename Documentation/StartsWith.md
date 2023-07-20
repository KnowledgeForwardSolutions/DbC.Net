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
```