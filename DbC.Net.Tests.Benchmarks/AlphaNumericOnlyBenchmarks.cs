namespace DbC.Net.Tests.Benchmarks;

[MemoryDiagnoser]
public class AlphaNumericOnlyBenchmarks
{
   private const String _nullString = null!;
   private const String _shortString = "asdf123456";
   private const String _longString = "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890";
   private const String _messageTemplate = "Requires{RequirementName} failed: {Value} must be alphanumeric only";
   private static readonly IExceptionFactory _exceptionFactory = StandardExceptionFactories.InvalidOperationExceptionFactory;

   [Benchmark]
   public void ThrowAway()
   {
      var result = _shortString.RequiresAlphaNumericOnly();
   }

   [Benchmark]
   public void RequiresAlphaNumericOnly_NullString_P000()
   {
      var result = _nullString.RequiresAlphaNumericOnly();
   }

   [Benchmark]
   public void RequiresAlphaNumericOnly_NullString_P100()
   {
      var result = _nullString.RequiresAlphaNumericOnly(_messageTemplate);
   }

   [Benchmark]
   public void RequiresAlphaNumericOnly_NullString_P010()
   {
      var result = _nullString.RequiresAlphaNumericOnly(exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresAlphaNumericOnly_NullString_P110()
   {
      var result = _nullString.RequiresAlphaNumericOnly(_messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresAlphaNumericOnly_ShortString_P000()
   {
      var result = _shortString.RequiresAlphaNumericOnly();
   }

   [Benchmark]
   public void RequiresAlphaNumericOnly_ShortString_P100()
   {
      var result = _shortString.RequiresAlphaNumericOnly(_messageTemplate);
   }

   [Benchmark]
   public void RequiresAlphaNumericOnly_ShortString_P010()
   {
      var result = _shortString.RequiresAlphaNumericOnly(exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresAlphaNumericOnly_ShortString_P110()
   {
      var result = _shortString.RequiresAlphaNumericOnly(_messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresAlphaNumericOnly_LongString_P000()
   {
      var result = _longString.RequiresAlphaNumericOnly();
   }

   [Benchmark]
   public void RequiresAlphaNumericOnly_LongString_P100()
   {
      var result = _longString.RequiresAlphaNumericOnly(_messageTemplate);
   }

   [Benchmark]
   public void RequiresAlphaNumericOnly_LongString_P010()
   {
      var result = _longString.RequiresAlphaNumericOnly(exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresAlphaNumericOnly_LongString_P110()
   {
      var result = _longString.RequiresAlphaNumericOnly(_messageTemplate, _exceptionFactory);
   }
}
