### ApproximatelyEqual

ApproximatelyEqual requires that the floating point value being checked be 
approximately equal to a target value. Two parameters are used to check the 
approximate equality: the allowed error margin (i.e. amount that the value is 
allowed to differ from the target and still be considered equal), known as 
*epsilon*, and a comparer object of type IApproximateEqualityComparer<T> that 
performs the actual equality check.

Due to the possibility of rounding errors in floating point calculations it is 
never a good idea to perform an exact equality check on floating point values. 
Instead the standard practice is to check for approximate equality by determining 
if the value is "close enough" to the target to be considered effectively equal.
However, there are multiple methods for checking for approximate equality and 
choosing the correct method requires knowledge of the values being checked and
also of the ways that the values will be used. There simply isn't a universal
approach that can be plugged into all use cases. Because of this, DbC.Net allows
a developer to specify how the comparison is performed via supplying a comparer
object to the Requires/EnsuresApproximatelyEqual methods.

**Absolute Error and Relative Error**

A common approach for checking approximate equality is to check 
ABS(value - target) < epsilon. This is known as an absolute error. The issue
with using an absolute error is that it can produce incorrect results for very
large or very small values. For example, an epsilon of 0.0001 may seem like a 
good choice, but when the target is 1,000,000,000 (1 billion), a value of 
1,000,000,100 could be considered effectively equal even though the difference 
is far greater than 0.0001.

A much more accurate, though more complex approach is to use a relative 
error as described in the [Floating Point Guide](https://floating-point-gui.de/errors/comparison/).

DbC.Net supplies standard implementations of both absolute and relative error 
comparers in the [StandardFloatingPointComparers](xyz) class and if these are 
insufficient, you have the option of using your own comparer by implementing the 
IApproximateEqualityComparer<T> interface.

**Method signatures:**
```C#
T RequiresApproximatelyEqual<T>(
   this T value, 
   T target, 
   T epsilon, 
   IApproximateEqualityComparer<T> comparer, 
   [String? messageTemplate = null], 
   [IExceptionFactory? exceptionFactory = null], 
   [String? valueExpression = null], 
   [String? targetExpression = null]) where T : IFloatingPoint<T>

T EnsuresApproximatelyEqual<T>(
   this T value, 
   T target, 
   T epsilon, 
   IApproximateEqualityComparer<T> comparer, 
   [String? messageTemplate = null], 
   [IExceptionFactory? exceptionFactory = null], 
   [String? valueExpression = null], 
   [String? targetExpression = null]) where T : IFloatingPoint<T>
```

The default message template for ApproximatelyEqual is "{RequirementType} {RequirementName} failed: {ValueExpression} must be within +/- {Epsilon} of {Target}".
The default exception factory for RequiresApproximatelyEqual is StandardExceptionFactories.ArgumentExceptionFactory
and StandardExceptionFactories.PostconditionFailedExceptionFactory for 
EnsuresApproximatelyEqual.

The data dictionary for exceptions thrown will contain entries for RequirementType,
RequirementName, Value, ValueExpression, Target, TargetExpression, Epsilon and 
EpsilonExpression.

**Examples:**
```C#
var customMessageTemplate = "{ValueExpression} must be close to {Target}";
var customExceptionFactory = new CustomExceptionFactory();

var value = Double.Pi;
var target = 4.0;
var epsilon = 0.0001;
var comparer = StandardFloatingPointComparers.DoubleRelativeErrorComparer;


// Precondition with default message template/default exception factory.
value.RequiresApproximatelyEqual(target, epsilon, comparer);

// Precondition with custom message template/default exception factory.
value.RequiresApproximatelyEqual(target, epsilon, comparer, customMessageTemplate);

// Precondition with default message template/custom exception factory.
value.RequiresApproximatelyEqual(target, epsilon, comparer, exceptionFactory: customExceptionFactory);

// Precondition with custom message template/custom exception factory.
value.RequiresApproximatelyEqual(target, epsilon, comparer, customMessageTemplate, customExceptionFactory);


// Postcondition with default message template/default exception factory.
value.EnsuresApproximatelyEqual(target, epsilon, comparer);

// Postcondition with custom message template/default exception factory.
value.EnsuresApproximatelyEqual(target, epsilon, comparer, customMessageTemplate);

// Postcondition with default message template/custom exception factory.
value.EnsuresApproximatelyEqual(target, epsilon, comparer, exceptionFactory: customExceptionFactory);

// Postcondition with custom message template/custom exception factory.
value.EnsuresApproximatelyEqual(target, epsilon, comparer, customMessageTemplate, customExceptionFactory);
```
