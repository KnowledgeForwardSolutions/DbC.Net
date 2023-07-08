namespace DbC.Net.Tests.Benchmarks;

[MemoryDiagnoser]
public class NotNullOrWhiteSpaceBenchmarks
{
   private const String _value = "asdf";
   private const String _messageTemplate = "Requires{RequirementName} failed: {Value} must have a non-null/non-empty/non-whitespace value";
   private static readonly IExceptionFactory _exceptionFactory = StandardExceptionFactories.InvalidOperationExceptionFactory;

   [Benchmark]
   public void ThrowAway()
   {
      var result = _value.RequiresNotNullOrWhiteSpace();
   }

   [Benchmark]
   public void RequiresNotNullOrWhiteSpace_String_P000()
   {
      var result = _value.RequiresNotNullOrWhiteSpace();
   }

   [Benchmark]
   public void RequiresNotNullOrWhiteSpace_String_P100()
   {
      var result = _value.RequiresNotNullOrWhiteSpace(_messageTemplate);
   }

   [Benchmark]
   public void RequiresNotNullOrWhiteSpace_String_P010()
   {
      var result = _value.RequiresNotNullOrWhiteSpace(nullExceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresNotNullOrWhiteSpace_String_P001()
   {
      var result = _value.RequiresNotNullOrWhiteSpace(emptyExceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresNotNullOrWhiteSpace_String_P011()
   {
      var result = _value.RequiresNotNullOrWhiteSpace(nullExceptionFactory: _exceptionFactory, emptyExceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresNotNullOrWhiteSpace_String_P110()
   {
      var result = _value.RequiresNotNullOrWhiteSpace(_messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresNotNullOrWhiteSpace_String_P101()
   {
      var result = _value.RequiresNotNullOrWhiteSpace(_messageTemplate, emptyExceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresNotNullOrWhiteSpace_String_P111()
   {
      var result = _value.RequiresNotNullOrWhiteSpace(_messageTemplate, _exceptionFactory, _exceptionFactory);
   }
}
