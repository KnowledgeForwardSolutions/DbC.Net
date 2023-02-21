namespace DbC.Net.Tests.Benchmarks;

[MemoryDiagnoser]
public class NotEqualBenchmarks
{
   private const Int32 _intValue = 100;
   private const Int32 _intTarget = 101;
   private static readonly IEqualityComparer<Int32> _intComparer = EqualityComparer<Int32>.Default;

   private const String _strValue = "asdf";
   private const String _strTarget = "QWERTY";
   private static readonly IEqualityComparer<String> _stringComparer = EqualityComparer<String>.Default;
   private const StringComparison _comparisonType = StringComparison.OrdinalIgnoreCase;

   private static readonly Box _boxValue = new(2, 4, 8, "Green");
   private static readonly Box _boxTarget = new(2, 4, 8, "Blue");
   private static readonly IEqualityComparer<Box> _boxComparer = BoxComparers.AllFieldsComparer;

   private static readonly Observation _observationValue = new()
   {
      ObservationId = new Guid("f77d70bc-6eea-45f4-96e5-5bbb02f7ee08"),
      ObservationTimestamp = new DateTime(2022, 11, 22, 9, 37, 46, 789),
      ObservationType = ObservationType.Temperature,
      Value = 6.278,
      Units = Units.DegreesCelsius
   };
   private static readonly Observation _observationTaget = new()
   {
      ObservationId = new Guid("66e1148d-ed17-4628-9a7f-530660f9b988"),
      ObservationTimestamp = new DateTime(2021, 11, 22, 9, 37, 46, 789),
      ObservationType = ObservationType.Concentration,
      Value = 2.75,
      Units = Units.KilogramsPerMeterCubed
   };
   private static readonly IEqualityComparer<Observation> _observationComparer = ObservationComparers.AllFieldsComparer;

   private const String _messageTemplate = "Requires{RequirementName} failed: {Value} must not be equal to {Target}";
   private static readonly IExceptionFactory _exceptionFactory = StandardExceptionFactories.InvalidOperationExceptionFactory;

   [Benchmark]
   public void ThrowAway()
   {
      var result = _intValue.RequiresNotEqual(_intTarget);
   }

   [Benchmark]
   public void RequiresNotEqual_Int32_P000()
   {
      var result = _intValue.RequiresNotEqual(_intTarget);
   }

   [Benchmark]
   public void RequiresNotEqual_Int32_P100()
   {
      var result = _intValue.RequiresNotEqual(_intTarget, _messageTemplate);
   }

   [Benchmark]
   public void RequiresNotEqual_Int32_P010()
   {
      var result = _intValue.RequiresNotEqual(_intTarget, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresNotEqual_Int32_P110()
   {
      var result = _intValue.RequiresNotEqual(_intTarget, _messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresNotEqual_Int32_P001()
   {
      var result = _intValue.RequiresNotEqual(_intTarget, _intComparer);
   }

   [Benchmark]
   public void RequiresNotEqual_Int32_P101()
   {
      var result = _intValue.RequiresNotEqual(_intTarget, _intComparer, _messageTemplate);
   }

   [Benchmark]
   public void RequiresNotEqual_Int32_P011()
   {
      var result = _intValue.RequiresNotEqual(_intTarget, _intComparer, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresNotEqual_Int32_P111()
   {
      var result = _intValue.RequiresNotEqual(_intTarget, _intComparer, _messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresNotEqual_String_P000()
   {
      var result = _strValue.RequiresNotEqual(_strTarget);
   }

   [Benchmark]
   public void RequiresNotEqual_String_P100()
   {
      var result = _strValue.RequiresNotEqual(_strTarget, _messageTemplate);
   }

   [Benchmark]
   public void RequiresNotEqual_String_P010()
   {
      var result = _strValue.RequiresNotEqual(_strTarget, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresNotEqual_String_P110()
   {
      var result = _strValue.RequiresNotEqual(_strTarget, _messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresNotEqual_String_P001()
   {
      var result = _strValue.RequiresNotEqual(_strTarget, _stringComparer);
   }

   [Benchmark]
   public void RequiresNotEqual_String_P101()
   {
      var result = _strValue.RequiresNotEqual(_strTarget, _stringComparer, _messageTemplate);
   }

   [Benchmark]
   public void RequiresNotEqual_String_P011()
   {
      var result = _strValue.RequiresNotEqual(_strTarget, _stringComparer, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresNotEqual_String_P111()
   {
      var result = _strValue.RequiresNotEqual(_strTarget, _stringComparer, _messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresNotEqual_String_P002()
   {
      var result = _strValue.RequiresNotEqual(_strTarget, _comparisonType);
   }

   [Benchmark]
   public void RequiresNotEqual_String_P102()
   {
      var result = _strValue.RequiresNotEqual(_strTarget, _comparisonType, _messageTemplate);
   }

   [Benchmark]
   public void RequiresNotEqual_String_P012()
   {
      var result = _strValue.RequiresNotEqual(_strTarget, _comparisonType, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresNotEqual_String_P112()
   {
      var result = _strValue.RequiresNotEqual(_strTarget, _comparisonType, _messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresNotEqual_Record_P000()
   {
      var result = _boxValue.RequiresNotEqual(_boxTarget);
   }

   [Benchmark]
   public void RequiresNotEqual_Record_P100()
   {
      var result = _boxValue.RequiresNotEqual(_boxTarget, _messageTemplate);
   }

   [Benchmark]
   public void RequiresNotEqual_Record_P010()
   {
      var result = _boxValue.RequiresNotEqual(_boxTarget, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresNotEqual_Record_P110()
   {
      var result = _boxValue.RequiresNotEqual(_boxTarget, _messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresNotEqual_Record_P001()
   {
      var result = _boxValue.RequiresNotEqual(_boxTarget, _boxComparer);
   }

   [Benchmark]
   public void RequiresNotEqual_Record_P101()
   {
      var result = _boxValue.RequiresNotEqual(_boxTarget, _boxComparer, _messageTemplate);
   }

   [Benchmark]
   public void RequiresNotEqual_Record_P011()
   {
      var result = _boxValue.RequiresNotEqual(_boxTarget, _boxComparer, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresNotEqual_Record_P111()
   {
      var result = _boxValue.RequiresNotEqual(_boxTarget, _boxComparer, _messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresNotEqual_Class_P000()
   {
      var result = _observationValue.RequiresNotEqual(_observationTaget);
   }

   [Benchmark]
   public void RequiresNotEqual_Class_P100()
   {
      var result = _observationValue.RequiresNotEqual(_observationTaget, _messageTemplate);
   }

   [Benchmark]
   public void RequiresNotEqual_Class_P010()
   {
      var result = _observationValue.RequiresNotEqual(_observationTaget, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresNotEqual_Class_P110()
   {
      var result = _observationValue.RequiresNotEqual(_observationTaget, _messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresNotEqual_Class_P001()
   {
      var result = _observationValue.RequiresNotEqual(_observationTaget, _observationComparer);
   }

   [Benchmark]
   public void RequiresNotEqual_Class_P101()
   {
      var result = _observationValue.RequiresNotEqual(_observationTaget, _observationComparer, _messageTemplate);
   }

   [Benchmark]
   public void RequiresNotEqual_Class_P011()
   {
      var result = _observationValue.RequiresNotEqual(_observationTaget, _observationComparer, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresNotEqual_Class_P111()
   {
      var result = _observationValue.RequiresNotEqual(_observationTaget, _observationComparer, _messageTemplate, _exceptionFactory);
   }
}
