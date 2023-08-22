namespace DbC.Net.Exceptions;

public static class DataNames
{
    public const String RequirementName = nameof(RequirementName);
    public const String RequirementType = nameof(RequirementType);

    // The value being checked.
    public const String Value = nameof(Value);
    public const String ValueExpression = nameof(ValueExpression);
    public const String ValueDatatype = nameof(ValueDatatype);

    // The target for equality checks.
    public const String Target = nameof(Target);
    public const String TargetExpression = nameof(TargetExpression);

    public const String Epsilon = nameof(Epsilon);
    public const String EpsilonExpression = nameof(EpsilonExpression);

    // The limits for comparable checks.
    public const String LowerBound = nameof(LowerBound);
    public const String LowerBoundExpression = nameof(LowerBoundExpression);
    public const String UpperBound = nameof(UpperBound);
    public const String UpperBoundExpression = nameof(UpperBoundExpression);

    // String min/max length checks.
    public const String MaxLength = nameof(MaxLength);
    public const String MaxLengthExpression = nameof(MaxLengthExpression);
    public const String MinLength = nameof(MinLength);
    public const String MinLengthExpression = nameof(MinLengthExpression);

   public const String Regex = nameof(Regex);
   public const String RegexOptions = nameof(RegexOptions);

   public const String StringComparison = nameof(StringComparison);

   // Check digits. Target = expected check digit per the algorithm. Value = check digit found in the value string
   public const String CheckDigitAlgorithm = nameof(CheckDigitAlgorithm);
   public const String TargetCheckDigit = nameof(TargetCheckDigit);
   public const String ValueCheckDigit = nameof(ValueCheckDigit);
}
