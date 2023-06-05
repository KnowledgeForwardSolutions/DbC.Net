namespace DbC.Net.Tests.Benchmarks;

[MemoryDiagnoser]
public class MaxLengthBenchmarks
{
   private const String _strEmpty = "";
   private const String _strNull = null!;
   private const String _strValue = "abcdefghij";
   private const String _strValueWithUnicodeCharacters = "\u00C5\u00E5\u00C6\u00E6\u1E9E\u00DF\u0130\u0131\u00D8\u00F8";

   private const Int32 _maxLength = 10;

   private const String _messageTemplate = "Requires{RequirementName} failed: {Value} must not be longer than 10 characters";
   private static readonly IExceptionFactory _exceptionFactory = StandardExceptionFactories.InvalidOperationExceptionFactory;

   [Benchmark]
   public void ThrowAway()
   {
      var result = _strValue.RequiresMaxLength(_maxLength);
   }

   [Benchmark]
   public void RequiresMaxLength_String_P000()
   {
      var result = _strValue.RequiresMaxLength(_maxLength);
   }

   [Benchmark]
   public void RequiresMaxLength_String_P100()
   {
      var result = _strValue.RequiresMaxLength(_maxLength, _messageTemplate);
   }

   [Benchmark]
   public void RequiresMaxLength_String_P010()
   {
      var result = _strValue.RequiresMaxLength(_maxLength, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresMaxLength_String_P110()
   {
      var result = _strValue.RequiresMaxLength(_maxLength, _messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresMaxLength_StringWithUnicode_P000()
   {
      var result = _strValueWithUnicodeCharacters.RequiresMaxLength(_maxLength);
   }

   [Benchmark]
   public void RequiresMaxLength_StringWithUnicode_P100()
   {
      var result = _strValueWithUnicodeCharacters.RequiresMaxLength(_maxLength, _messageTemplate);
   }

   [Benchmark]
   public void RequiresMaxLength_StringWithUnicode_P010()
   {
      var result = _strValueWithUnicodeCharacters.RequiresMaxLength(_maxLength, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresMaxLength_StringWithUnicode_P110()
   {
      var result = _strValueWithUnicodeCharacters.RequiresMaxLength(_maxLength, _messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresMaxLength_NullString_P000()
   {
      var result = _strNull.RequiresMaxLength(_maxLength);
   }

   [Benchmark]
   public void RequiresMaxLength_NullString_P100()
   {
      var result = _strNull.RequiresMaxLength(_maxLength, _messageTemplate);
   }

   [Benchmark]
   public void RequiresMaxLength_NullString_P010()
   {
      var result = _strNull.RequiresMaxLength(_maxLength, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresMaxLength_NullString_P110()
   {
      var result = _strNull.RequiresMaxLength(_maxLength, _messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresMaxLength_EmptyString_P000()
   {
      var result = _strEmpty.RequiresMaxLength(_maxLength);
   }

   [Benchmark]
   public void RequiresMaxLength_EmptyString_P100()
   {
      var result = _strEmpty.RequiresMaxLength(_maxLength, _messageTemplate);
   }

   [Benchmark]
   public void RequiresMaxLength_EmptyString_P010()
   {
      var result = _strEmpty.RequiresMaxLength(_maxLength, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresMaxLength_EmptyString_P110()
   {
      var result = _strEmpty.RequiresMaxLength(_maxLength, _messageTemplate, _exceptionFactory);
   }
}
