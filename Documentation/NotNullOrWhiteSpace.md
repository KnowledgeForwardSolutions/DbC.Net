### NotNullOrWhiteSpace

NotNullOrWhiteSpace requires that the string value being checked not be null, 
String.Empty or all whitespace characters.

**Method signatures:**
```C#
String RequiresNotNullOrWhiteSpace(this String value, [String? messageTemplate = null], [IExceptionFactory? nullExceptionFactory = null], [IExceptionFactory? emptyExceptionFactory = null], [String? valueExpression = null])

String EnsuresNotNullOrWhiteSpace(this String value, [String? messageTemplate = null], [IExceptionFactory? nullExceptionFactory = null], [IExceptionFactory? emptyExceptionFactory = null], [String? valueExpression = null])
```

The default message template for NotNullOrWhiteSpace is "{RequirementType} {RequirementName} failed: {ValueExpression} may not be null String.Empty or all whitespace characters".
Requires/EnsuresNotNullOrWhiteSpace use two exception factories, one for exceptions
thrown when the value being checked is null and one for exceptions thrown when
the value being checked is empty or all whitespace characters. The default exception 
factories for RequiresNotNullOrWhiteSpace are
StandardExceptionFactories.ArgumentNullExceptionFactory and 
StandardExceptionFactories.ArgumentExceptionFactory. EnsuresNotNullOrWhiteSpace uses
StandardExceptionFactories.PostconditionFailedExceptionFactory as the default for
both null and empty values.

The data dictionary for exceptions thrown will contain entries for RequirementType,
RequirementName, Value and ValueExpression.

**Examples:**
```C#
var customMessageTemplate = "{ValueExpression} must have a non-null/non-empty/non-whitespace value";
var customExceptionFactory = new CustomExceptionFactory();

var value = String.Empty;

// Precondition with default message template and default exception factories.
value.RequiresNotNullOrWhiteSpace();

// Precondition with custom message template and default exception factories.
value.RequiresNotNullOrWhiteSpace(customMessageTemplate);

// Precondition with default message template and custom null value exception factory.
value.RequiresNotNullOrWhiteSpace(nullExceptionFactory: customExceptionFactory);

// Precondition with default message template and custom empty value exception factory.
value.RequiresNotNullOrWhiteSpace(emptyExceptionFactory: customExceptionFactory);

// Precondition with custom message template and custom exception factories.
value.RequiresNotNullOrWhiteSpace(customMessageTemplate, customExceptionFactory, customExceptionFactory);


// Postcondition with default message template and default exception factories.
value.EnsuresNotNullOrWhiteSpace();

// Postcondition with custom message template and default exception factories.
value.EnsuresNotNullOrWhiteSpace(customMessageTemplate);

// Postcondition with default message template and custom null value exception factory.
value.EnsuresNotNullOrWhiteSpace(nullExceptionFactory: customExceptionFactory);

// Postcondition with default message template and custom empty value exception factory.
value.EnsuresNotNullOrWhiteSpace(emptyExceptionFactory: customExceptionFactory);

// Postcondition with custom message template and custom exception factories.
value.EnsuresNotNullOrWhiteSpace(customMessageTemplate, customExceptionFactory, customExceptionFactory);
```