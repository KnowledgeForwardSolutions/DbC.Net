namespace DbC.Net.Tests.Unit.TestData;

public class StringData : ComparableValue<String>
{
   public StringData() : base(
      "asdf",
      "qwerty",
      new ReverseComparer<String>(),
      "AA",
      "zz")
   { }

   public const String UpperCaseA = "A";
   public const String LowerCaseA = "a";

   public const String UpperCaseAE = "AE";
   public const String LowerCaseAE = "ae";

   public const String LowerCaseADash = "a-";

   public const String UpperCaseDipthongAE = "\u00C6";
   public const String LowerCaseDipthongAE = "\u00E6";

   public const String UpperCaseEszett = "\u1E9E";
   public const String LowerCaseEszett = "\u00DF";

   public const String UpperCaseI = "I";
   public const String LowerCaseI = "i";

   public const String UpperCaseJ = "J";
   public const String LowerCaseJ = "j";

   public const String UpperCaseDottedI = "\u0130";
   public const String LowerCaseDotlessI = "\u0131";

   public const String UpperCaseSlashedO = "\u00D8";
   public const String LowerCaseSlashedO = "\u00F8";

   public const String UpperCaseSs = "SS";
   public const String LowerCaseSs = "ss";

   public const String UpperCaseZ = "Z";
   public const String LowerCaseZ = "z";
}