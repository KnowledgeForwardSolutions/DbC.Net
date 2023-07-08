namespace DbC.Net.Tests.Benchmarks;

[MemoryDiagnoser]
public class NotNullOrEmptyBenchmarks
{
   private const String _value = "asdf";
   private const String _messageTemplate = "Requires{RequirementName} failed: {Value} must have a non-null/non-empty value";
   private static readonly IExceptionFactory _exceptionFactory = StandardExceptionFactories.InvalidOperationExceptionFactory;

   [Benchmark]
   public void ThrowAway()
   {
      var result = _value.RequiresNotNullOrEmpty();
   }

   [Benchmark]
   public void RequiresNotNullOrEmpty_String_P000()
   {
      var result = _value.RequiresNotNullOrEmpty();
   }

   [Benchmark]
   public void RequiresNotNullOrEmpty_String_P100()
   {
      var result = _value.RequiresNotNullOrEmpty(_messageTemplate);
   }

   [Benchmark]
   public void RequiresNotNullOrEmpty_String_P010()
   {
      var result = _value.RequiresNotNullOrEmpty(nullExceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresNotNullOrEmpty_String_P001()
   {
      var result = _value.RequiresNotNullOrEmpty(emptyExceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresNotNullOrEmpty_String_P110()
   {
      var result = _value.RequiresNotNullOrEmpty(_messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresNotNullOrEmpty_String_P101()
   {
      var result = _value.RequiresNotNullOrEmpty(_messageTemplate, emptyExceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresNotNullOrEmpty_String_P111()
   {
      var result = _value.RequiresNotNullOrEmpty(_messageTemplate, _exceptionFactory, _exceptionFactory);
   }
}
