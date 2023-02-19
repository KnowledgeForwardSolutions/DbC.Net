namespace DbC.Net.Tests.Benchmarks;

public class EqualDemoBenchmarks
{
   private const Int32 _intValue = 99;
   private const Int32 _intExpected = _intValue;
   private static readonly IEqualityComparer<Int32> _intComparer = EqualityComparer<Int32>.Default;

   private const String _strValue = "asdf";
   private const String _strExpectedLc = "asdf";
   private const String _strExpected = "ASDF";
   private static readonly IEqualityComparer<String> _strComparer = StringComparer.OrdinalIgnoreCase;
   private const StringComparison _strComparisonType = StringComparison.OrdinalIgnoreCase;

   [Benchmark]
   public void ThrowAway()
   {
      var result = _intValue.RequiresValueTypeEqual(_intExpected);
   }

   [Benchmark]
   public void RequiresEqual_Int32()
   {
      var result = _intValue.RequiresEqual(_intExpected);
   }

   [Benchmark]
   public void RequiresEqual_IEquatable_Int32()
   {
      var result = _intValue.RequiresValueTypeEqual(_intExpected);
   }

   [Benchmark]
   public void RequiresEqual_IEqualityComparer_Int32()
   {
      var result = _intValue.RequiresEqual(_intExpected, _intComparer);
   }

   [Benchmark]
   public void RequiresEqual_IEquatable_String()
   {
      var result = _strValue.RequiresRefTypeEqual(_strExpectedLc);
   }

   [Benchmark]
   public void RequiresEqual_IEqualityComparer_String()
   {
      var result = _strValue.RequiresEqual(_strExpected, _strComparer);
   }

   [Benchmark]
   public void RequiresEqual_String_ComparisonType()
   {
      var result = _strValue.RequiresEqual(_strExpected, _strComparisonType);
   }
}
