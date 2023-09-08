namespace DbC.Net.Tests.Unit.TestResources;

public class AlwaysFailsCheckDigitAlgorithm : ICheckDigitAlgorithm
{
   public String Name => nameof(AlwaysFailsCheckDigitAlgorithm);

   public Boolean ValidateCheckDigit(String value) => false;
}
