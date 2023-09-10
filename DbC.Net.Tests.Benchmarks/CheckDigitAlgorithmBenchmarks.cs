// Ignore Spelling: Luhn Barcode Aba

namespace DbC.Net.Tests.Benchmarks;

[MemoryDiagnoser]
public class CheckDigitAlgorithmBenchmarks
{
   private static readonly AbaRoutingNumberAlgorithm _abaAlgorithm = new();
   private static readonly Isbn10Algorithm _isbn10Algorithm = new();
   private static readonly LuhnAlgorithm _luhnAlgorithm = new();
   private static readonly Mod10BarcodeAlgorithm _mod10BarcodeAlgorithm = new();

   [Benchmark]
   public void ThrowAway()
   {
      _ = _luhnAlgorithm.ValidateCheckDigit("3056930009020004");
   }

   [Benchmark]
   public void AbaRoutingNumberAlgorithm()
   {
      _ = _abaAlgorithm.ValidateCheckDigit("111000025");
   }

   [Benchmark]
   public void Isbn10Algorithm()
   {
      _ = _isbn10Algorithm.ValidateCheckDigit("0714105449");
   }

   [Benchmark]
   public void LuhnAlgorithm()
   {
      _ = _luhnAlgorithm.ValidateCheckDigit("3056930009020004");
   }

   [Benchmark]
   public void Mod10BarcodeAlgorithm()
   {
      _ = _mod10BarcodeAlgorithm.ValidateCheckDigit("4006381333931");
   }
}
