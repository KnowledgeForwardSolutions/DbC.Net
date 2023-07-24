namespace DbC.Net.Tests.Benchmarks;

[MemoryDiagnoser]
public class StartsWithBenchmarks
{
   private const String _messageTemplate = "{ValueExpression} must start with target substring";
   private static readonly IExceptionFactory _exceptionFactory = StandardExceptionFactories.InvalidOperationExceptionFactory;

   private const String _value = "This is a test. This is only a test";
   private const String _target = "This";

   [Benchmark]
   public void ThrowAway()
   {
      var result = _value.RequiresStartsWith(_target);
   }

   [Benchmark]
   public void RequiresStartsWith_P000()
   {
      var result = _value.RequiresStartsWith(_target);
   }

   [Benchmark]
   public void RequiresStartsWith_P010()
   {
      var result = _value.RequiresStartsWith(_target, messageTemplate: _messageTemplate);
   }

   [Benchmark]
   public void RequiresStartsWith_P001()
   {
      var result = _value.RequiresStartsWith(_target, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresStartsWith_P011()
   {
      var result = _value.RequiresStartsWith(_target, messageTemplate: _messageTemplate, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresStartsWith_Ordinal_P100()
   {
      var result = _value.RequiresStartsWith(_target, StringComparison.Ordinal);
   }

   [Benchmark]
   public void RequiresStartsWith_Ordinal_P110()
   {
      var result = _value.RequiresStartsWith(_target, StringComparison.Ordinal, _messageTemplate);
   }

   [Benchmark]
   public void RequiresStartsWith_Ordinal_P101()
   {
      var result = _value.RequiresStartsWith(_target, StringComparison.Ordinal, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresStartsWith_Ordinal_P111()
   {
      var result = _value.RequiresStartsWith(_target, StringComparison.Ordinal, _messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresStartsWith_OrdinalIgnoreCase_P100()
   {
      var result = _value.RequiresStartsWith(_target, StringComparison.OrdinalIgnoreCase);
   }

   [Benchmark]
   public void RequiresStartsWith_OrdinalIgnoreCase_P110()
   {
      var result = _value.RequiresStartsWith(_target, StringComparison.OrdinalIgnoreCase, _messageTemplate);
   }

   [Benchmark]
   public void RequiresStartsWith_OrdinalIgnoreCase_P101()
   {
      var result = _value.RequiresStartsWith(_target, StringComparison.OrdinalIgnoreCase, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresStartsWith_OrdinalIgnoreCase_P111()
   {
      var result = _value.RequiresStartsWith(_target, StringComparison.OrdinalIgnoreCase, _messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresStartsWith_CurrentCulture_P100()
   {
      var result = _value.RequiresStartsWith(_target, StringComparison.CurrentCulture);
   }

   [Benchmark]
   public void RequiresStartsWith_CurrentCulture_P110()
   {
      var result = _value.RequiresStartsWith(_target, StringComparison.CurrentCulture, _messageTemplate);
   }

   [Benchmark]
   public void RequiresStartsWith_CurrentCulture_P101()
   {
      var result = _value.RequiresStartsWith(_target, StringComparison.CurrentCulture, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresStartsWith_CurrentCulture_P111()
   {
      var result = _value.RequiresStartsWith(_target, StringComparison.CurrentCulture, _messageTemplate, _exceptionFactory);
   }
}
