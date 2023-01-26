# DbC.Net

## Table of Contents
- **[Introduction](#introduction)**

- **[Using DbC.Net](#using-dbcnet)**

  - [Exception Factories](#exception-factories)

    - [IExceptionFactory](#iexceptionfactory)
    - [ExceptionFactory](#exceptionfactory)
    - [ArgumentExceptionFactory](#argumentexceptionfactory)
    - [ArgumentNullExceptionFactory](#argumentnullexceptionfactory)
    - [ArgumentOutOfRangeExceptionFactory](#argumentoutofrangeexceptionfactory)
    - [FormatExceptionFactory](#formatexceptionfactory)
    - [InvalidOperationExceptionFactory](#invalidoperationexceptionfactory)

    - [MaskedExceptionFactory](#maskedexceptionfactory)

  - [Masking Sensitive Values](#masking-sensitive-values)

    - [IValueMasker](#ivaluemasker)
    - [CharacterMasker](#charactermasker)

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

### MaskedExceptionFactory

MaskedExceptionFactory is the abstract base class for all DbC.Net exception
factories that mask sensitive data in the produced exception. It is derived from 
ExceptionFactory and adds a method to process the exception data dictionary and
mask any values considered sensitive. The constructor for MaskedExceptionFactory
accepts an instance of IValueMasker to perform the masking and a list of keys
for values that are considered sensitive.

## Masking Sensitive Values

Modern applications deal with a wide range of sensitive information such as
passwords, account/credit card numbers, Protected Health Information (PHI) and 
more. It is important to protect that information from accidental exposure by 
including it in error messages or writing it to logs. DbC.Net allows you to
protect sensitive information by masking it.  All of the masked exception 
factories support using an IValueMasker to protect items that you want to protect.
DbC.Net provides a number of implementations of IValueMasker for you to choose 
from and you are also able to implement your own value masker.

### IValueMasker

The IValueMasker interface defines an object used to mask sensitive values. The 
interface has a single method, MaskValue which accepts an Object value and returns
a masked String value.

```C#
public interface IValueMasker
{
   String MaskValue(Object value);
}
```

### CharacterMasker

CharacterMasker masks a sensitive value by converting the value to a string and
then converting all characters in the string to the mask character. The mask 
character can be set when a new instance of CharacterMasker is created.

# Release History/Release Notes


