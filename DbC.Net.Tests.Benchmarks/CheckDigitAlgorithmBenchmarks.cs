// Ignore Spelling: Luhn Barcode Aba Npi Verhoeff

namespace DbC.Net.Tests.Benchmarks;

[MemoryDiagnoser]
public class CheckDigitAlgorithmBenchmarks
{
   private static readonly ICheckDigitAlgorithm _abaAlgorithm = StandardCheckDigitAlgorithms.AbaRoutingNumberAlgorithm;
   private static readonly ICheckDigitAlgorithm _isbn10Algorithm = StandardCheckDigitAlgorithms.Isbn10Algorithm;
   private static readonly ICheckDigitAlgorithm _luhnAlgorithm = StandardCheckDigitAlgorithms.LuhnAlgorithm;
   private static readonly ICheckDigitAlgorithm _mod10BarcodeAlgorithm = StandardCheckDigitAlgorithms.Mod10BarcodeAlgorithm;
   private static readonly ICheckDigitAlgorithm _npiAlgorithm = StandardCheckDigitAlgorithms.NpiAlgorithm;
   private static readonly ICheckDigitAlgorithm _vinAlgorithm = StandardCheckDigitAlgorithms.VehicleIdentificationNumberAlgorithm;
   private static readonly ICheckDigitAlgorithm _verhoeffAlgorithm = StandardCheckDigitAlgorithms.VerhoeffAlgorithm;

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

   [Benchmark]
   public void NpiAlgorithm()
   {
      _ = _npiAlgorithm.ValidateCheckDigit("1234567893");
   }

   [Benchmark]
   public void VehicleIdentificationNumberAlgorithm()
   {
      _ = _vinAlgorithm.ValidateCheckDigit("1FTZX1722XKA76091");
   }

   [Benchmark]
   public void VerhoeffAlgorithm()
   {
      _ = _verhoeffAlgorithm.ValidateCheckDigit("1234567890120");
   }
}
