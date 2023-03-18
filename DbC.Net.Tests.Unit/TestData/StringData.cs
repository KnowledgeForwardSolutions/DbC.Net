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

   // A with diaeresis sorts between A(overring) and O(diaeresis) in sv-SE culture (Swedish/Sweden)
   public const String UpperCaseAWithDiaeresis = "\u00C4";
   public const String LowerCaseAWithDiaeresis = "\u00E4";

   // A with overring sorts as the last character, after O with slash, in da-DK culture (Danish/Denmark)
   // and between Z and A(diaeresis) in sv-SE culture (Swedish/Sweden)
   public const String UpperCaseAWithOverring = "\u00C5";
   public const String LowerCaseAWithOverring = "\u00E5";

   public const String UpperCaseAE = "AE";
   public const String LowerCaseAE = "ae";

   // a- is considered equal to a in th-TH culture (Thai/Thailand)
   public const String LowerCaseADash = "a-";

   // Diphthong AE sorts between z and o with slash in da-DK culture (Danish/Denmark)
   public const String UpperCaseDiphthongAE = "\u00C6";
   public const String LowerCaseDiphthongAE = "\u00E6";

   public const String UpperCaseEszett = "\u1E9E";
   public const String LowerCaseEszett = "\u00DF";

   public const String UpperCaseH = "H";
   public const String LowerCaseH = "h";

   public const String UpperCaseI = "I";
   public const String LowerCaseI = "i";

   public const String UpperCaseJ = "J";
   public const String LowerCaseJ = "j";

   // Dot-less I sorts between H and dotted I in tr-TR culture (Turkish/Turkey)
   public const String UpperCaseDottedI = "\u0130";
   public const String LowerCaseDotlessI = "\u0131";

   // O with slash sorts between diphthong AE and a(overring) in da-DK culture (Danish/Denmark)
   public const String UpperCaseSlashedO = "\u00D8";
   public const String LowerCaseSlashedO = "\u00F8";

   // O with diaeresis (or umlaut) sorts after Z, A(overring), A(diaeresis) in sv-SE culture (Swedish/Sweden)
   // and between o and p in tr-TR culture (Turkish)
   public const String UpperCaseOWithDiaeresis = "\u00D6";
   public const String LowerCaseOWithDiaeresis = "\u00F6";

   public const String UpperCaseSs = "SS";
   public const String LowerCaseSs = "ss";

   public const String UpperCaseZ = "Z";
   public const String LowerCaseZ = "z";
}