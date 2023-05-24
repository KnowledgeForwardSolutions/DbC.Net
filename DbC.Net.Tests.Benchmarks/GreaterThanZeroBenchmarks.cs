namespace DbC.Net.Tests.Benchmarks;

[MemoryDiagnoser]
public class GreaterThanZeroBenchmarks
{
   private const Int32 _intValue = 42;
   private const Double _doubleValue = Double.Pi;
   private const Decimal _decimalValue = Decimal.MaxValue;

   private const String _messageTemplate = "Requires{RequirementName} failed: {Value} must be greater than zero";
   private static readonly IExceptionFactory _exceptionFactory = StandardExceptionFactories.InvalidOperationExceptionFactory;

   [Benchmark]
   public void ThrowAway()
   {
      var result = _intValue.RequiresGreaterThanZero();
   }

   [Benchmark]
   public void RequiresGreaterThanZero_Int32_P000()
   {
      var result = _intValue.RequiresGreaterThanZero();
   }

   [Benchmark]
   public void RequiresGreaterThanZero_Int32_P100()
   {
      var result = _intValue.RequiresGreaterThanZero(_messageTemplate);
   }

   [Benchmark]
   public void RequiresGreaterThanZero_Int32_P010()
   {
      var result = _intValue.RequiresGreaterThanZero(exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresGreaterThanZero_Int32_P110()
   {
      var result = _intValue.RequiresGreaterThanZero(_messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresGreaterThanZero_Double_P000()
   {
      var result = _doubleValue.RequiresGreaterThanZero();
   }

   [Benchmark]
   public void RequiresGreaterThanZero_Double_P100()
   {
      var result = _doubleValue.RequiresGreaterThanZero(_messageTemplate);
   }

   [Benchmark]
   public void RequiresGreaterThanZero_Double_P010()
   {
      var result = _doubleValue.RequiresGreaterThanZero(exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresGreaterThanZero_Double_P110()
   {
      var result = _doubleValue.RequiresGreaterThanZero(_messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresGreaterThanZero_Decimal_P000()
   {
      var result = _decimalValue.RequiresGreaterThanZero();
   }

   [Benchmark]
   public void RequiresGreaterThanZero_Decimal_P100()
   {
      var result = _decimalValue.RequiresGreaterThanZero(_messageTemplate);
   }

   [Benchmark]
   public void RequiresGreaterThanZero_Decimal_P010()
   {
      var result = _decimalValue.RequiresGreaterThanZero(exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresGreaterThanZero_Decimal_P110()
   {
      var result = _decimalValue.RequiresGreaterThanZero(_messageTemplate, _exceptionFactory);
   }
}
