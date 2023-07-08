### NotNullOrEmpty

NotNullOrEmpty requires that the string value being checked not be null or String.Empty.

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
var customMessageTemplate = "{ValueExpression} must have a non-null/non-empty value";
var customExceptionFactory = new CustomExceptionFactory();

var value = String.Empty;

// Precondition with default message template and default exception factories.
value.RequiresNotNullOrEmpty();

// Precondition with custom message template and default exception factories.
value.RequiresNotNullOrEmpty(customMessageTemplate);

// Precondition with default message template and custom null value exception factory.
value.RequiresNotNullOrEmpty(nullExceptionFactory: customExceptionFactory);

// Precondition with default message template and custom empty value exception factory.
value.RequiresNotNullOrEmpty(emptyExceptionFactory: customExceptionFactory);

// Precondition with custom message template and custom exception factories.
value.RequiresNotNullOrEmpty(customMessageTemplate, customExceptionFactory, customExceptionFactory);


// Postcondition with default message template and default exception factories.
value.EnsuresNotNullOrEmpty();

// Postcondition with custom message template and default exception factories.
value.EnsuresNotNullOrEmpty(customMessageTemplate);

// Postcondition with default message template and custom null value exception factory.
value.EnsuresNotNullOrEmpty(nullExceptionFactory: customExceptionFactory);

// Postcondition with default message template and custom empty value exception factory.
value.EnsuresNotNullOrEmpty(emptyExceptionFactory: customExceptionFactory);

// Postcondition with custom message template and custom exception factories.
value.EnsuresNotNullOrEmpty(customMessageTemplate, customExceptionFactory, customExceptionFactory);
```