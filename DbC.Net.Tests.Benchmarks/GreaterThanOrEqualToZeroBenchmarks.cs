namespace DbC.Net.Tests.Benchmarks;

[MemoryDiagnoser]
public class GreaterThanOrEqualToZeroBenchmarks
{
   private const Int32 _intValue = 42;
   private const Double _doubleValue = Double.Pi;
   private const Decimal _decimalValue = Decimal.MaxValue;

   private const String _messageTemplate = "Requires{RequirementName} failed: {Value} must be greater than or equal to zero";
   private static readonly IExceptionFactory _exceptionFactory = StandardExceptionFactories.InvalidOperationExceptionFactory;

   [Benchmark]
   public void ThrowAway()
   {
      var result = _intValue.RequiresGreaterThanOrEqualToZero();
   }

   [Benchmark]
   public void RequiresGreaterThanOrEqualToZero_Int32_P000()
   {
      var result = _intValue.RequiresGreaterThanOrEqualToZero();
   }

   [Benchmark]
   public void RequiresGreaterThanOrEqualToZero_Int32_P100()
   {
      var result = _intValue.RequiresGreaterThanOrEqualToZero(_messageTemplate);
   }

   [Benchmark]
   public void RequiresGreaterThanOrEqualToZero_Int32_P010()
   {
      var result = _intValue.RequiresGreaterThanOrEqualToZero(exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresGreaterThanOrEqualToZero_Int32_P110()
   {
      var result = _intValue.RequiresGreaterThanOrEqualToZero(_messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresGreaterThanOrEqualToZero_Double_P000()
   {
      var result = _doubleValue.RequiresGreaterThanOrEqualToZero();
   }

   [Benchmark]
   public void RequiresGreaterThanOrEqualToZero_Double_P100()
   {
      var result = _doubleValue.RequiresGreaterThanOrEqualToZero(_messageTemplate);
   }

   [Benchmark]
   public void RequiresGreaterThanOrEqualToZero_Double_P010()
   {
      var result = _doubleValue.RequiresGreaterThanOrEqualToZero(exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresGreaterThanOrEqualToZero_Double_P110()
   {
      var result = _doubleValue.RequiresGreaterThanOrEqualToZero(_messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresGreaterThanOrEqualToZero_Decimal_P000()
   {
      var result = _decimalValue.RequiresGreaterThanOrEqualToZero();
   }

   [Benchmark]
   public void RequiresGreaterThanOrEqualToZero_Decimal_P100()
   {
      var result = _decimalValue.RequiresGreaterThanOrEqualToZero(_messageTemplate);
   }

   [Benchmark]
   public void RequiresGreaterThanOrEqualToZero_Decimal_P010()
   {
      var result = _decimalValue.RequiresGreaterThanOrEqualToZero(exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresGreaterThanOrEqualToZero_Decimal_P110()
   {
      var result = _decimalValue.RequiresGreaterThanOrEqualToZero(_messageTemplate, _exceptionFactory);
   }
}
