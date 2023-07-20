namespace DbC.Net.Tests.Benchmarks;

[MemoryDiagnoser]
public class DigitsOnlyBenchmarks
{
   private const String _nullString = null!;
   private const String _shortString = "1234567890";
   private const String _longString = "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890";
   private const String _messageTemplate = "Requires{RequirementName} failed: {Value} must be digits only";
   private static readonly IExceptionFactory _exceptionFactory = StandardExceptionFactories.InvalidOperationExceptionFactory;

   [Benchmark]
   public void ThrowAway()
   {
      var result = _shortString.RequiresDigitsOnly();
   }

   [Benchmark]
   public void RequiresDigitsOnly_NullString_P000()
   {
      var result = _nullString.RequiresDigitsOnly();
   }

   [Benchmark]
   public void RequiresDigitsOnly_NullString_P100()
   {
      var result = _nullString.RequiresDigitsOnly(_messageTemplate);
   }

   [Benchmark]
   public void RequiresDigitsOnly_NullString_P010()
   {
      var result = _nullString.RequiresDigitsOnly(exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresDigitsOnly_NullString_P110()
   {
      var result = _nullString.RequiresDigitsOnly(_messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresDigitsOnly_ShortString_P000()
   {
      var result = _shortString.RequiresDigitsOnly();
   }

   [Benchmark]
   public void RequiresDigitsOnly_ShortString_P100()
   {
      var result = _shortString.RequiresDigitsOnly(_messageTemplate);
   }

   [Benchmark]
   public void RequiresDigitsOnly_ShortString_P010()
   {
      var result = _shortString.RequiresDigitsOnly(exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresDigitsOnly_ShortString_P110()
   {
      var result = _shortString.RequiresDigitsOnly(_messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresDigitsOnly_LongString_P000()
   {
      var result = _longString.RequiresDigitsOnly();
   }

   [Benchmark]
   public void RequiresDigitsOnly_LongString_P100()
   {
      var result = _longString.RequiresDigitsOnly(_messageTemplate);
   }

   [Benchmark]
   public void RequiresDigitsOnly_LongString_P010()
   {
      var result = _longString.RequiresDigitsOnly(exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresDigitsOnly_LongString_P110()
   {
      var result = _longString.RequiresDigitsOnly(_messageTemplate, _exceptionFactory);
   }
}
