### ValidCheckDigit

ValidCheckDigit requires that the string value being checked contain a valid
check digit. The check digit calculation is performed by an instance of 
ICheckDigitAlgorithm that must be passed to Requires/EnsuresValidCheckDigit.

**Method signatures:**
```C#
String RequiresValidCheckDigit(this String value, ICheckDigitAlgorithm checkDigitAlgorithm, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null])

String EnsuresValidCheckDigit(this String value, ICheckDigitAlgorithm checkDigitAlgorithm, [String? messageTemplate = null], [IExceptionFactory? exceptionFactory = null], [String? valueExpression = null])
```

The default message template for ValidCheckDigit is "{RequirementType} {RequirementName} failed: {ValueExpression} must contain a valid check digit".
The default exception factory for RequiresValidCheckDigit is StandardExceptionFactories.ArgumentExceptionFactory 
and StandardExceptionFactories.PostconditionFailedExceptionFactory for 
EnsuresValidCheckDigit.

The data dictionary for exceptions thrown will contain entries for RequirementType,
RequirementName, Value, ValueExpression and AlgorithmName.

Requires/EnsuresValidCheckDigit will throw an ArgumentNullException if the 
checkDigitAlgorithm is null.

**Examples:**
```C#
var customMessageTemplate = "{ValueExpression} has an invalid check digit";
var customExceptionFactory = new CustomExceptionFactory();
var checkDigitAlgorithm = StandardCheckDigitAlgorithms.LuhnAlgorithm;

var value = "4111111111111111";    // VISA test card number


// Precondition with default message template and default exception factory.
value.RequiresValidCheckDigit(checkDigitAlgorithm);

// Precondition with custom message template and default exception factory.
value.RequiresValidCheckDigit(checkDigitAlgorithm, customMessageTemplate);

// Precondition with default message template and custom exception factory.
value.RequiresValidCheckDigit(checkDigitAlgorithm, exceptionFactory: customExceptionFactory);

// Precondition with custom message template and custom exception factory.
value.RequiresValidCheckDigit(checkDigitAlgorithm, customMessageTemplate, customExceptionFactory);


// Postcondition with default message template and default exception factory.
value.EnsuresValidCheckDigit(checkDigitAlgorithm);

// Postcondition with custom message template and default exception factory.
value.EnsuresValidCheckDigit(checkDigitAlgorithm, customMessageTemplate);

// Postcondition with default message template and custom exception factory.
value.EnsuresValidCheckDigit(checkDigitAlgorithm, exceptionFactory: customExceptionFactory);

// Postcondition with custom message template and custom exception factory.
value.EnsuresValidCheckDigit(checkDigitAlgorithm, customMessageTemplate, customExceptionFactory);
```

### StandardCheckDigitAlgorithms

The DbC.Net.CheckDigits.StandardCheckDigitAlgorithms class has properties 
that give you access to predefined implementations of ICheckDigitAlgorithm as
lazily created singleton objects. The algorithms available are:

- AbaRoutingNumberAlgorithm - algorithm used by American Bankers Association (ABA) 
  routing numbers.

- Isbn10Algorithm - algorithm used by ISBN (International Standard Book
  Number) values with the ISBN-10 format. Superseded by the ISBN-13 in Jan. 2007.

- LuhnAlgorithm - popular algorithm used in a variety of applications including
  credit card numbers, IMEI (International Mobile Equipment Identity) numbers
  and more.

- Mod10BarcodeAlgorithm - algorithm used by a wide range of international standards.
  This implementation is suitable for Universal Product Codes (UPC-A and UPC-E),
  Global Trade Item Numbers and associated standards such as GTIN-14, GTIN-13, 
  GTIN-12, GTIN-8, ISBN-13, ISSN (International Standard Serial Number), ISMN
  (International Standard Music Number), International Article Number, SSCC 
  (Serial Shipping Container Code) and more.

- NpiAlgorithm - algorithm used by US NPI (National Provider Identifier) numbers.
  NPI number check digits are calculated by prefixing the 10 digit NPI number
  with "80840" and then applying the Luhn algorithm. This implementation handles 
  the prefix internally so your code does not need to allocate a new string just 
  to validate value.

- VehicleIdentificationNumberAlgorithm - algorithm used by North American (United
  States and Canada) Vehicle Identification Numbers (VIN).

### ICheckDigitAlgorithm

If you need to use a different check digit algorithm, either because you have a
tested/proven implementation that you prefer to use or you need an algorithm that
is not provided by StandardCheckDigitAlgorithms, then you can implement the 
ICheckDigitAlgorithm interface and pass your own implementation to
Requires/EnsuresValidCheckDigit.