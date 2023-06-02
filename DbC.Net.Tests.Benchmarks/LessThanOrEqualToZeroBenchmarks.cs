namespace DbC.Net.Tests.Benchmarks;

[MemoryDiagnoser]
public class LessThanOrEqualToZeroBenchmarks
{
   private const Int32 _intValue = -42;
   private const Double _doubleValue = Double.MinValue;
   private const Decimal _decimalValue = Decimal.MinValue;

   private const String _messageTemplate = "Requires{RequirementName} failed: {Value} must be less than or equal to zero";
   private static readonly IExceptionFactory _exceptionFactory = StandardExceptionFactories.InvalidOperationExceptionFactory;

   [Benchmark]
   public void ThrowAway()
   {
      var result = _intValue.RequiresLessThanOrEqualToZero();
   }

   [Benchmark]
   public void RequiresLessThanOrEqualToZero_Int32_P000()
   {
      var result = _intValue.RequiresLessThanOrEqualToZero();
   }

   [Benchmark]
   public void RequiresLessThanOrEqualToZero_Int32_P100()
   {
      var result = _intValue.RequiresLessThanOrEqualToZero(_messageTemplate);
   }

   [Benchmark]
   public void RequiresLessThanOrEqualToZero_Int32_P010()
   {
      var result = _intValue.RequiresLessThanOrEqualToZero(exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresLessThanOrEqualToZero_Int32_P110()
   {
      var result = _intValue.RequiresLessThanOrEqualToZero(_messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresLessThanOrEqualToZero_Double_P000()
   {
      var result = _doubleValue.RequiresLessThanOrEqualToZero();
   }

   [Benchmark]
   public void RequiresLessThanOrEqualToZero_Double_P100()
   {
      var result = _doubleValue.RequiresLessThanOrEqualToZero(_messageTemplate);
   }

   [Benchmark]
   public void RequiresLessThanOrEqualToZero_Double_P010()
   {
      var result = _doubleValue.RequiresLessThanOrEqualToZero(exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresLessThanOrEqualToZero_Double_P110()
   {
      var result = _doubleValue.RequiresLessThanOrEqualToZero(_messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresLessThanOrEqualToZero_Decimal_P000()
   {
      var result = _decimalValue.RequiresLessThanOrEqualToZero();
   }

   [Benchmark]
   public void RequiresLessThanOrEqualToZero_Decimal_P100()
   {
      var result = _decimalValue.RequiresLessThanOrEqualToZero(_messageTemplate);
   }

   [Benchmark]
   public void RequiresLessThanOrEqualToZero_Decimal_P010()
   {
      var result = _decimalValue.RequiresLessThanOrEqualToZero(exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresLessThanOrEqualToZero_Decimal_P110()
   {
      var result = _decimalValue.RequiresLessThanOrEqualToZero(_messageTemplate, _exceptionFactory);
   }
}
