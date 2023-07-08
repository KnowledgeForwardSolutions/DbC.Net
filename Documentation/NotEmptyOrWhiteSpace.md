### NotEmptyOrWhiteSpace

NotEmptyOrWhiteSpace requires that the string value being checked not be String.Empty 
or all whitespace characters. Null is allowed.

Use NotEmptyOrWhiteSpace where a string may be completed uninitialized (null) or
if initialized may not be empty.

**Method signatures:**
```C#
String RequiresNotEmptyOrWhiteSpace(this String value, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null])

String EnsuresNotEmptyOrWhiteSpace(this String value, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null])
```

The default message template for NotEmptyOrWhiteSpace is "{RequirementType} {RequirementName} failed: {ValueExpression} may not be String.Empty or all whitespace characters".
The default exception factory for RequiresNotEmptyOrWhiteSpace is StandardExceptionFactories.ArgumentNullExceptionFactory 
and StandardExceptionFactories.PostconditionFailedExceptionFactory for 
EnsuresNotEmptyOrWhiteSpace.

The data dictionary for exceptions thrown will contain entries for RequirementType,
RequirementName, Value and ValueExpression.

**Examples:**
```C#
```