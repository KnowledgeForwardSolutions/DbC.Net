namespace DbC.Net.Tests.Benchmarks;

[MemoryDiagnoser]
public class NotDefaultBenchmarks
{
   private const Int32 _intValue = 1;
   private const String _stringValue = "This is a test";
   private static readonly List<Double> _listValue = new() { Double.MinValue, Double.MaxValue };
   private const String _messageTemplate = "Requires{RequirementName} failed: {ValueExpression} may not be default";
   private static readonly IExceptionFactory _exceptionFactory = StandardExceptionFactories.InvalidOperationExceptionFactory;

   [Benchmark]
   public void ThrowAway()
   {
      var result = _intValue.RequiresNotDefault();
   }

   [Benchmark]
   public void RequiresNotDefault_Int32_P00()
   {
      var result = _intValue.RequiresNotDefault();
   }

   [Benchmark]
   public void RequiresNotDefault_Int32_P10()
   {
      var result = _intValue.RequiresNotDefault(_messageTemplate);
   }

   [Benchmark]
   public void RequiresNotDefault_Int32_P01()
   {
      var result = _intValue.RequiresNotDefault(exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresNotDefault_Int32_P11()
   {
      var result = _intValue.RequiresNotDefault(_messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresNotDefault_String_P00()
   {
      var result = _stringValue.RequiresNotDefault();
   }

   [Benchmark]
   public void RequiresNotDefault_String_P10()
   {
      var result = _stringValue.RequiresNotDefault(_messageTemplate);
   }

   [Benchmark]
   public void RequiresNotDefault_String_P01()
   {
      var result = _stringValue.RequiresNotDefault(exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresNotDefault_String_P11()
   {
      var result = _stringValue.RequiresNotDefault(_messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresNotDefault_List_P00()
   {
      var result = _listValue.RequiresNotDefault();
   }

   [Benchmark]
   public void RequiresNotDefault_List_P10()
   {
      var result = _listValue.RequiresNotDefault(_messageTemplate);
   }

   [Benchmark]
   public void RequiresNotDefault_List_P01()
   {
      var result = _listValue.RequiresNotDefault(exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresNotDefault_List_P11()
   {
      var result = _listValue.RequiresNotDefault(_messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void EnsuresNotDefault_Int32_P00()
   {
      var result = _intValue.EnsuresNotDefault();
   }

   [Benchmark]
   public void EnsuresNotDefault_Int32_P10()
   {
      var result = _intValue.EnsuresNotDefault(_messageTemplate);
   }

   [Benchmark]
   public void EnsuresNotDefault_Int32_P01()
   {
      var result = _intValue.EnsuresNotDefault(exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void EnsuresNotDefault_Int32_P11()
   {
      var result = _intValue.EnsuresNotDefault(_messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void EnsuresNotDefault_String_P00()
   {
      var result = _stringValue.EnsuresNotDefault();
   }

   [Benchmark]
   public void EnsuresNotDefault_String_P10()
   {
      var result = _stringValue.EnsuresNotDefault(_messageTemplate);
   }

   [Benchmark]
   public void EnsuresNotDefault_String_P01()
   {
      var result = _stringValue.EnsuresNotDefault(exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void EnsuresNotDefault_String_P11()
   {
      var result = _stringValue.EnsuresNotDefault(_messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void EnsuresNotDefault_List_P00()
   {
      var result = _listValue.EnsuresNotDefault();
   }

   [Benchmark]
   public void EnsuresNotDefault_List_P10()
   {
      var result = _listValue.EnsuresNotDefault(_messageTemplate);
   }

   [Benchmark]
   public void EnsuresNotDefault_List_P01()
   {
      var result = _listValue.EnsuresNotDefault(exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void EnsuresNotDefault_List_P11()
   {
      var result = _listValue.EnsuresNotDefault(_messageTemplate, _exceptionFactory);
   }
}
