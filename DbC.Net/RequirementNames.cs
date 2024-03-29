﻿namespace DbC.Net;

/// <summary>
///   Lists the names of all the requirements supported by DbC.Net.
/// </summary>
public static class RequirementNames
{
   public const String AlphaNumericOnly = nameof(AlphaNumericOnly);
   public const String ApproximatelyEqual = nameof(ApproximatelyEqual);
   public const String Between = nameof(Between);
   public const String Contains = nameof(Contains);
   public const String DigitsOnly = nameof(DigitsOnly);
   public const String EndsWith = nameof(EndsWith);
   public const String Equal = nameof(Equal);
   public const String GreaterThan = nameof(GreaterThan);
   public const String GreaterThanOrEqual = nameof(GreaterThanOrEqual);
   public const String GreaterThanOrEqualToZero = nameof(GreaterThanOrEqualToZero);
   public const String GreaterThanZero = nameof(GreaterThanZero);
   public const String LessThan = nameof(LessThan);
   public const String LessThanOrEqual = nameof(LessThanOrEqual);
   public const String LessThanOrEqualToZero = nameof(LessThanOrEqualToZero);
   public const String LessThanZero = nameof(LessThanZero);
   public const String MaxLength = nameof(MaxLength);
   public const String MinLength = nameof(MinLength);
   public const String NotDefault = nameof(NotDefault);
   public const String NotEmptyOrWhiteSpace = nameof(NotEmptyOrWhiteSpace);
   public const String NotEqual = nameof(NotEqual);
   public const String NotNull = nameof(NotNull);
   public const String NotNullOrEmpty = nameof(NotNullOrEmpty);
   public const String NotNullOrWhiteSpace = nameof(NotNullOrWhiteSpace);
   public const String RegexMatch = nameof(RegexMatch);
   public const String StartsWith = nameof(StartsWith);
}
