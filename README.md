# DbC.Net

## Table of Contents
- **[Introduction](#introduction)**

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

  - Initialization Requirements

    - [NotNull](/Documentation/NotNull.md)
    - [NotDefault](/Documentation/NotDefault.md)

  - Equality Requirements

    - [Equal](/Documentation/Equal.md)
    - [NotEqual](/Documentation/NotEqual.md)

    - [ApproximatelyEqual](/Documentation/ApproximatelyEqual.md)

  - Range Requirements

    - [GreaterThan](/Documentation/GreaterThan.md)
    - [GreaterThanOrEqual](/Documentation/GreaterThanOrEqual.md)
    - [GreaterThanZero](/Documentation/GreaterThanZero.md)
    - [GreaterThanOrEqualToZero](/Documentation/GreaterThanOrEqualToZero.md)
    - [LessThan](/Documentation/LessThan.md)
    - [LessThanOrEqual](/Documentation/LessThanOrEqual.md)
    - [LessThanOrEqualToZero](/Documentation/LessThanOrEqualToZero.md)
    - [LessThanZero](/Documentation/LessThanZero.md)
    - [Between](/Documentation/Between.md)

  - String Requirements

    - [AlphaNumericOnly](/Documentation/AlphaNumericOnly.md)
    - [Contains](/Documentation/Contains.md)
    - [DigitsOnly](/Documentation/DigitsOnly.md)
    - [EndsWith](/Documentation/EndsWith.md)
    - [MaxLength](/Documentation/MaxLength.md)
    - [MinLength](/Documentation/MinLength.md)
    - [NotEmptyOrWhiteSpace](/Documentation/NotEmptyOrWhiteSpace.md)
    - [NotNullOrEmpty](/Documentation/NotNullOrEmpty.md)
    - [NotNullOrWhiteSpace](/Documentation/NotNullOrWhiteSpace.md)
    - [StartsWith](/Documentation/StartsWith.md)

- **[Release History/Release Notes](#release-historyrelease-notes)**

	- Not currently released

- **[Benchmarks](Benchmarks.md)**

# Introduction

DbC.Net is inspired by the concept of Design by Contract, first introduced by 
Bertrand Meyer in the Eiffel programming language and also by Microsoft's Code 
Contracts (no longer supported by .NET 5 or higher). DbC.Net lets you create
robust requirements based pre-conditions and post-conditions with an expressive 
fluent syntax.

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

The static DbC.Net.ExceptionFactories.StandardExceptionFactories class has 
properties that give you access to pre-configured exception factories as lazily 
created singletons. The exception factories available are:

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

The static DbC.Net.Transforms.StandardTransforms class has properties that give 
you access to pre-configured value transforms as lazily created singletons. The 
value transforms available are:

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

# Release History/Release Notes

