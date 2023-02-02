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

    - [StandardExceptionFactories](#standardexceptionfactories)

  - [Value Transforms](#value-transforms)

    - [StandardTransforms](#standardtransforms)

    - [Implementing an ExceptionFactory](#implementing-an-exceptionfactory)

  - [Initialization Requirements](#initialization-requirements)

    - [NotNull](#notnull)
    - [NotDefault](#notdefault)

- **[Release History/Release Notes](#release-historyrelease-notes)**

	- Not currently released

- **[Performance Data](#performance-data)**

  - [NotNull Benchmarks](#notnull-benchmarks)
  - [NotDefault Benchmarks](#notdefault-benchmarks)

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

### Implementing an ExceptionFactory

example here...

## Initialization Requirements

### NotNull

NotNull requires that the value being checked not be null. Use RequiresNotNull
for preconditions and EnsuresNotNull for postconditions.

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

# Release History/Release Notes


# Performance Data

Benchmark details

``` ini

BenchmarkDotNet=v0.13.4, OS=Windows 11 (10.0.22621.1105)
Intel Core i7-8700K CPU 3.70GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2


```

### NotNull Benchmarks

X indicates that the optional parameter was supplied; blank indicates that the 
parameter was omitted.

| Method          | Value Type  | Message Template | Exception Factory |      Mean |     Error |    StdDev |    Median | Allocated |
|:--------------- |:------------|:----------------:|:-----------------:|----------:|----------:|----------:|----------:|----------:|
| RequiresNotNull | Int32       |                  |                   | 0.0127 ns | 0.0168 ns | 0.0157 ns | 0.0056 ns |         - |
| RequiresNotNull | Int32       | X                |                   | 0.0040 ns | 0.0062 ns | 0.0058 ns | 0.0000 ns |         - |
| RequiresNotNull | Int32       |                  | X                 | 1.1554 ns | 0.0261 ns | 0.0244 ns | 1.1442 ns |         - |
| RequiresNotNull | Int32       | X                | X                 | 1.1624 ns | 0.0248 ns | 0.0207 ns | 1.1623 ns |         - |
| RequiresNotNull | String      |                  |                   | 0.0033 ns | 0.0049 ns | 0.0043 ns | 0.0008 ns |         - |
| RequiresNotNull | String      | X                |                   | 0.0008 ns | 0.0023 ns | 0.0019 ns | 0.0000 ns |         - |
| RequiresNotNull | String      |                  | X                 | 1.7635 ns | 0.0201 ns | 0.0168 ns | 1.7626 ns |         - |
| RequiresNotNull | String      | X                | X                 | 2.2459 ns | 0.0288 ns | 0.0269 ns | 2.2467 ns |         - |
| RequiresNotNull | List<T>     |                  |                   | 0.0064 ns | 0.0074 ns | 0.0070 ns | 0.0054 ns |         - |
| RequiresNotNull | List<T>     | X                |                   | 0.0012 ns | 0.0025 ns | 0.0023 ns | 0.0000 ns |         - |
| RequiresNotNull | List<T>     |                  | X                 | 1.7117 ns | 0.0305 ns | 0.0285 ns | 1.7042 ns |         - |
| RequiresNotNull | List<T>     | X                | X                 | 2.4327 ns | 0.0197 ns | 0.0175 ns | 2.4263 ns |         - |
| *************** | *********** | **************** | ***************** | ********* | ********* | ********* | ********* | ********* |
| EnsuresNotNull  | Int32       |                  |                   | 0.0013 ns | 0.0030 ns | 0.0025 ns | 0.0000 ns |         - |
| EnsuresNotNull  | Int32       | X                |                   | 0.0038 ns | 0.0059 ns | 0.0055 ns | 0.0015 ns |         - |
| EnsuresNotNull  | Int32       |                  | X                 | 1.1545 ns | 0.0096 ns | 0.0090 ns | 1.1547 ns |         - |
| EnsuresNotNull  | Int32       | X                | X                 | 1.1586 ns | 0.0111 ns | 0.0104 ns | 1.1562 ns |         - |
| EnsuresNotNull  | String      |                  |                   | 0.0040 ns | 0.0057 ns | 0.0053 ns | 0.0023 ns |         - |
| EnsuresNotNull  | String      | X                |                   | 0.0042 ns | 0.0073 ns | 0.0065 ns | 0.0009 ns |         - |
| EnsuresNotNull  | String      |                  | X                 | 1.8425 ns | 0.0131 ns | 0.0116 ns | 1.8397 ns |         - |
| EnsuresNotNull  | String      | X                | X                 | 2.0406 ns | 0.0271 ns | 0.0253 ns | 2.0303 ns |         - |
| EnsuresNotNull  | List<T>     |                  |                   | 0.0030 ns | 0.0061 ns | 0.0051 ns | 0.0000 ns |         - |
| EnsuresNotNull  | List<T>     | X                |                   | 0.0005 ns | 0.0014 ns | 0.0013 ns | 0.0000 ns |         - |
| EnsuresNotNull  | List<T>     |                  | X                 | 1.8339 ns | 0.0122 ns | 0.0102 ns | 1.8344 ns |         - |
| EnsuresNotNull  | List<T>     | X                | X                 | 1.5898 ns | 0.0128 ns | 0.0107 ns | 1.5866 ns |         - |

### NotDefault Benchmarks

RequiresNotDefault and EnsuresNotDefault use EqualityComparer<T>.Default.Equals to test if a value is default.

X indicates that the optional parameter was supplied; blank indicates that the 
parameter was omitted.

|  Method            | Value Type  | Message Template | Exception Factory |     Mean |     Error |    StdDev | Allocated |
|:------------------ |:------------|:----------------:|:-----------------:|---------:|----------:|----------:|----------:|
| RequiresNotDefault | Int32       |                  |                   | 1.460 ns | 0.0184 ns | 0.0154 ns |         - |
| RequiresNotDefault | Int32       | X                |                   | 1.515 ns | 0.0259 ns | 0.0242 ns |         - |
| RequiresNotDefault | Int32       |                  | X                 | 1.581 ns | 0.0229 ns | 0.0215 ns |         - |
| RequiresNotDefault | Int32       | X                | X                 | 1.370 ns | 0.0248 ns | 0.0194 ns |         - |
| RequiresNotDefault | String      |                  |                   | 7.902 ns | 0.1122 ns | 0.1049 ns |         - |
| RequiresNotDefault | String      | X                |                   | 7.632 ns | 0.0346 ns | 0.0307 ns |         - |
| RequiresNotDefault | String      |                  | X                 | 7.598 ns | 0.0387 ns | 0.0323 ns |         - |
| RequiresNotDefault | String      | X                | X                 | 7.563 ns | 0.0460 ns | 0.0384 ns |         - |
| RequiresNotDefault | List<T>     |                  |                   | 7.564 ns | 0.0678 ns | 0.0634 ns |         - |
| RequiresNotDefault | List<T>     | X                |                   | 7.372 ns | 0.0254 ns | 0.0199 ns |         - |
| RequiresNotDefault | List<T>     |                  | X                 | 6.882 ns | 0.0588 ns | 0.0550 ns |         - |
| RequiresNotDefault | List<T>     | X                | X                 | 7.361 ns | 0.0356 ns | 0.0297 ns |         - |
| ****************** | *********** | **************** | ***************** | ******** | ********* | ********* | ********* |
| EnsuresNotDefault  | Int32       |                  |                   | 1.389 ns | 0.0150 ns | 0.0133 ns |         - |
| EnsuresNotDefault  | Int32       | X                |                   | 1.512 ns | 0.0239 ns | 0.0224 ns |         - |
| EnsuresNotDefault  | Int32       |                  | X                 | 1.462 ns | 0.0161 ns | 0.0143 ns |         - |
| EnsuresNotDefault  | Int32       | X                | X                 | 1.557 ns | 0.0313 ns | 0.0293 ns |         - |
| EnsuresNotDefault  | String      |                  |                   | 7.184 ns | 0.0619 ns | 0.0517 ns |         - |
| EnsuresNotDefault  | String      | X                |                   | 8.361 ns | 0.0642 ns | 0.0570 ns |         - |
| EnsuresNotDefault  | String      |                  | X                 | 7.085 ns | 0.0355 ns | 0.0315 ns |         - |
| EnsuresNotDefault  | String      | X                | X                 | 7.314 ns | 0.0751 ns | 0.0666 ns |         - |
| EnsuresNotDefault  | List<T>     |                  |                   | 7.529 ns | 0.0445 ns | 0.0347 ns |         - |
| EnsuresNotDefault  | List<T>     | X                |                   | 6.994 ns | 0.0691 ns | 0.0612 ns |         - |
| EnsuresNotDefault  | List<T>     |                  | X                 | 6.906 ns | 0.0354 ns | 0.0295 ns |         - |
| EnsuresNotDefault  | List<T>     | X                | X                 | 6.999 ns | 0.0480 ns | 0.0449 ns |         - |
