namespace DbC.Net.Tests.Unit.TestResources;

public class AlwaysSucceedsCheckDigitAlgorithm : ICheckDigitAlgorithm
{
   public String Name => nameof(AlwaysSucceedsCheckDigitAlgorithm);

   public Boolean ValidateCheckDigit(String value) => true;
}
