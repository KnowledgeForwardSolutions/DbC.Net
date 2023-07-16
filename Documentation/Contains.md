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
```