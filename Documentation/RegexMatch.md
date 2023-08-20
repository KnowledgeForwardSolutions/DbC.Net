### RegexMatch

RegexMatch requires that the string value match the supplied regular expression.

**Method signatures:**
```C#
String RequiressRegexMatch(this String value, Regex regex, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null])

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

var adjacentRepeatedWordRegex = new Regex(@"\b(?<word>\w+)\s+(\k<word>)\b", RegexOptions.IgnoreCase | RegexOptions.Compiled);
var ipAddressRegex = new Regex(@"^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$", RegexOptions.Compiled);

var ipAddress = "192.168.1.32";
var adjacentWords = "One one two TWO";


// Precondition with default message template and default exception factory.
ipAddress.RequiresRegexMatch(ipAddressRegex);

// Precondition with custom message template and default exception factory.
ipAddress.RequiresRegexMatch(ipAddressRegex, customMessageTemplate);

// Precondition with default message template and custom exception factory.
ipAddress.RequiresRegexMatch(ipAddressRegex, exceptionFactory: customExceptionFactory);

// Precondition with custom message template and custom exception factory.
ipAddress.RequiresRegexMatch(ipAddressRegex, customMessageTemplate, customExceptionFactory);


// Postcondition with default message template and default exception factory.
adjacentWords.EnsuresRegexMatch(adjacentRepeatedWordRegex);

// Postcondition with custom message template and default exception factory.
adjacentWords.EnsuresRegexMatch(adjacentRepeatedWordRegex, customMessageTemplate);

// Postcondition with default message template and custom exception factory.
adjacentWords.EnsuresRegexMatch(adjacentRepeatedWordRegex, exceptionFactory: customExceptionFactory);

// Postcondition with custom message template and custom exception factory.
adjacentWords.EnsuresRegexMatch(adjacentRepeatedWordRegex, customMessageTemplate, customExceptionFactory);
```