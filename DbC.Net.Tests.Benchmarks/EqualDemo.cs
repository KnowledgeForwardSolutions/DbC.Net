namespace DbC.Net.Tests.Benchmarks;

public static class EqualDemo
{
   public static T RequiresValueTypeEqual<T>(this T value, T expected) where T : struct, IEquatable<T>
      => !value.Equals(expected)
         ? throw new ArgumentException("should be equal", nameof(value))
         : value;

   public static Int32 RequiresEqual(this Int32 value, Int32 expected)
      => !value.Equals(expected)
         ? throw new ArgumentException("should be equal", nameof(value))
         : value;

   public static T RequiresRefTypeEqual<T>(this T value, T expected) where T : class, IEquatable<T>
      => (value is null ^ expected is null) || (value is null && !value!.Equals(expected))
         ? throw new ArgumentException("should be equal", nameof(value))
         : value;

   public static T RequiresEqual<T>(this T value, T expected, IEqualityComparer<T> comparer)
      => !comparer.Equals(value, expected)
         ? throw new ArgumentException("should be equal", nameof(value))
         : value;

   public static String RequiresEqual(this String value, String expected, StringComparison comparisonType)
      => (value is null ^ expected is null) || !value!.Equals(expected, comparisonType)
         ? throw new ArgumentException("should be equal", nameof(value))
         : value;
}
