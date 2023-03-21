namespace DbC.Net.Exceptions;

public static class DataNames
{
    public const string RequirementName = nameof(RequirementName);
    public const string RequirementType = nameof(RequirementType);

    // The value being checked.
    public const string Value = nameof(Value);
    public const string ValueExpression = nameof(ValueExpression);
    public const string ValueDatatype = nameof(ValueDatatype);

    // The target for equality checks.
    public const string Target = nameof(Target);
    public const string TargetExpression = nameof(TargetExpression);

    public const string Epsilon = nameof(Epsilon);
    public const string EpsilonExpression = nameof(EpsilonExpression);

    // The limits for comparable checks.
    public const string LowerBound = nameof(LowerBound);
    public const string LowerBoundExpression = nameof(LowerBoundExpression);
    public const string UpperBound = nameof(UpperBound);
    public const string UpperBoundExpression = nameof(UpperBoundExpression);

    // String min/max length checks.
    public const string MaxLength = nameof(MaxLength);
    public const string MaxLengthExpression = nameof(MaxLengthExpression);
    public const string MinLength = nameof(MinLength);
    public const string MinLengthExpression = nameof(MinLengthExpression);

    public const string Regex = nameof(Regex);

    public const string StringComparison = nameof(StringComparison);
}
