# DbC.Net

## Table of Contents
- **[Introduction](#introduction)**

[Link Example](/Documentation/Example.md)

- **[Using DbC.Net](#using-dbcnet)**

  - [Exception Factories](#exception-factories)

    - [Data Dictionary](#data-dictionary)

    - [Message Templates](#message-templates)

    - [IExceptionFactory](#iexceptionfactory)
    - [ExceptionFactoryBase](#exceptionfactorybase)
    - [ArgumentExceptionFactory](#argumentexceptionfactory)
    - [ArgumentNullExceptionFactory](#argumentnullexceptionfactory)
    - [ArgumentOutOfRangeExceptionFactory](#argumentoutofrangeexceptionfactory)
    - [FormatExceptionFactory](#formatexceptionfactory)
    - [InvalidOperationExceptionFactory](#invalidoperationexceptionfactory)
    - [NotSupportedExceptionFactory](#notsupportedexceptionfactory)
    - [PostconditionFailedExceptionFactory](#postconditionfailedexceptionfactory)

    - [Implementing an ExceptionFactory](#implementing-an-exceptionfactory)

    - [StandardExceptionFactories](#standardexceptionfactories)

  - [Value Transforms](#value-transforms)

    - [StandardTransforms](#standardtransforms)

  - [Initialization Requirements](#initialization-requirements)

    - [NotNull](#notnull)
    - [NotDefault](#notdefault)

  - [Equality Requirements](#equality-requirements)

    - [Equal](#equal)

- **[Release History/Release Notes](#release-historyrelease-notes)**

	- Not currently released

- **[Benchmarks](Benchmarks.md)**

# Introduction

DbC.Net is inspired by the concept of Design by Contract, first introduced by 
Bertrand Meyer in the Eiffel programming language and also by Microsoft's Code 
Contracts (no longer supported by .NET 5 or higher). DbC.Net lets you create
robust requirements based pre- and post-conditions with an expressive fluent
syntax.

# Using DbC.Net

## Exception Factories

DbC.Net uses exception factories to create the exception that is thrown when a
requirement is not met. DbC.Net provides a variety of standard exception 
factories as lazily created singletons in the [StandardExceptionFactories](#standardexceptionfactories) class.
You can create your own exception factory by creating a class that implements 
IExceptionFactory. All DbC.Net provided exception factories are derived from the
abstract class ExceptionFactoryBase and you may derive your own exception
factories from ExceptionFactoryBase if you like.

### Data Dictionary

DbC.Net exception factories have several important features: data dictionaries,
message templates and value transforms. The CreateException method of 
IExceptionFactory accepts a data parameter of type Dictionary<String, Object>.
ExceptionFactoryBase uses that dictionary to populate the Data property of the 
created exception and is also to build the exception method from the message 
template. Each DbC.Net Requires.../Ensures... fills the data dictionary with
values related to the failed requirement before invoking CreateException. See
the individual Requires.../Ensures... method documentation for the values that 
are added to the data dictionary. The keys used for entries in the data dictionary
are constants available in the DataNames class.

### Message Templates

The CreateException method of IExceptionFactory also accepts a string message
template parameter. ExceptionFactoryBase uses the data dictionary and the message
template to create the final error message by replacing placeholders in the
message template with values from the data dictionary. Placeholders are delimited
by curly braces (example: {Value}). ExceptionFactoryBase will walk the entries in
the data dictionary and replace any placeholder in the message template that 
matches the key of a data dictionary item with that item's value.

If you create your own exception factory by deriving from ExceptionFactoryBase
you will have message template handling and value transforms available as methods
that you can use in your implementation of CreateException.

### IExceptionFactory

The IExceptionFactory interface defines an exception factory object. The interface
has a single method, CreateException. It has two parameters, a message template 
and a dictionary of values to include in the created exception's Data dictionary 
and returns a new Exception.

```C#
public interface IExceptionFactory
{
   Exception CreateException(String messageTemplate, Dictionary<String, Object> data);
}
```
The message template can contain placeholders (delimited by open and close braces)
which will correspond to the keys of some of the items in the data dictionary.
The message template and the data dictionary are used to construct the error 
message included in the new exception by replacing placeholders in the message 
template with corresponding values from the dictionary.

```C#
private readonly Dictionary<String, Object> _data = new() {
   { "RequirementType", RequirementType.Precondition },
   { "RequirementName", "GreaterThan" },
   { "Value", 99.9 },
   { "ValueExpression", "sum" },
   { "Limit", 100.0 },
   { "LimitExpression", "lowerBound" } };

var messageTemplate = "{RequirementType} {RequirementName} failed: value ({Value}) is not greater than {Limit}";
```
The resulting error message would be "Precondition GreaterThan failed: value (99.9) is not greater than 100";

Refer to the individual Requires.../Ensures... methods for the values that are 
included in the data dictionary that is passed to the exception factory when the
method throws an exception because the requirement was failed.

### ExceptionFactoryBase

ExceptionFactoryBase is the abstract base class for all DbC.Net exception factories.
It provides methods for performing the placeholder substitution for message
templates and for extracting a parameter name from the "ValueExpression" data
dictionary entry.

### ArgumentExceptionFactory

Use ArgumentExceptionFactory to create ArgumentExceptions. ArgumentExceptionFactory
expects the exception data dictionary to contain an entry for DataNames.ValueExpression.

### ArgumentNullExceptionFactory

Use ArgumentNullExceptionFactory to create ArgumentNullExceptions. ArgumentNullExceptionFactory
expects the exception data dictionary to contain an entry for DataNames.ValueExpression.

### ArgumentOutOfRangeExceptionFactory

Use ArgumentOutOfRangeExceptionFactory to create ArgumentOutOfRangeExceptions. 
ArgumentOutOfRangeExceptionFactory expects the exception data dictionary to contain
entries for DataNames.Value and DataNames.ValueExpression.

### FormatExceptionFactory

Use FormatExceptionFactory to create FormatExceptions. FormatExceptionFactory
does not expect any specific entries in the exception data dictionary.

### InvalidOperationExceptionFactory

Use InvalidOperationExceptionFactory to create InvalidOperationExceptions. 
InvalidOperationExceptionFactory does not expect any specific entries in the 
exception data dictionary.

### NotSupportedExceptionFactory

Use NotSupportedExceptionFactory to create NotSupportedExceptions. 
NotSupportedExceptionFactory does not expect any specific entries in the 
exception data dictionary.

### PostconditionFailedExceptionFactory

Use PostconditionFailedExceptionFactory to create PostconditionFailedExceptions. 
PostconditionFailedExceptionFactory does not expect any specific entries in the 
exception data dictionary.

### StandardExceptionFactories

The static StandardExceptionFactories class has properties that give you access
to pre-configured exception factories as lazily created singletons. The exception
factories available are:

- ArgumentExceptionFactory - an instance of [ArgumentExceptionFactory](#argumentexceptionfactory)
that does not use any value transforms.

- ArgumentNullExceptionFactory - an instance of [ArgumentNullExceptionFactory](#argumentnullexceptionfactory)
that does not use any value transforms.

- ArgumentOutOfRangeExceptionFactory - an instance of [ArgumentOutOfRangeExceptionFactory](#argumentoutofrangeexceptionfactory)
that does not use any value transforms.

- FormatExceptionFactory - an instance of [FormatExceptionFactory](#formatexceptionfactory)
that does not use any value transforms.

- InvalidOperationExceptionFactory - an instance of [InvalidOperationExceptionFactory](#invalidoperationexceptionfactory)
that does not use any value transforms.

- NotSupportedExceptionFactory - an instance of [NotSupportedExceptionFactory](#notsupportedexceptionfactory)
that does not use any value transforms.

- PostconditionFailedExceptionFactory - an instance of [PostconditionFailedExceptionFactory](#postconditionfailedexceptionfactory)
that does not use any value transforms.

- SecureArgumentExceptionFactory - an instance of [ArgumentExceptionFactory](#argumentexceptionfactory)
that includes a value transform on the Value data dictionary entry that masks the
value with all asterisk characters ('*').

- SecureArgumentOutOfRangeExceptionFactory - an instance of [ArgumentOutOfRangeExceptionFactory](#argumentoutofrangeexceptionfactory)
that includes a value transform on the Value data dictionary entry that masks the
value with all asterisk characters ('*').

- SecureInvalidOperationExceptionFactory - an instance of [InvalidOperationExceptionFactory](#invalidoperationexceptionfactory)
that includes a value transform on the Value data dictionary entry that masks the
value with all asterisk characters ('*').

- SecureNotSupportedExceptionFactory - an instance of [NotSupportedExceptionFactory](#notsupportedexceptionfactory)
that includes a value transform on the Value data dictionary entry that masks the
value with all asterisk characters ('*').

- SecurePostconditionFailedExceptionFactory - an instance of [PostconditionFailedExceptionFactory](#postconditionfailedexceptionfactory)
that includes a value transform on the Value data dictionary entry that masks the
value with all asterisk characters ('*').

### Implementing an ExceptionFactory

example here...

## Value Transforms

DbC.Net exception factories use value transforms for several reasons, primarily 
to prevent sensitive data from being exposed in error messages and log entries
as well as to prevent filling logs with unnecessarily large amounts of data. 
Dbc.Net value transforms implement IValueTransform and use the Decorator Pattern
to extend basic transforms with additional features. DbC.Net provides a variety
of standard value transforms in the [StandardTransforms](#standardtransforms)
class. Value transforms do not affect the value being checked, they are only used
to transform a value that will be included in the exception being created.

Why should you mask values when the value in question is invalid? One reason is 
that while the value may not meet all the requirements for a domain entity or 
value object, the invalid data may be partially correct and contain sufficient
information for a bad actor to fully compromise the information. For example, an
account number or credit card number that fails a check digit requirement. If a
bad actor knows that a value is invalid but also knows that the value only has a 
single incorrect digit or two transposed digits, they have a significant advantage 
to determining the actual value.

### StandardTransforms

The static StandardTransforms class has properties that give you access to 
pre-configured value transforms as lazily created singletons. The value transforms
available are:

- AsteriskMaskTransform - a transform that converts a value to a string and then 
replaces all characters in the string with an asterisk character ('*').

- DigitAsteriskMaskTransform - a transform converts a value to a string and then 
replaces all decimal digit characters (0-9) in the string with an asterisk character 
('*').

- FixedLengthTransform - a transform converts a value to a string exactly eight
characters in length, by truncating values longer than eight characters and
padding shorter values with space characters (' ').

- NullTransform - a transform that returns the original value unaltered. Use this
transform as the base for other transform decorators.

- PhiSensitiveTranform - a transform that always returns the string "PHI Sensitive Value".
Use this transform to mask PHI (Protected Health Information) from accidental exposure.

## Initialization Requirements

### NotNull

NotNull requires that the value being checked not be null. Use RequiresNotNull
for preconditions and EnsuresNotNull for postconditions.

Method signatures:
```C#
T RequiresNotNull<T>(this T value, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null])

T EnsuresNotNull<T>(this T value, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null])
```

The default message template for NotNull is "{RequirementType} {RequirementName} failed: {ValueExpression} may not be null".
The default exception factory for RequiresNotNull is StandardExceptionFactories.ArgumentNullExceptionFactory 
and StandardExceptionFactories.PostconditionFailedExceptionFactory for 
EnsuresNotNull.

The data dictionary for exceptions thrown will contain entries for RequirementType,
RequirementName and ValueExpression.

Examples:
```C#
var customMessageTemplate = "{ValueExpression} can not be null";
var customExceptionFactory = new CustomExceptionFactory();

String lastName = null!;

List<Guid> identifiers = null!;

// Precondition with default message template/default exception factory.
lastName.RequiresNotNull();

// Precondition with custom message template/default exception factory.
lastName.RequiresNotNull(customMessageTemplate);

// Precondition with default message template/custom exception factory.
lastName.RequiresNotNull(exceptionFactory: customExceptionFactory);

// Precondition with custom message template/custom exception factory.
lastName.RequiresNotNull(customMessageTemplate, customExceptionFactory);


// Postcondition with default message template/default exception factory.
identifiers.EnsuresNotNull();

// Postcondition with custom message template/default exception factory.
identifiers.EnsuresNotNull(customMessageTemplate);

// Postcondition with default message template/custom exception factory.
identifiers.EnsuresNotNull(exceptionFactory: customExceptionFactory);

// Postcondition with custom message template/custom exception factory.
identifiers.EnsuresNotNull(customMessageTemplate, customExceptionFactory);
```

### NotDefault

NotDefault requires that the value being checked not be the default for the 
datatype of the value being checked (zero for value types, null for reference
types). Use RequiresNotDefault for preconditions and EnsuresNotDefault for 
postconditions.

Method signatures:
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

Examples:
```C#
var customMessageTemplate = "{ValueExpression} can not be default";
var customExceptionFactory = new CustomExceptionFactory();

Int64 id = default;

List<Guid> identifiers = default!;

// Precondition with default message template/default exception factory.
id.RequiresNotDefault();

// Precondition with custom message template/default exception factory.
id.RequiresNotDefault(customMessageTemplate);

// Precondition with default message template/custom exception factory.
id.RequiresNotDefault(exceptionFactory: customExceptionFactory);

// Precondition with custom message template/custom exception factory.
id.RequiresNotDefault(customMessageTemplate, customExceptionFactory);


// Postcondition with default message template/default exception factory.
identifiers.EnsuresNotDefault();

// Postcondition with custom message template/default exception factory.
identifiers.EnsuresNotDefault(customMessageTemplate);

// Postcondition with default message template/custom exception factory.
identifiers.EnsuresNotDefault(exceptionFactory: customExceptionFactory);

// Postcondition with custom message template/custom exception factory.
identifiers.EnsuresNotDefault(customMessageTemplate, customExceptionFactory);
```

## Equality Requirements

### Equal

Equal requires that the value being checked is equal to a target value. RequiresEqual
and EnsuresEqual have several overloads that support IEquatable<T> and
IEqualtiyComparer<T> as well as an overload for String that accepts a 
StringComparison value that specifies how the comparison is performed.

Method signatures:
```C#
T RequiresEqual<T>(this T value, T target, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null]) where T : IEquatable<T>

T RequiresEqual<T>(this T value, T target, IEqualityComparer<T> comparer, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null])

String RequiresEqual<T>(this String value, String target, StringComparison comparisonType, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null])

T EnsuresEqual<T>(this T value, T target, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null]) where T : IEquatable<T>

T EnsuresEqual<T>(this T value, T target, IEqualityComparer<T> comparer, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null])

String EnsuresEqual<T>(this String value, String target, StringComparison comparisonType, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null], [String? targetExpression = null])
```

The default message template for Equal is "{RequirementType} {RequirementName} failed: {ValueExpression} must be equal to {Target}".
The default exception factory for RequiresEqual is StandardExceptionFactories.ArgumentExceptionFactory
and StandardExceptionFactories.PostconditionFailedExceptionFactory for 
EnsuresEqual.

The data dictionary for exceptions thrown will contain entries for RequirementType,
RequirementName, Value, ValueExpression, Target and TargetExpression. The data
dictionary for the String overloads will contain an additional entry for 
StringComparison.

Examples:
```C#
public record Box(Int32 Height, Int32 Length, Int32 Width)
{
    public Int32 Volume => Height * Length * Width;
}

public class BoxVolumeComparer : IEqualityComparer<Box>
{
    public Boolean Equals(Box? x, Box? y)
    {
        if (x is null && y is null) return true;
        else if (x is null|| y is null) return false;
         
        return x!.Volume.Equals(y!.Volume);
    }

    public Int32 GetHashCode([DisallowNull] Box obj) => obj.Volume.GetHashCode();
}

var customMessageTemplate = "{ValueExpression} must be equal to {Target}";
var customExceptionFactory = new CustomExceptionFactory();

var totalCount = 99;
var targetCount = 100;

// Precondition with default message template/default exception factory.
totalCount.RequiresEqual(targetCount);

// Precondition with custom message template/default exception factory.
totalCount.RequiresEqual(targetCount, customMessageTemplate);

// Precondition with default message template/custom exception factory.
totalCount.RequiresEqual(targetCount, exceptionFactory: customExceptionFactory);

// Precondition with custom message template/custom exception factory.
totalCount.RequiresEqual(targetCount, customMessageTemplate, customExceptionFactory);


// Postcondition with default message template/default exception factory.
totalCount.EnsuresEqual(targetCount);

// Postcondition with custom message template/default exception factory.
totalCount.EnsuresEqual(targetCount, customMessageTemplate);

// Postcondition with default message template/custom exception factory.
totalCount.EnsuresEqual(targetCount, exceptionFactory: customExceptionFactory);

// Postcondition with custom message template/custom exception factory.
totalCount.EnsuresEqual(targetCount, customMessageTemplate, customExceptionFactory);


var box = new Box(1, 2, 3);
var targetBox = new Box(2, 2, 2);
var comparer = new BoxVolumeComparer();

// Precondition with default message template/default exception factory.
box.RequiresEqual(targetBox, comparer);

// Precondition with custom message template/default exception factory.
box.RequiresEqual(targetBox, comparer, customMessageTemplate);

// Precondition with default message template/custom exception factory.
box.RequiresEqual(targetBox, comparer, exceptionFactory: customExceptionFactory);

// Precondition with custom message template/custom exception factory.
box.RequiresEqual(targetBox, comparer, customMessageTemplate, customExceptionFactory);


// Postcondition with default message template/default exception factory.
box.EnsuresEqual(targetBox, comparer);

// Postcondition with custom message template/default exception factory.
box.EnsuresEqual(targetBox, comparer, customMessageTemplate);

// Postcondition with default message template/custom exception factory.
box.EnsuresEqual(targetBox, comparer, exceptionFactory: customExceptionFactory);

// Postcondition with custom message template/custom exception factory.
box.EnsuresEqual(targetBox, comparer, customMessageTemplate, customExceptionFactory);


var str = "asdf";
var targetStr = "QWERTY";
var comparisonType = StringComparison.OrdinalIgnoreCase;

// Precondition with default message template/default exception factory.
str.RequiresEqual(targetStr, comparisonType);

// Precondition with custom message template/default exception factory.
str.RequiresEqual(targetStr, comparisonType, customMessageTemplate);

// Precondition with default message template/custom exception factory.
str.RequiresEqual(targetStr, comparisonType, exceptionFactory: customExceptionFactory);

// Precondition with custom message template/custom exception factory.
str.RequiresEqual(targetStr, comparisonType, customMessageTemplate, customExceptionFactory);


// Postcondition with default message template/default exception factory.
str.EnsuresEqual(targetStr, comparisonType);

// Postcondition with custom message template/default exception factory.
str.EnsuresEqual(targetStr, comparisonType, customMessageTemplate);

// Postcondition with default message template/custom exception factory.
str.EnsuresEqual(targetStr, comparisonType, exceptionFactory: customExceptionFactory);

// Postcondition with custom message template/custom exception factory.
str.EnsuresEqual(targetStr, comparisonType, customMessageTemplate, customExceptionFactory);
```

# Release History/Release Notes

