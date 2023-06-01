namespace DbC.Net.Tests.Benchmarks;

[MemoryDiagnoser]
public class LessThanZeroBenchmarks
{
   private const Int32 _intValue = -42;
   private const Double _doubleValue = Double.MinValue;
   private const Decimal _decimalValue = Decimal.MinValue;

   private const String _messageTemplate = "Requires{RequirementName} failed: {Value} must be less than zero";
   private static readonly IExceptionFactory _exceptionFactory = StandardExceptionFactories.InvalidOperationExceptionFactory;

   [Benchmark]
   public void ThrowAway()
   {
      var result = _intValue.RequiresLessThanZero();
   }

   [Benchmark]
   public void RequiresLessThanZero_Int32_P000()
   {
      var result = _intValue.RequiresLessThanZero();
   }

   [Benchmark]
   public void RequiresLessThanZero_Int32_P100()
   {
      var result = _intValue.RequiresLessThanZero(_messageTemplate);
   }

   [Benchmark]
   public void RequiresLessThanZero_Int32_P010()
   {
      var result = _intValue.RequiresLessThanZero(exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresLessThanZero_Int32_P110()
   {
      var result = _intValue.RequiresLessThanZero(_messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresLessThanZero_Double_P000()
   {
      var result = _doubleValue.RequiresLessThanZero();
   }

   [Benchmark]
   public void RequiresLessThanZero_Double_P100()
   {
      var result = _doubleValue.RequiresLessThanZero(_messageTemplate);
   }

   [Benchmark]
   public void RequiresLessThanZero_Double_P010()
   {
      var result = _doubleValue.RequiresLessThanZero(exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresLessThanZero_Double_P110()
   {
      var result = _doubleValue.RequiresLessThanZero(_messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresLessThanZero_Decimal_P000()
   {
      var result = _decimalValue.RequiresLessThanZero();
   }

   [Benchmark]
   public void RequiresLessThanZero_Decimal_P100()
   {
      var result = _decimalValue.RequiresLessThanZero(_messageTemplate);
   }

   [Benchmark]
   public void RequiresLessThanZero_Decimal_P010()
   {
      var result = _decimalValue.RequiresLessThanZero(exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresLessThanZero_Decimal_P110()
   {
      var result = _decimalValue.RequiresLessThanZero(_messageTemplate, _exceptionFactory);
   }
}
