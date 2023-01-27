# DbC.Net

## Table of Contents
- **[Introduction](#introduction)**

- **[Using DbC.Net](#using-dbcnet)**

  - [Exception Factories](#exception-factories)

    - [Data Dictionary](#data-dictionary)

    - [Message Templates](#message-templates)

    - [Value Transforms](#value-transforms)

    - [IExceptionFactory](#iexceptionfactory)
    - [ExceptionFactory](#exceptionfactory)
    - [ArgumentExceptionFactory](#argumentexceptionfactory)
    - [ArgumentNullExceptionFactory](#argumentnullexceptionfactory)
    - [ArgumentOutOfRangeExceptionFactory](#argumentoutofrangeexceptionfactory)
    - [FormatExceptionFactory](#formatexceptionfactory)
    - [InvalidOperationExceptionFactory](#invalidoperationexceptionfactory)
    - [NotSupportedExceptionFactory](#notsupportedexceptionfactory)

    - [Implementing an ExceptionFactory](#implementing-an-exceptionfactory)

- [Release History/Release Notes](#release-historyrelease-notes)

	- Not currently released

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
factories as lazily created singletons in the StandardExceptionFactories class.
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

### Value Transforms

DbC.Net exception factories use value transforms for several reasons, primarily 
to prevent sensitive data from being exposed in error messages and log entries
as well as to prevent filling logs with unnecessarily large amounts of data. 
Dbc.Net value transforms implement IValueTransform and use the Decorator Pattern
to extend basic transforms with additional features. DbC.Net provides a variety
of standard value transforms as lazily created singletons in the StandardTransforms
class. Value transforms do not affect the value being checked, they are only used
to transform a value that will be included in the exception being created.

If you create your own exception factory by deriving from ExceptionFactoryBase
you will have message template handling and value transforms available as methods
that you can use in your implementation of CreateException.



DbC.Net provides a number of exception factory classes for creating common 
exceptions and you are also able to implement your own factory class.

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

### ExceptionFactory

ExceptionFactory is the abstract base class for all DbC.Net exception factories.
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

Use NotSupportedExceptionFactory to create NotSupportedException. 
NotSupportedExceptionFactory does not expect any specific entries in the 
exception data dictionary.

### Implementing an ExceptionFactory

MaskedExceptionFactory is the abstract base class for all DbC.Net exception
factories that mask sensitive data in the produced exception. It is derived from 
ExceptionFactory and adds a method to process the exception data dictionary and
mask any values considered sensitive. The constructor for MaskedExceptionFactory
accepts an instance of IValueMasker to perform the masking and a list of keys
for values that are considered sensitive.

# Release History/Release Notes


