### RegexMatch

RegexMatch requires that the string value match the supplied regular expression.
RegexMatch has overloads that accept a string regular expression or a pre-built
```Regex``` object.

**Method signatures:**
```C#
String RequiresRegexMatch(this String value, String regexText, [RegexOptions regexOptions = RegexOptions.None], [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null])

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

**Examples:**
```C#
```