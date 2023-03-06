namespace DbC.Net.Tests.Benchmarks;

[MemoryDiagnoser]
public class ApproximatelyEqualBenchmarks
{
   private const Double _doubleValue = 3.141592653589793D;
   private const Double _doubleTarget = _doubleValue + 0.000000000000001D;
   private const Double _doubleFixedEpsilon = 0.000000000000003D;
   private static IApproximateEqualityComparer<Double> _doubleFixedEpsilonComparer = StandardFloatingPointComparers.DoubleFixedErrorComparer;
   private const Double _doubleRelativeEpsilon = 0.0000000000000002D;
   private static IApproximateEqualityComparer<Double> _doubleRelativeEpsilonComparer = StandardFloatingPointComparers.DoubleRelativeErrorComparer;
   
   private const Single _singleValue = 3.14152F;
   private const Single _singleTarget = _singleValue + 0.00001F;
   private const Single _singleFixedEpsilon = 0.00003F;
   private static IApproximateEqualityComparer<Single> _singleFixedEpsilonComparer = StandardFloatingPointComparers.SingleFixedErrorComparer;
   private const Single _singleRelativeEpsilon = 0.000002F;
   private static IApproximateEqualityComparer<Single> _singleRelativeEpsilonComparer = StandardFloatingPointComparers.SingleRelativeErrorComparer;

   private const String _messageTemplate = "Requires{RequirementName} failed: {Value} must be close to {Target}";
   private static readonly IExceptionFactory _exceptionFactory = StandardExceptionFactories.InvalidOperationExceptionFactory;

   [Benchmark]
   public void ThrowAway()
   {
      var result = _doubleValue.RequiresApproximatelyEqual(_doubleTarget, _doubleFixedEpsilon, _doubleFixedEpsilonComparer);
   }

   [Benchmark]
   public void RequiresApproximatelyEqual_Double_P000()
   {
      var result = _doubleValue.RequiresApproximatelyEqual(_doubleTarget, _doubleFixedEpsilon, _doubleFixedEpsilonComparer);
   }

   [Benchmark]
   public void RequiresApproximatelyEqual_Double_P010()
   {
      var result = _doubleValue.RequiresApproximatelyEqual(_doubleTarget, _doubleFixedEpsilon, _doubleFixedEpsilonComparer, _messageTemplate);
   }

   [Benchmark]
   public void RequiresApproximatelyEqual_Double_P001()
   {
      var result = _doubleValue.RequiresApproximatelyEqual(_doubleTarget, _doubleFixedEpsilon, _doubleFixedEpsilonComparer, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresApproximatelyEqual_Double_P011()
   {
      var result = _doubleValue.RequiresApproximatelyEqual(_doubleTarget, _doubleFixedEpsilon, _doubleFixedEpsilonComparer, _messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresApproximatelyEqual_Double_P100()
   {
      var result = _doubleValue.RequiresApproximatelyEqual(_doubleTarget, _doubleRelativeEpsilon, _doubleRelativeEpsilonComparer);
   }

   [Benchmark]
   public void RequiresApproximatelyEqual_Double_P110()
   {
      var result = _doubleValue.RequiresApproximatelyEqual(_doubleTarget, _doubleRelativeEpsilon, _doubleRelativeEpsilonComparer, _messageTemplate);
   }

   [Benchmark]
   public void RequiresApproximatelyEqual_Double_P101()
   {
      var result = _doubleValue.RequiresApproximatelyEqual(_doubleTarget, _doubleRelativeEpsilon, _doubleRelativeEpsilonComparer, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresApproximatelyEqual_Double_P111()
   {
      var result = _doubleValue.RequiresApproximatelyEqual(_doubleTarget, _doubleRelativeEpsilon, _doubleRelativeEpsilonComparer, _messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresApproximatelyEqual_Single_P000()
   {
      var result = _singleValue.RequiresApproximatelyEqual(_singleTarget, _singleFixedEpsilon, _singleFixedEpsilonComparer);
   }

   [Benchmark]
   public void RequiresApproximatelyEqual_Single_P010()
   {
      var result = _singleValue.RequiresApproximatelyEqual(_singleTarget, _singleFixedEpsilon, _singleFixedEpsilonComparer, _messageTemplate);
   }

   [Benchmark]
   public void RequiresApproximatelyEqual_Single_P001()
   {
      var result = _singleValue.RequiresApproximatelyEqual(_singleTarget, _singleFixedEpsilon, _singleFixedEpsilonComparer, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresApproximatelyEqual_Single_P011()
   {
      var result = _singleValue.RequiresApproximatelyEqual(_singleTarget, _singleFixedEpsilon, _singleFixedEpsilonComparer, _messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresApproximatelyEqual_Single_P100()
   {
      var result = _singleValue.RequiresApproximatelyEqual(_singleTarget, _singleRelativeEpsilon, _singleRelativeEpsilonComparer);
   }

   [Benchmark]
   public void RequiresApproximatelyEqual_Single_P110()
   {
      var result = _singleValue.RequiresApproximatelyEqual(_singleTarget, _singleRelativeEpsilon, _singleRelativeEpsilonComparer, _messageTemplate);
   }

   [Benchmark]
   public void RequiresApproximatelyEqual_Single_P101()
   {
      var result = _singleValue.RequiresApproximatelyEqual(_singleTarget, _singleRelativeEpsilon, _singleRelativeEpsilonComparer, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresApproximatelyEqual_Single_P111()
   {
      var result = _singleValue.RequiresApproximatelyEqual(_singleTarget, _singleRelativeEpsilon, _singleRelativeEpsilonComparer, _messageTemplate, _exceptionFactory);
   }
}
