﻿namespace DbC.Net.Tests.Benchmarks;

[MemoryDiagnoser]
public class GreaterThanBenchmarks
{
   private const Int32 _intValue = 100;
   private const Int32 _intUpperBound = 99;
   private static readonly IComparer<Int32> _intComparer = Comparer<Int32>.Default;

   private const String _strValue = "qwerty";
   private const String _strUpperBound = "ASDF";
   private static readonly IComparer<String> _stringComparer = StringComparer.OrdinalIgnoreCase;
   private const StringComparison _comparisonType = StringComparison.OrdinalIgnoreCase;

   private static readonly Box _boxValue = new(4, 16, 36, "Purple");
   private static readonly Box _boxUpperBound = new(2, 4, 8, "Green");
   private static readonly IComparer<Box> _boxComparer = BoxComparers.AllFieldsComparer;

   private static readonly Observation _observationValue = new()
   {
      ObservationId = new Guid("f77e70ee-6fff-45f4-96e5-5bbb02f7ee08"),
      ObservationTimestamp = new DateTime(2023, 12, 23, 10, 38, 47, 889),
      ObservationType = ObservationType.Temperature,
      Value = 16.278,
      Units = Units.DegreesCelsius
   };
   private static readonly Observation _observationUpperBound = new()
   {
      ObservationId = new Guid("f77d70bc-6eea-45f4-96e5-5bbb02f7ee08"),
      ObservationTimestamp = new DateTime(2022, 11, 22, 9, 37, 46, 789),
      ObservationType = ObservationType.Temperature,
      Value = 6.278,
      Units = Units.DegreesCelsius
   };
   private static readonly IComparer<Observation> _observationComparer = ObservationComparers.AllFieldsComparer;

   private const String _messageTemplate = "Requires{RequirementName} failed: {Value} must be greater than {Target}";
   private static readonly IExceptionFactory _exceptionFactory = StandardExceptionFactories.InvalidOperationExceptionFactory;

   [Benchmark]
   public void ThrowAway()
   {
      var result = _intValue.RequiresGreaterThan(_intUpperBound);
   }

   [Benchmark]
   public void RequiresGreaterThan_Int32_P000()
   {
      var result = _intValue.RequiresGreaterThan(_intUpperBound);
   }

   [Benchmark]
   public void RequiresGreaterThan_Int32_P100()
   {
      var result = _intValue.RequiresGreaterThan(_intUpperBound, _messageTemplate);
   }

   [Benchmark]
   public void RequiresGreaterThan_Int32_P010()
   {
      var result = _intValue.RequiresGreaterThan(_intUpperBound, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresGreaterThan_Int32_P110()
   {
      var result = _intValue.RequiresGreaterThan(_intUpperBound, _messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresGreaterThan_Int32_P001()
   {
      var result = _intValue.RequiresGreaterThan(_intUpperBound, _intComparer);
   }

   [Benchmark]
   public void RequiresGreaterThan_Int32_P101()
   {
      var result = _intValue.RequiresGreaterThan(_intUpperBound, _intComparer, _messageTemplate);
   }

   [Benchmark]
   public void RequiresGreaterThan_Int32_P011()
   {
      var result = _intValue.RequiresGreaterThan(_intUpperBound, _intComparer, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresGreaterThan_Int32_P111()
   {
      var result = _intValue.RequiresGreaterThan(_intUpperBound, _intComparer, _messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresGreaterThan_String_P000()
   {
      var result = _strValue.RequiresGreaterThan(_strUpperBound);
   }

   [Benchmark]
   public void RequiresGreaterThan_String_P100()
   {
      var result = _strValue.RequiresGreaterThan(_strUpperBound, _messageTemplate);
   }

   [Benchmark]
   public void RequiresGreaterThan_String_P010()
   {
      var result = _strValue.RequiresGreaterThan(_strUpperBound, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresGreaterThan_String_P110()
   {
      var result = _strValue.RequiresGreaterThan(_strUpperBound, _messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresGreaterThan_String_P001()
   {
      var result = _strValue.RequiresGreaterThan(_strUpperBound, _stringComparer);
   }

   [Benchmark]
   public void RequiresGreaterThan_String_P101()
   {
      var result = _strValue.RequiresGreaterThan(_strUpperBound, _stringComparer, _messageTemplate);
   }

   [Benchmark]
   public void RequiresGreaterThan_String_P011()
   {
      var result = _strValue.RequiresGreaterThan(_strUpperBound, _stringComparer, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresGreaterThan_String_P111()
   {
      var result = _strValue.RequiresGreaterThan(_strUpperBound, _stringComparer, _messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresGreaterThan_String_P002()
   {
      var result = _strValue.RequiresGreaterThan(_strUpperBound, _comparisonType);
   }

   [Benchmark]
   public void RequiresGreaterThan_String_P102()
   {
      var result = _strValue.RequiresGreaterThan(_strUpperBound, _comparisonType, _messageTemplate);
   }

   [Benchmark]
   public void RequiresGreaterThan_String_P012()
   {
      var result = _strValue.RequiresGreaterThan(_strUpperBound, _comparisonType, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresGreaterThan_String_P112()
   {
      var result = _strValue.RequiresGreaterThan(_strUpperBound, _comparisonType, _messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresGreaterThan_Record_P000()
   {
      var result = _boxValue.RequiresGreaterThan(_boxUpperBound);
   }

   [Benchmark]
   public void RequiresGreaterThan_Record_P100()
   {
      var result = _boxValue.RequiresGreaterThan(_boxUpperBound, _messageTemplate);
   }

   [Benchmark]
   public void RequiresGreaterThan_Record_P010()
   {
      var result = _boxValue.RequiresGreaterThan(_boxUpperBound, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresGreaterThan_Record_P110()
   {
      var result = _boxValue.RequiresGreaterThan(_boxUpperBound, _messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresGreaterThan_Record_P001()
   {
      var result = _boxValue.RequiresGreaterThan(_boxUpperBound, _boxComparer);
   }

   [Benchmark]
   public void RequiresGreaterThan_Record_P101()
   {
      var result = _boxValue.RequiresGreaterThan(_boxUpperBound, _boxComparer, _messageTemplate);
   }

   [Benchmark]
   public void RequiresGreaterThan_Record_P011()
   {
      var result = _boxValue.RequiresGreaterThan(_boxUpperBound, _boxComparer, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresGreaterThan_Record_P111()
   {
      var result = _boxValue.RequiresGreaterThan(_boxUpperBound, _boxComparer, _messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresGreaterThan_Class_P000()
   {
      var result = _observationValue.RequiresGreaterThan(_observationUpperBound);
   }

   [Benchmark]
   public void RequiresGreaterThan_Class_P100()
   {
      var result = _observationValue.RequiresGreaterThan(_observationUpperBound, _messageTemplate);
   }

   [Benchmark]
   public void RequiresGreaterThan_Class_P010()
   {
      var result = _observationValue.RequiresGreaterThan(_observationUpperBound, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresGreaterThan_Class_P110()
   {
      var result = _observationValue.RequiresGreaterThan(_observationUpperBound, _messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresGreaterThan_Class_P001()
   {
      var result = _observationValue.RequiresGreaterThan(_observationUpperBound, _observationComparer);
   }

   [Benchmark]
   public void RequiresGreaterThan_Class_P101()
   {
      var result = _observationValue.RequiresGreaterThan(_observationUpperBound, _observationComparer, _messageTemplate);
   }

   [Benchmark]
   public void RequiresGreaterThan_Class_P011()
   {
      var result = _observationValue.RequiresGreaterThan(_observationUpperBound, _observationComparer, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresGreaterThan_Class_P111()
   {
      var result = _observationValue.RequiresGreaterThan(_observationUpperBound, _observationComparer, _messageTemplate, _exceptionFactory);
   }
}
