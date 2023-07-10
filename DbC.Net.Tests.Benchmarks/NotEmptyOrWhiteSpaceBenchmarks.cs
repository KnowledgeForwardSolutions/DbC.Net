namespace DbC.Net.Tests.Benchmarks;

[MemoryDiagnoser]
public class NotEmptyOrWhiteSpaceBenchmarks
{
   private const String _value = "asdf";
   private const String _messageTemplate = "Requires{RequirementName} failed: {Value} must have a non-empty/non-whitespace value";
   private static readonly IExceptionFactory _exceptionFactory = StandardExceptionFactories.InvalidOperationExceptionFactory;

   [Benchmark]
   public void ThrowAway()
   {
      var result = _value.RequiresNotEmptyOrWhiteSpace();
   }

   [Benchmark]
   public void RequiresNotEmptyOrWhiteSpace_String_P000()
   {
      var result = _value.RequiresNotEmptyOrWhiteSpace();
   }

   [Benchmark]
   public void RequiresNotEmptyOrWhiteSpace_String_P100()
   {
      var result = _value.RequiresNotEmptyOrWhiteSpace(_messageTemplate);
   }

   [Benchmark]
   public void RequiresNotEmptyOrWhiteSpace_String_P010()
   {
      var result = _value.RequiresNotEmptyOrWhiteSpace(exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresNotEmptyOrWhiteSpace_String_P110()
   {
      var result = _value.RequiresNotEmptyOrWhiteSpace(_messageTemplate, _exceptionFactory);
   }
}
