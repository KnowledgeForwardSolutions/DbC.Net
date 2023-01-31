namespace DbC.Net.Tests.Benchmarks;

[MemoryDiagnoser]
public class NotNullBenchmarks
{
   private const Int32 _intValue = 1;
   private const String _stringValue = "This is a test";
   private static readonly List<Double> _listValue = new() { Double.MinValue, Double.MaxValue };
   private const String _messageTemplate = "Requires{RequirementName} failed: {ValueExpression} may not be null";
   private static readonly IExceptionFactory _exceptionFactory = StandardExceptionFactories.InvalidOperationExceptionFactory;

   [Benchmark]
   public void ThrowAway()
   {
      var result = _intValue.RequiresNotNull();
   }

   [Benchmark]
   public void RequiresNotNull_Int32_P00()
   {
      var result = _intValue.RequiresNotNull();
   }

   [Benchmark]
   public void RequiresNotNull_Int32_P10()
   {
      var result = _intValue.RequiresNotNull(_messageTemplate);
   }

   [Benchmark]
   public void RequiresNotNull_Int32_P01()
   {
      var result = _intValue.RequiresNotNull(exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresNotNull_Int32_P11()
   {
      var result = _intValue.RequiresNotNull(_messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresNotNull_String_P00()
   {
      var result = _stringValue.RequiresNotNull();
   }

   [Benchmark]
   public void RequiresNotNull_String_P10()
   {
      var result = _stringValue.RequiresNotNull(_messageTemplate);
   }

   [Benchmark]
   public void RequiresNotNull_String_P01()
   {
      var result = _stringValue.RequiresNotNull(exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresNotNull_String_P11()
   {
      var result = _stringValue.RequiresNotNull(_messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresNotNull_List_P00()
   {
      var result = _listValue.RequiresNotNull();
   }

   [Benchmark]
   public void RequiresNotNull_List_P10()
   {
      var result = _listValue.RequiresNotNull(_messageTemplate);
   }

   [Benchmark]
   public void RequiresNotNull_List_P01()
   {
      var result = _listValue.RequiresNotNull(exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresNotNull_List_P11()
   {
      var result = _listValue.RequiresNotNull(_messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void EnsuresNotNull_Int32_P00()
   {
      var result = _intValue.EnsuresNotNull();
   }

   [Benchmark]
   public void EnsuresNotNull_Int32_P10()
   {
      var result = _intValue.EnsuresNotNull(_messageTemplate);
   }

   [Benchmark]
   public void EnsuresNotNull_Int32_P01()
   {
      var result = _intValue.EnsuresNotNull(exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void EnsuresNotNull_Int32_P11()
   {
      var result = _intValue.EnsuresNotNull(_messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void EnsuresNotNull_String_P00()
   {
      var result = _stringValue.EnsuresNotNull();
   }

   [Benchmark]
   public void EnsuresNotNull_String_P10()
   {
      var result = _stringValue.EnsuresNotNull(_messageTemplate);
   }

   [Benchmark]
   public void EnsuresNotNull_String_P01()
   {
      var result = _stringValue.EnsuresNotNull(exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void EnsuresNotNull_String_P11()
   {
      var result = _stringValue.EnsuresNotNull(_messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void EnsuresNotNull_List_P00()
   {
      var result = _listValue.EnsuresNotNull();
   }

   [Benchmark]
   public void EnsuresNotNull_List_P10()
   {
      var result = _listValue.EnsuresNotNull(_messageTemplate);
   }

   [Benchmark]
   public void EnsuresNotNull_List_P01()
   {
      var result = _listValue.EnsuresNotNull(exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void EnsuresNotNull_List_P11()
   {
      var result = _listValue.EnsuresNotNull(_messageTemplate, _exceptionFactory);
   }
}
