### RegexMatch

RegexMatch requires that the string value match the supplied regular expression.
RegexMatch has overloads that accept a string regular expression or a pre-built
```Regex``` object.

**Method signatures:**
```C#
String RequiresRegexMatch(this String value, String regexText, [RegexOptions regexOptions = RegexOptions.None], [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null])

String RequiressRegexMatch(this String value, Regex regex, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null])

String EnsuresRegexMatch(this String value, String regexText, [RegexOptions regexOptions = RegexOptions.None], [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null])

String EnsuresRegexMatch(this String value, Regex regex, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null])
```

The default message template for RegexMatch is "{RequirementType} {RequirementName} failed: {ValueExpression} must match the regular expression: {Regex}".
The default exception factory for RequiresRegexMatch is StandardExceptionFactories.ArgumentExceptionFactory 
and StandardExceptionFactories.PostconditionFailedExceptionFactory for 
EnsuresRegexMatch.

The data dictionary for exceptions thrown will contain entries for RequirementType,
RequirementName, Value, ValueExpression, Regex, and RegexOptions.

The string overload of Requires/EnsuresRegexMatch will throw an ArgumentNullException 
if the string regex is null and an ArgumentException if the string regex is 
String.Empty or all whitespace characters. The Regex overload of Requires/EnsuresRegexMatch
will throw an ArgumentNullException if the regex parameter is null.

**NOTE:**

Benchmarks show that using a compiled or generated regex is far superior than using a
string regex (up to 2 orders of magnitude faster and no memory allocation).

**Examples:**
```C#
var customMessageTemplate = "\"{Value}\" must match regex \"{Regex}\"";
var customExceptionFactory = new CustomExceptionFactory();

var adjacentRepeatedWordRegex = @"\b(?<word>\w+)\s+(\k<word>)\b";
var emailAddressRegex = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
var ipAddressRegex = new Regex(@"^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");

var emailAddress = "abc@xyz.com";
var ipAddress = "192.168.1.32";
var adjacentWords = "One one two TWO";


// Precondition with string regex, default options, default message template and default exception factory.
emailAddress.RequiresRegexMatch(emailAddressRegex);

// Precondition with string regex, default options, custom message template and default exception factory.
emailAddress.RequiresRegexMatch(emailAddressRegex, messageTemplate: customMessageTemplate);

// Precondition with string regex, default options, default message template and custom exception factory.
emailAddress.RequiresRegexMatch(emailAddressRegex, exceptionFactory: customExceptionFactory);

// Precondition with string regex, default options, custom message template and custom exception factory.
emailAddress.RequiresRegexMatch(emailAddressRegex, messageTemplate: customMessageTemplate, exceptionFactory: customExceptionFactory);


// Precondition with string regex, options specified, default message template and default exception factory.
adjacentWords.RequiresRegexMatch(adjacentRepeatedWordRegex, RegexOptions.IgnoreCase);

// Precondition with string regex, options specified, custom message template and default exception factory.
adjacentWords.RequiresRegexMatch(adjacentRepeatedWordRegex, RegexOptions.IgnoreCase, customMessageTemplate);

// Precondition with string regex, options specified, default message template and custom exception factory.
adjacentWords.RequiresRegexMatch(adjacentRepeatedWordRegex, RegexOptions.IgnoreCase, exceptionFactory: customExceptionFactory);

// Precondition with string regex, options specified, custom message template and custom exception factory.
adjacentWords.RequiresRegexMatch(adjacentRepeatedWordRegex, RegexOptions.IgnoreCase, customMessageTemplate, customExceptionFactory);


// Precondition with regex object, default message template and default exception factory.
ipAddress.RequiresRegexMatch(ipAddressRegex);

// Precondition with regex object, custom message template and default exception factory.
ipAddress.RequiresRegexMatch(ipAddressRegex, customMessageTemplate);

// Precondition with regex object, default message template and custom exception factory.
ipAddress.RequiresRegexMatch(ipAddressRegex, exceptionFactory: customExceptionFactory);

// Precondition with regex object, custom message template and custom exception factory.
ipAddress.RequiresRegexMatch(ipAddressRegex, customMessageTemplate, customExceptionFactory);


// Postcondition with string regex, default options, default message template and default exception factory.
emailAddress.EnsuresRegexMatch(emailAddressRegex);

// Postcondition with string regex, default options, custom message template and default exception factory.
emailAddress.EnsuresRegexMatch(emailAddressRegex, messageTemplate: customMessageTemplate);

// Postcondition with string regex, default options, default message template and custom exception factory.
emailAddress.EnsuresRegexMatch(emailAddressRegex, exceptionFactory: customExceptionFactory);

// Postcondition with string regex, default options, custom message template and custom exception factory.
emailAddress.EnsuresRegexMatch(emailAddressRegex, messageTemplate: customMessageTemplate, exceptionFactory: customExceptionFactory);


// Postcondition with string regex, options specified, default message template and default exception factory.
adjacentWords.EnsuresRegexMatch(adjacentRepeatedWordRegex, RegexOptions.IgnoreCase);

// Postcondition with string regex, options specified, custom message template and default exception factory.
adjacentWords.EnsuresRegexMatch(adjacentRepeatedWordRegex, RegexOptions.IgnoreCase, customMessageTemplate);

// Postcondition with string regex, options specified, default message template and custom exception factory.
adjacentWords.EnsuresRegexMatch(adjacentRepeatedWordRegex, RegexOptions.IgnoreCase, exceptionFactory: customExceptionFactory);

// Postcondition with string regex, options specified, custom message template and custom exception factory.
adjacentWords.EnsuresRegexMatch(adjacentRepeatedWordRegex, RegexOptions.IgnoreCase, customMessageTemplate, customExceptionFactory);


// Postcondition with regex object, default message template and default exception factory.
ipAddress.EnsuresRegexMatch(ipAddressRegex);

// Postcondition with regex object, custom message template and default exception factory.
ipAddress.EnsuresRegexMatch(ipAddressRegex, customMessageTemplate);

// Postcondition with regex object, default message template and custom exception factory.
ipAddress.EnsuresRegexMatch(ipAddressRegex, exceptionFactory: customExceptionFactory);

// Postcondition with regex object, custom message template and custom exception factory.
ipAddress.EnsuresRegexMatch(ipAddressRegex, customMessageTemplate, customExceptionFactory);
```