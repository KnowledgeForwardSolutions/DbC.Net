### NotNullOrEmpty

NotNull requires that the string value being checked not be null or String.Empty.

**Method signatures:**
```C#
String RequiresNotNullOrEmpty(this String value, [String? messageTemplate = null], [IExceptionFactory? nullExceptionFactory = null], [IExceptionFactory? emptyExceptionFactory = null], [String? valueExpression = null])

String EnsuresNotNullOrEmpty(this String value, [String? messageTemplate = null], [IExceptionFactory? nullExceptionFactory = null], [IExceptionFactory? emptyExceptionFactory = null], [String? valueExpression = null])
```

The default message template for NotNullOrEmpty is "{RequirementType} {RequirementName} failed: {ValueExpression} may not be null or String.Empty".
Requires/EnsuresNotNullOrEmpty use two exception factories, one for exceptions
thrown when the value being checked is null and one for exceptions thrown when
the value being checked is empty. The default exception factories for RequiresNotNullOrEmpty
are StandardExceptionFactories.ArgumentNullExceptionFactory and 
StandardExceptionFactories.ArgumentExceptionFactory. EnsuresNotNullOrEmpty uses
StandardExceptionFactories.PostconditionFailedExceptionFactory as the default for
both null and empty values.

The data dictionary for exceptions thrown will contain entries for RequirementType,
RequirementName and ValueExpression.

**Examples:**
```C#
```