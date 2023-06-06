namespace DbC.Net.Tests.Benchmarks;

[MemoryDiagnoser]
public class MinLengthBenchmarks
{
   private const String _strEmpty = "";
   private const String _strNull = null!;
   private const String _strValue = "abcdefghij";
   private const String _strValueWithUnicodeCharacters = "\u00C5\u00E5\u00C6\u00E6\u1E9E\u00DF\u0130\u0131\u00D8\u00F8";

   private const Int32 _minLength = 5;
   private const Int32 _emptyStringMinLength = 0;

   private const String _messageTemplate = "Requires{RequirementName} failed: {Value} must be at least 10 characters in length";
   private static readonly IExceptionFactory _exceptionFactory = StandardExceptionFactories.InvalidOperationExceptionFactory;

   [Benchmark]
   public void ThrowAway()
   {
      var result = _strValue.RequiresMinLength(_minLength);
   }

   [Benchmark]
   public void RequiresMinLength_String_P000()
   {
      var result = _strValue.RequiresMinLength(_minLength);
   }

   [Benchmark]
   public void RequiresMinLength_String_P100()
   {
      var result = _strValue.RequiresMinLength(_minLength, _messageTemplate);
   }

   [Benchmark]
   public void RequiresMinLength_String_P010()
   {
      var result = _strValue.RequiresMinLength(_minLength, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresMinLength_String_P110()
   {
      var result = _strValue.RequiresMinLength(_minLength, _messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresMinLength_StringWithUnicode_P000()
   {
      var result = _strValueWithUnicodeCharacters.RequiresMinLength(_minLength);
   }

   [Benchmark]
   public void RequiresMinLength_StringWithUnicode_P100()
   {
      var result = _strValueWithUnicodeCharacters.RequiresMinLength(_minLength, _messageTemplate);
   }

   [Benchmark]
   public void RequiresMinLength_StringWithUnicode_P010()
   {
      var result = _strValueWithUnicodeCharacters.RequiresMinLength(_minLength, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresMinLength_StringWithUnicode_P110()
   {
      var result = _strValueWithUnicodeCharacters.RequiresMinLength(_minLength, _messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresMinLength_NullString_P000()
   {
      var result = _strNull.RequiresMinLength(_emptyStringMinLength);
   }

   [Benchmark]
   public void RequiresMinLength_NullString_P100()
   {
      var result = _strNull.RequiresMinLength(_emptyStringMinLength, _messageTemplate);
   }

   [Benchmark]
   public void RequiresMinLength_NullString_P010()
   {
      var result = _strNull.RequiresMinLength(_emptyStringMinLength, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresMinLength_NullString_P110()
   {
      var result = _strNull.RequiresMinLength(_emptyStringMinLength, _messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresMinLength_EmptyString_P000()
   {
      var result = _strEmpty.RequiresMinLength(_emptyStringMinLength);
   }

   [Benchmark]
   public void RequiresMinLength_EmptyString_P100()
   {
      var result = _strEmpty.RequiresMinLength(_emptyStringMinLength, _messageTemplate);
   }

   [Benchmark]
   public void RequiresMinLength_EmptyString_P010()
   {
      var result = _strEmpty.RequiresMinLength(_emptyStringMinLength, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresMinLength_EmptyString_P110()
   {
      var result = _strEmpty.RequiresMinLength(_emptyStringMinLength, _messageTemplate, _exceptionFactory);
   }
}