namespace DbC.Net.Tests.Benchmarks;

[MemoryDiagnoser]
public class RegexMatchBenchmarks
{
   private const String _messageTemplate = "{Value} must be a valid IP Address";
   private static readonly IExceptionFactory _exceptionFactory = StandardExceptionFactories.InvalidOperationExceptionFactory;

   private const String _stringRegex = @"^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
   private readonly Regex _compiledRegex = new(_stringRegex, RegexOptions.Compiled);

   private const String _value = "192.168.1.32";

   [Benchmark]
   public void ThrowAway()
   {
      var result = _value.RequiresRegexMatch(_stringRegex);
   }

   [Benchmark]
   public void RequiresRegexMatch_String_P000()
   {
      var result = _value.RequiresRegexMatch(_stringRegex);
   }

   [Benchmark]
   public void RequiresRegexMatch_String_P010()
   {
      var result = _value.RequiresRegexMatch(_stringRegex, messageTemplate: _messageTemplate);
   }

   [Benchmark]
   public void RequiresRegexMatch_String_P001()
   {
      var result = _value.RequiresRegexMatch(_stringRegex, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresRegexMatch_String_P011()
   {
      var result = _value.RequiresRegexMatch(_stringRegex, messageTemplate: _messageTemplate, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresRegexMatch_String_P100()
   {
      var result = _value.RequiresRegexMatch(_stringRegex, RegexOptions.IgnoreCase);
   }

   [Benchmark]
   public void RequiresRegexMatch_String_P110()
   {
      var result = _value.RequiresRegexMatch(_stringRegex, RegexOptions.IgnoreCase, _messageTemplate);
   }

   [Benchmark]
   public void RequiresRegexMatch_String_P101()
   {
      var result = _value.RequiresRegexMatch(_stringRegex, RegexOptions.IgnoreCase, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresRegexMatch_String_P111()
   {
      var result = _value.RequiresRegexMatch(_stringRegex, RegexOptions.IgnoreCase, _messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresRegexMatch_Compiled_P000()
   {
      var result = _value.RequiresRegexMatch(_compiledRegex);
   }

   [Benchmark]
   public void RequiresRegexMatch_Compiled_P010()
   {
      var result = _value.RequiresRegexMatch(_compiledRegex, _messageTemplate);
   }

   [Benchmark]
   public void RequiresRegexMatch_Compiled_P001()
   {
      var result = _value.RequiresRegexMatch(_compiledRegex, exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresRegexMatch_Compiled_P011()
   {
      var result = _value.RequiresRegexMatch(_compiledRegex, _messageTemplate, _exceptionFactory);
   }

   [Benchmark]
   public void RequiresRegexMatch_Generated_P000()
   {
      var result = _value.RequiresRegexMatch(IpAddressRegex.Regex());
   }

   [Benchmark]
   public void RequiresRegexMatch_Generated_P010()
   {
      var result = _value.RequiresRegexMatch(IpAddressRegex.Regex(), _messageTemplate);
   }

   [Benchmark]
   public void RequiresRegexMatch_Generated_P001()
   {
      var result = _value.RequiresRegexMatch(IpAddressRegex.Regex(), exceptionFactory: _exceptionFactory);
   }

   [Benchmark]
   public void RequiresRegexMatch_Generated_P011()
   {
      var result = _value.RequiresRegexMatch(IpAddressRegex.Regex(), _messageTemplate, _exceptionFactory);
   }
}
