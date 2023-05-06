### NotNull

NotNull requires that the reference type value being checked not be null. Use 
RequiresNotNull for preconditions and EnsuresNotNull for postconditions.

**Method signatures:**
```C#
T RequiresNotNull<T>(this T value, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null]) where T : class

T EnsuresNotNull<T>(this T value, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null]) where T : class
```

The default message template for NotNull is "{RequirementType} {RequirementName} failed: {ValueExpression} may not be null".
The default exception factory for RequiresNotNull is StandardExceptionFactories.ArgumentNullExceptionFactory 
and StandardExceptionFactories.PostconditionFailedExceptionFactory for 
EnsuresNotNull.

The data dictionary for exceptions thrown will contain entries for RequirementType,
RequirementName and ValueExpression.

**Examples:**
```C#
var customMessageTemplate = "{ValueExpression} can not be null";
var customExceptionFactory = new CustomExceptionFactory();

String lastName = null!;

List<Guid> identifiers = null!;

// Precondition with default message template and default exception factory.
lastName.RequiresNotNull();

// Precondition with custom message template and default exception factory.
lastName.RequiresNotNull(customMessageTemplate);

// Precondition with default message template and custom exception factory.
lastName.RequiresNotNull(exceptionFactory: customExceptionFactory);

// Precondition with custom message template and custom exception factory.
lastName.RequiresNotNull(customMessageTemplate, customExceptionFactory);


// Postcondition with default message template and default exception factory.
identifiers.EnsuresNotNull();

// Postcondition with custom message template and default exception factory.
identifiers.EnsuresNotNull(customMessageTemplate);

// Postcondition with default message template and custom exception factory.
identifiers.EnsuresNotNull(exceptionFactory: customExceptionFactory);

// Postcondition with custom message template and custom exception factory.
identifiers.EnsuresNotNull(customMessageTemplate, customExceptionFactory);
```