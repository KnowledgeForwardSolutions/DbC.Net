// Ignore Spelling: Aba Luhn Barcode Npi

namespace DbC.Net.Tests.Benchmarks;

[MemoryDiagnoser]
public class ValidCheckDigitBenchmarks
{
   private static readonly ICheckDigitAlgorithm _abaAlgorithm = StandardCheckDigitAlgorithms.AbaRoutingNumberAlgorithm;
   private static readonly ICheckDigitAlgorithm _isbn10Algorithm = StandardCheckDigitAlgorithms.Isbn10Algorithm;
   private static readonly ICheckDigitAlgorithm _luhnAlgorithm = StandardCheckDigitAlgorithms.LuhnAlgorithm;
   private static readonly ICheckDigitAlgorithm _mod10BarcodeAlgorithm = StandardCheckDigitAlgorithms.Mod10BarcodeAlgorithm;
   private static readonly ICheckDigitAlgorithm _npiAlgorithm = StandardCheckDigitAlgorithms.NpiAlgorithm;
   private static readonly ICheckDigitAlgorithm _vinAlgorithm = StandardCheckDigitAlgorithms.VehicleIdentificationNumberAlgorithm;

   private const String _messageTemplate = "{Value} must contain a valid check digit";
   private static readonly IExceptionFactory _exceptionFactory = StandardExceptionFactories.InvalidOperationExceptionFactory;

   private const String _routingNumber = "111000025";
   private const String _isbn10Number = "050027293X";
   private const String _creditCardNumber = "4111111111111111";
   private const String _ean13Number = "4006381333931";
   private const String _npiNumber = "1234567893";
   private const String _vinNumber = "1M8GDM9AXKP042788";

   [Benchmark]
   public void ThrowAway()
   {
      _ = _routingNumber.RequiresValidCheckDigit(_abaAlgorithm);
   }

   [Benchmark]
   public void AbaRoutingNumberAlgorithm_P000()
   {
      _ = _routingNumber.RequiresValidCheckDigit(_abaAlgorithm);
   }

   [Benchmark]
   public void AbaRoutingNumberAlgorithm_P010()
   {
      _ = _routingNumber.RequiresValidCheckDigit(_abaAlgorithm, _messageTemplate);
   }

   [Benchmark]
   public void AbaRoutingNumberAlgorithm_P001()
   {
      _ = _routingNumber.RequiresValidCheckDigit(_abaAlgorithm, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void AbaRoutingNumberAlgorithm_P011()
   {
      _ = _routingNumber.RequiresValidCheckDigit(_abaAlgorithm, _messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void Isbn10Algorithm_P000()
   {
      _ = _isbn10Number.RequiresValidCheckDigit(_isbn10Algorithm);
   }

   [Benchmark]
   public void Isbn10Algorithm_P010()
   {
      _ = _isbn10Number.RequiresValidCheckDigit(_isbn10Algorithm, _messageTemplate);
   }

   [Benchmark]
   public void Isbn10Algorithm_P001()
   {
      _ = _isbn10Number.RequiresValidCheckDigit(_isbn10Algorithm, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void Isbn10Algorithm_P011()
   {
      _ = _isbn10Number.RequiresValidCheckDigit(_isbn10Algorithm, _messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void LuhnAlgorithm_P000()
   {
      _ = _creditCardNumber.RequiresValidCheckDigit(_luhnAlgorithm);
   }

   [Benchmark]
   public void LuhnAlgorithm_P010()
   {
      _ = _creditCardNumber.RequiresValidCheckDigit(_luhnAlgorithm, _messageTemplate);
   }

   [Benchmark]
   public void LuhnAlgorithm_P001()
   {
      _ = _creditCardNumber.RequiresValidCheckDigit(_luhnAlgorithm, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void LuhnAlgorithm_P011()
   {
      _ = _creditCardNumber.RequiresValidCheckDigit(_luhnAlgorithm, _messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void Mod10BarcodeAlgorithm_P000()
   {
      _ = _ean13Number.RequiresValidCheckDigit(_mod10BarcodeAlgorithm);
   }

   [Benchmark]
   public void Mod10BarcodeAlgorithm_P010()
   {
      _ = _ean13Number.RequiresValidCheckDigit(_mod10BarcodeAlgorithm, _messageTemplate);
   }

   [Benchmark]
   public void Mod10BarcodeAlgorithm_P001()
   {
      _ = _ean13Number.RequiresValidCheckDigit(_mod10BarcodeAlgorithm, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void Mod10BarcodeAlgorithm_P011()
   {
      _ = _ean13Number.RequiresValidCheckDigit(_mod10BarcodeAlgorithm, _messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void NpiAlgorithm_P000()
   {
      _ = _npiNumber.RequiresValidCheckDigit(_npiAlgorithm);
   }

   [Benchmark]
   public void NpiAlgorithm_P010()
   {
      _ = _npiNumber.RequiresValidCheckDigit(_npiAlgorithm, _messageTemplate);
   }

   [Benchmark]
   public void NpiAlgorithm_P001()
   {
      _ = _npiNumber.RequiresValidCheckDigit(_npiAlgorithm, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void NpiAlgorithm_P011()
   {
      _ = _npiNumber.RequiresValidCheckDigit(_npiAlgorithm, _messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void VehicleIdentificationNumberAlgorithm_P000()
   {
      _ = _vinNumber.RequiresValidCheckDigit(_vinAlgorithm);
   }

   [Benchmark]
   public void VehicleIdentificationNumberAlgorithm_P010()
   {
      _ = _vinNumber.RequiresValidCheckDigit(_vinAlgorithm, _messageTemplate);
   }

   [Benchmark]
   public void VehicleIdentificationNumberAlgorithm_P001()
   {
      _ = _vinNumber.RequiresValidCheckDigit(_vinAlgorithm, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void VehicleIdentificationNumberAlgorithm_P011()
   {
      _ = _vinNumber.RequiresValidCheckDigit(_vinAlgorithm, _messageTemplate, _exceptionFactory);
   }
}
