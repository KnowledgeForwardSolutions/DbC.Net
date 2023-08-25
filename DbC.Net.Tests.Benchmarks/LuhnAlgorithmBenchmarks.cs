// Ignore Spelling: Luhn

namespace DbC.Net.Tests.Benchmarks;

[MemoryDiagnoser]
public class LuhnAlgorithmBenchmarks
{
   private const String _value = "3056930009020004";
   private static readonly LuhnAlgorithm _luhnAlgorithm = new();

   [Benchmark]
   public void ThrowAway()
   {
      var result = _luhnAlgorithm.ValidateCheckDigit(_value);
   }

   [Benchmark]
   public void Original()
   {
      var result = _luhnAlgorithm.ValidateCheckDigit(_value);
   }
}
