### NotDefault

NotDefault requires that the value being checked not be the default for the 
datatype of the value being checked (zero for value types, null for reference
types). Use RequiresNotDefault for preconditions and EnsuresNotDefault for 
postconditions.

**Method signatures:**
```C#
T RequiresNotDefault<T>(this T value, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null])

T EnsuresNotDefault<T>(this T value, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null])
```

The default message template for NotDefault is "{RequirementType} {RequirementName} failed: {ValueExpression} may not be default({ValueDatatype})".
The default exception factory for RequiresNotDefault is StandardExceptionFactories.ArgumentExceptionFactory
and StandardExceptionFactories.PostconditionFailedExceptionFactory for 
EnsuresNotDefault.

The data dictionary for exceptions thrown will contain entries for RequirementType,
RequirementName, ValueExpression and ValueDatatype.

**Examples:**
```C#
var customMessageTemplate = "{ValueExpression} can not be default";
var customExceptionFactory = new CustomExceptionFactory();

Int64 id = default;

List<Guid> identifiers = default!;

// Precondition with default message template and default exception factory.
id.RequiresNotDefault();

// Precondition with custom message template and default exception factory.
id.RequiresNotDefault(customMessageTemplate);

// Precondition with default message template and custom exception factory.
id.RequiresNotDefault(exceptionFactory: customExceptionFactory);

// Precondition with custom message template and custom exception factory.
id.RequiresNotDefault(customMessageTemplate, customExceptionFactory);


// Postcondition with default message template and default exception factory.
identifiers.EnsuresNotDefault();

// Postcondition with custom message template and default exception factory.
identifiers.EnsuresNotDefault(customMessageTemplate);

// Postcondition with default message template and custom exception factory.
identifiers.EnsuresNotDefault(exceptionFactory: customExceptionFactory);

// Postcondition with custom message template and custom exception factory.
identifiers.EnsuresNotDefault(customMessageTemplate, customExceptionFactory);
```
