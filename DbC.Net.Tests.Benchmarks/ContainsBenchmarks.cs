namespace DbC.Net.Tests.Benchmarks;

[MemoryDiagnoser]
public class ContainsBenchmarks
{
   private const String _messageTemplate = "{ValueExpression} must contain target substring";
   private static readonly IExceptionFactory _exceptionFactory = StandardExceptionFactories.InvalidOperationExceptionFactory;

   private const String _value = "This is a test. This is only a test";
   private const String _target = "only";

   [Benchmark]
   public void ThrowAway()
   {
      var result = _value.RequiresContains(_target);
   }

   [Benchmark]
   public void RequiresContains_P000()
   {
      var result = _value.RequiresContains(_target);
   }

   [Benchmark]
   public void RequiresContains_P010()
   {
      var result = _value.RequiresContains(_target, messageTemplate: _messageTemplate);
   }

   [Benchmark]
   public void RequiresContains_P001()
   {
      var result = _value.RequiresContains(_target, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresContains_P011()
   {
      var result = _value.RequiresContains(_target, messageTemplate: _messageTemplate, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresContains_Ordinal_P100()
   {
      var result = _value.RequiresContains(_target, StringComparison.Ordinal);
   }

   [Benchmark]
   public void RequiresContains_Ordinal_P110()
   {
      var result = _value.RequiresContains(_target, StringComparison.Ordinal, _messageTemplate);
   }

   [Benchmark]
   public void RequiresContains_Ordinal_P101()
   {
      var result = _value.RequiresContains(_target, StringComparison.Ordinal, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresContains_Ordinal_P111()
   {
      var result = _value.RequiresContains(_target, StringComparison.Ordinal, _messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresContains_OrdinalIgnoreCase_P100()
   {
      var result = _value.RequiresContains(_target, StringComparison.OrdinalIgnoreCase);
   }

   [Benchmark]
   public void RequiresContains_OrdinalIgnoreCase_P110()
   {
      var result = _value.RequiresContains(_target, StringComparison.OrdinalIgnoreCase, _messageTemplate);
   }

   [Benchmark]
   public void RequiresContains_OrdinalIgnoreCase_P101()
   {
      var result = _value.RequiresContains(_target, StringComparison.OrdinalIgnoreCase, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresContains_OrdinalIgnoreCase_P111()
   {
      var result = _value.RequiresContains(_target, StringComparison.OrdinalIgnoreCase, _messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresContains_CurrentCulture_P100()
   {
      var result = _value.RequiresContains(_target, StringComparison.CurrentCulture);
   }

   [Benchmark]
   public void RequiresContains_CurrentCulture_P110()
   {
      var result = _value.RequiresContains(_target, StringComparison.CurrentCulture, _messageTemplate);
   }

   [Benchmark]
   public void RequiresContains_CurrentCulture_P101()
   {
      var result = _value.RequiresContains(_target, StringComparison.CurrentCulture, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresContains_CurrentCulture_P111()
   {
      var result = _value.RequiresContains(_target, StringComparison.CurrentCulture, _messageTemplate, _exceptionFactory);
   }
}
